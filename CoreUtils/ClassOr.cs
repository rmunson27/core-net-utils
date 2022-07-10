using Rem.CoreUtils.CodeAnalysis;
using Rem.CoreUtils.ComponentModel;
using Rem.CoreUtils.Helpers.Throw;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace Rem.CoreUtils;

using TypeFlags2 = OrType2.TypeFlags;

/// <summary>
/// Static functionality relating to instances that represent a logical OR of two or more reference types.
/// </summary>
public static class ClassOr
{
    /// <summary>
    /// Allows one of the types of the class OR to be fixed to simplify generic calls.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Fix<T> where T : class
    {
        /// <summary>
        /// Creates a new <see cref="ClassOr{T1, T2}"/> from the value passed in without casting.
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="child"></param>
        /// <returns></returns>
        [return: NotDefault, MaybeDefaultIfParameterDefault("child")]
        public static ClassOr<T, T2> FromT1Child<TChild, T2>(ClassOr<TChild, T2> child)
            where TChild : class, T
            where T2 : class
            => child.IsDefault ? default : new(child._value, OrType2.DescribeType<T, T2>(child._value));

        /// <summary>
        /// Creates a new <see cref="ClassOr{T1, T2}"/> from the value passed in without casting.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="child"></param>
        /// <returns></returns>
        [return: NotDefault, MaybeDefaultIfParameterDefault("child")]
        public static ClassOr<T1, T> FromT2Child<T1, TChild>(ClassOr<T1, TChild> child)
            where T1 : class
            where TChild : class, T
            => child.IsDefault ? default : new(child._value, OrType2.DescribeType<T1, T>(child._value));
    }
}

/// <summary>
/// Represents a logical OR of two reference types.
/// </summary>
/// 
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// 
/// <remarks>
/// <para>
/// Instances of this type cannot be explicitly constructed wrapping <see langword="null"/>; however, the default
/// value of the type wraps <see langword="null"/>.  Most instance methods and properties function normally (without
/// throwing an exception) when called on the default instance, and those that do not are decorated with
/// <see cref="DoesNotReturnIfInstanceDefaultAttribute"/>.  Therefore, the default value of the type can be effectively
/// used to represent the <see langword="null"/> case.
/// </para>
/// 
/// <para>
/// Some methods or properties may return <see langword="null"/> when called on the default instance even if the
/// nullability of the corresponding type disallows it.  These methods or properties are decorated with
/// <see cref="MaybeDefaultIfInstanceDefaultAttribute"/>.
/// </para>
/// </remarks>
public readonly struct ClassOr<T1, T2>
    : IOrType<T1, T2>, IDefaultDeterminableStruct, IEquatable<ClassOr<T1, T2>>, IStructuralEquatable
    where T1 : class
    where T2 : class
{
    #region Properties
    /// <inheritdoc cref="IDefaultDeterminableStruct.IsDefault"/>
    public bool IsDefault => _typeFlags == TypeFlags2.None;

    /// <inheritdoc cref="IDefaultDeterminableStruct.IsNotDefault"/>
    public bool IsNotDefault => _typeFlags != TypeFlags2.None;

    /// <summary>
    /// Gets the value wrapped in this instance typed as an instance of <typeparamref name="T1"/>, or
    /// <see langword="null"/> if this instance does not wrap a <typeparamref name="T1"/> value.
    /// </summary>
    public T1? AsT1 => _typeFlags.HasTypeFlag(TypeFlags2.T1) ? UnsafeAsT1 : null;

    /// <summary>
    /// Gets the value wrapped in this instance typed as an instance of <typeparamref name="T2"/>, or
    /// <see langword="null"/> if this instance does not wrap a <typeparamref name="T2"/> value.
    /// </summary>
    public T2? AsT2 => _typeFlags.HasTypeFlag(TypeFlags2.T2) ? UnsafeAsT2 : null;

    /// <inheritdoc cref="IOrType2.TypeFlags"/>
    [NamedEnum] public TypeFlags2 TypeFlags => _typeFlags;
    [NamedEnum] internal readonly TypeFlags2 _typeFlags;

    [MaybeDefaultIfInstanceDefault] private T1 UnsafeAsT1 => Unsafe.As<T1>(_value);
    [MaybeDefaultIfInstanceDefault] private T2 UnsafeAsT2 => Unsafe.As<T2>(_value);

    /// <summary>
    /// Gets the value wrapped in this instance typed as an <see cref="object"/>.
    /// </summary>
    [MaybeDefaultIfInstanceDefault] public object AsObject => _value;

    [MaybeDefaultIfInstanceDefault] internal readonly object _value;
    #endregion

    #region Construction
    /// <summary>
    /// Creates a new <see cref="ClassOr{T1, T2}"/> instance wrapping the value passed in.
    /// </summary>
    /// <remarks>
    /// This method exists to prevent ambiguity between the <see cref="ClassOr{T1, T2}.ClassOr(T1)"/> and
    /// <see cref="ClassOr{T1, T2}.ClassOr(T2)"/> constructors when the type of the value passed in is a subtype of
    /// both <typeparamref name="T1"/> and <typeparamref name="T2"/>.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static ClassOr<T1, T2> FromChild<T>(T Value) where T : class, T1, T2
        => new(Throw.IfArgNull(Value, nameof(Value)), TypeFlags2.Both);

    /// <summary>
    /// Constructs a new instance of the <see cref="ClassOr{T1, T2}"/> struct wrapping the value passed in.
    /// </summary>
    /// <param name="Value"></param>
    public ClassOr(T1 Value)
    {
        _typeFlags = TypeFlags2.T1;
        if (Value is T2) _typeFlags |= TypeFlags2.T2;
        _value = Throw.IfArgNull(Value, nameof(Value));
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="ClassOr{T1, T2}"/> struct wrapping the value passed in.
    /// </summary>
    /// <param name="Value"></param>
    public ClassOr(T2 Value)
    {
        _typeFlags = TypeFlags2.T2;
        if (Value is T1) _typeFlags |= TypeFlags2.T1;
        _value = Throw.IfArgNull(Value, nameof(Value));
    }

    internal ClassOr(object Value, TypeFlags2 TypeFlags)
    {
        _value = Value;
        _typeFlags = TypeFlags;
    }
    #endregion

    #region Equality
    /// <inheritdoc cref="object.Equals(object)"/>
    public override bool Equals(object? o) => Equals(o, EqualityComparer<T1?>.Default, EqualityComparer<T2?>.Default);

    /// <summary>
    /// Determines if the current instance is equal to an object passed in, using the given
    /// <see cref="IEqualityComparer{T}"/> instances to determine equality.
    /// </summary>
    /// <param name="o"></param>
    /// <param name="t1Comparer"></param>
    /// <param name="t2Comparer"></param>
    /// <returns></returns>
    public bool Equals(object? o, IEqualityComparer<T1?> t1Comparer, IEqualityComparer<T2?> t2Comparer)
        => o switch
        {
            // Use the comparer corresponding to the type wrapped in this instance to determine equality
            // Allow the null reference to be passed to the equality comparers if o is null
            (T1 and T2) or null => _typeFlags switch
            {
                TypeFlags2.T1 => t1Comparer.Equals(UnsafeAsT1, Unsafe.As<T1>(o)),
                TypeFlags2.T2 => t2Comparer.Equals(UnsafeAsT2, Unsafe.As<T2>(o)),
                _ => ClassAnd.EqualsUnsafe(_value, o, t1Comparer, t2Comparer),
            },

            T1 t1 => Equals(t1, t1Comparer),
            T2 t2 => Equals(t2, t2Comparer),

            ClassOr<T1, T2> other => EqualsInternal(other, t1Comparer, t2Comparer),
            ClassOr<T2, T1> other => EqualsInternal(other, t1Comparer, t2Comparer),

            _ => false,
        };

    /// <inheritdoc cref="IStructuralEquatable.Equals(object, IEqualityComparer)"/>
    public bool Equals(object? o, IEqualityComparer comparer) => o switch
    {
        // Pass all class types to the comparer
        null or T1 or T2 => comparer.Equals(_value, o),

        // Pass the internal values of other instances of this type to the comparer
        ClassOr<T1, T2> other => comparer.Equals(_value, other._value),
        ClassOr<T2, T1> other => comparer.Equals(_value, other._value),

        _ => false,
    };

    public static bool operator !=(ClassOr<T1, T2> lhs, ClassOr<T1, T2> rhs) => !lhs.Equals(rhs);
    public static bool operator ==(ClassOr<T1, T2> lhs, ClassOr<T1, T2> rhs) => lhs.Equals(rhs);

    /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
    public bool Equals(ClassOr<T1, T2> other) => EqualsInternal(other);

    public static bool operator !=(ClassOr<T1, T2> lhs, ClassOr<T2, T1> rhs) => !lhs.Equals(rhs);
    public static bool operator ==(ClassOr<T1, T2> lhs, ClassOr<T2, T1> rhs) => lhs.Equals(rhs);

    /// <summary>
    /// Indicates whether the current instance is equal to another <see cref="ClassAnd{T1, T2}"/> with the generic
    /// type parameters reordered.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ClassOr<T2, T1> other) => EqualsInternal(other);

    public static bool operator !=(ClassOr<T1, T2> lhs, T1? rhs) => !lhs.Equals(rhs);
    public static bool operator ==(ClassOr<T1, T2> lhs, T1? rhs) => lhs.Equals(rhs);
    public static bool operator !=(T1? lhs, ClassOr<T1, T2> rhs) => !rhs.Equals(lhs);
    public static bool operator ==(T1? lhs, ClassOr<T1, T2> rhs) => rhs.Equals(lhs);

    /// <summary>
    /// Indicates whether the current instance is equal to a value of type <typeparamref name="T1"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Equals(T1? value) => Equals(value, EqualityComparer<T1?>.Default);

    /// <summary>
    /// Indicates whether the current instance is equal to a value of type <typeparamref name="T1"/>, using the
    /// specified <see cref="IEqualityComparer{T}"/> to determine equality.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public bool Equals(T1? value, IEqualityComparer<T1?> comparer)
        // Use the T1 comparer to determine equality if the value wrapped in this instance is also T1,
        // otherwise return false
        => IsT1OrDefault() && comparer.Equals(UnsafeAsT1, value);

    public static bool operator !=(ClassOr<T1, T2> lhs, T2? rhs) => !lhs.Equals(rhs);
    public static bool operator ==(ClassOr<T1, T2> lhs, T2? rhs) => lhs.Equals(rhs);
    public static bool operator !=(T2? lhs, ClassOr<T1, T2> rhs) => !rhs.Equals(lhs);
    public static bool operator ==(T2? lhs, ClassOr<T1, T2> rhs) => rhs.Equals(lhs);

    /// <summary>
    /// Indicates whether the current instance is equal to a value of type <typeparamref name="T2"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Equals(T2? value) => Equals(value, EqualityComparer<T2?>.Default);

    /// <summary>
    /// Indicates whether the current instance is equal to a value of type <typeparamref name="T2"/>, using the
    /// specified <see cref="IEqualityComparer{T}"/> to determine equality.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="comparer"></param>
    /// <returns></returns>
    public bool Equals(T2? value, IEqualityComparer<T2?> comparer)
        // Use the T2 comparer to determine equality if the value wrapped in this instance is also T2,
        // otherwise return false
        => IsT2OrDefault() && comparer.Equals(UnsafeAsT2, value);

    /// <summary>
    /// Indicates whether the current instance is equal to an instance of a subtype of <typeparamref name="T1"/>
    /// and <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="TChild"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Equals<TChild>(TChild? value) where TChild : class, T1, T2
        => Equals(value, EqualityComparer<T1?>.Default, EqualityComparer<T2?>.Default);

    /// <summary>
    /// Indicates whether the current instance is equal to an instance of a subtype of <typeparamref name="T1"/>
    /// and <typeparamref name="T2"/>, using the specified <see cref="IEqualityComparer{T}"/> instances to determine
    /// equality.
    /// </summary>
    /// <typeparam name="TChild"></typeparam>
    /// <param name="value"></param>
    /// <param name="t1Comparer"></param>
    /// <param name="t2Comparer"></param>
    /// <returns></returns>
    public bool Equals<TChild>(TChild? value, IEqualityComparer<T1?> t1Comparer, IEqualityComparer<T2?> t2Comparer)
        where TChild : class, T1, T2
        => _typeFlags switch
        {
            TypeFlags2.T1 => t1Comparer.Equals(UnsafeAsT1, value),
            TypeFlags2.T2 => t2Comparer.Equals(UnsafeAsT2, value),
            _ => ClassAnd.EqualsUnsafe(_value, value, t1Comparer, t2Comparer),
        };

    /// <inheritdoc cref="ValueType.GetHashCode"/>
    public override int GetHashCode() => IsDefault ? 0 : _value.GetHashCode();

    /// <inheritdoc cref="IStructuralEquatable.GetHashCode(IEqualityComparer)"/>
    public int GetHashCode(IEqualityComparer comparer) => comparer.GetHashCode(_value);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool EqualsInternal(ClassOr<T1, T2> other)
        => EqualsInternal(other, EqualityComparer<T1?>.Default, EqualityComparer<T2?>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool EqualsInternal(
        ClassOr<T1, T2> other, IEqualityComparer<T1?> t1Comparer, IEqualityComparer<T2?> t2Comparer)
        => this._typeFlags switch
        {
            TypeFlags2.T1 => other._typeFlags.HasTypeFlag(TypeFlags2.T1)
                                && t1Comparer.Equals(this.UnsafeAsT1, other.UnsafeAsT1),
            TypeFlags2.T2 => other._typeFlags.HasTypeFlag(TypeFlags2.T2)
                                && t2Comparer.Equals(this.UnsafeAsT2, other.UnsafeAsT2),
            _ => other._typeFlags switch
            {
                TypeFlags2.T1 => t1Comparer.Equals(this.UnsafeAsT1, other.UnsafeAsT1),
                TypeFlags2.T2 => t2Comparer.Equals(this.UnsafeAsT2, other.UnsafeAsT2),
                _ => ClassAnd.EqualsUnsafe(this._value, other._value, t1Comparer, t2Comparer),
            }
        };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool EqualsInternal(ClassOr<T2, T1> other)
        => EqualsInternal(other, EqualityComparer<T1?>.Default, EqualityComparer<T2?>.Default);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool EqualsInternal(
        ClassOr<T2, T1> other, IEqualityComparer<T1?> t1Comparer, IEqualityComparer<T2?> t2Comparer)
        => this._typeFlags switch
        {
            TypeFlags2.T1 => other._typeFlags.HasTypeFlag(TypeFlags2.T2)
                                && t1Comparer.Equals(this.UnsafeAsT1, other.UnsafeAsT2),
            TypeFlags2.T2 => other._typeFlags.HasTypeFlag(TypeFlags2.T1)
                                && t2Comparer.Equals(this.UnsafeAsT2, other.UnsafeAsT1),
            _ => other._typeFlags switch
            {
                TypeFlags2.T1 => t2Comparer.Equals(this.UnsafeAsT2, other.UnsafeAsT1),
                TypeFlags2.T2 => t1Comparer.Equals(this.UnsafeAsT1, other.UnsafeAsT2),
                _ => ClassAnd.EqualsUnsafe(this._value, other._value, t1Comparer, t2Comparer),
            }
        };
    #endregion

    #region Conversion
    /// <inheritdoc cref="IOrType{T1, T2}.CastToT1"/>
    [return: MaybeDefaultIfInstanceDefault]
    public T1 CastToT1()
        => IsT1OrDefault()
            ? UnsafeAsT1
            : throw new InvalidCastException(
                $"Expected instance of type {typeof(T1)}, but got {GetWrappedType()}.");

    /// <inheritdoc cref="IOrType{T1, T2}.CastToT2"/>
    [return: MaybeDefaultIfInstanceDefault]
    public T2 CastToT2()
        => IsT2OrDefault()
            ? UnsafeAsT2
            : throw new InvalidCastException(
                $"Expected instance of type {typeof(T2)}, but got {GetWrappedType()}.");

    public static implicit operator ClassOr<T2, T1>(ClassOr<T1, T2> value)
        => new(value._value, value._typeFlags.Switched());

    [return: NotDefault, MaybeDefaultIfParameterDefault("value")]
    public static implicit operator ClassOr<T1, T2>(T1? value) => value is null ? default : new(value);

    [return: NotDefault, MaybeDefaultIfParameterDefault("value")]
    public static implicit operator ClassOr<T1, T2>(T2? value) => value is null ? default : new(value);

    [return: MaybeDefaultIfParameterDefault("value")]
    public static explicit operator T1(ClassOr<T1, T2> value) => value.CastToT1();

    [return: MaybeDefaultIfParameterDefault("value")]
    public static explicit operator T2(ClassOr<T1, T2> value) => value.CastToT2();

    /// <summary>
    /// Creates a new <see cref="ClassOr{T1, T2}"/> from the value passed in without casting.
    /// </summary>
    /// <typeparam name="T1Child"></typeparam>
    /// <typeparam name="T2Child"></typeparam>
    /// <param name="child"></param>
    /// <returns></returns>
    [return: NotDefault, MaybeDefaultIfParameterDefault("child")]
    public static ClassOr<T1, T2> FromChildren<T1Child, T2Child>(ClassAnd<T1Child, T2Child> child)
        where T1Child : class, T1
        where T2Child : class, T2
        => child.IsDefault ? default : new(child._value, OrType2.DescribeType<T1, T2>(child._value));

    /// <summary>
    /// Performs an explicit cast of <typeparamref name="T1"/>, forming a new <see cref="ClassOr{T1, T2}"/> with
    /// <typeparamref name="T1Child"/> replacing <typeparamref name="T1"/>.
    /// </summary>
    /// <typeparam name="T1Child"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    [return: NotDefault, MaybeDefaultIfInstanceDefault]
    public ClassOr<T1Child, T2> CastT1ToChild<T1Child>() where T1Child : class, T1
    {
        if (IsDefault) return default;
        else if (this.IsOnlyT1()) return new((T1Child)_value);
        else return new(UnsafeAsT2);
    }

    /// <summary>
    /// Performs an explicit cast of <typeparamref name="T2"/>, forming a new <see cref="ClassOr{T1, T2}"/> with
    /// <typeparamref name="T2Child"/> replacing <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="T2Child"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    [return: NotDefault, MaybeDefaultIfInstanceDefault]
    public ClassOr<T1, T2Child> CastT2ToChild<T2Child>() where T2Child : class, T2
    {
        if (IsDefault) return default;
        else if (this.IsOnlyT2()) return new((T2Child)_value);
        else return new(UnsafeAsT1);
    }

    /// <summary>
    /// Performs an explicit cast of both <typeparamref name="T1"/> and <typeparamref name="T2"/>, forming a new
    /// <see cref="ClassOr{T1, T2}"/> with <typeparamref name="T1Child"/> replacing <typeparamref name="T1"/> and
    /// <typeparamref name="T2Child"/> replacing <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="T1Child"></typeparam>
    /// <typeparam name="T2Child"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    [return: NotDefault, MaybeDefaultIfInstanceDefault]
    public ClassOr<T1Child, T2Child> CastToChildren<T1Child, T2Child>()
        where T1Child : class, T1
        where T2Child : class, T2
        => _value switch
        {
            null => default,
            T1Child t1C => new(t1C),
            T2Child t2C => new(t2C),
            _ => throw new InvalidCastException(
                $"Cannot cast value of type '{_value.GetType()}' "
                    + $"to either '{typeof(T1Child)}' or '{typeof(T2Child)}'."),
        };

    /// <summary>
    /// Performs an explicit cast to a type extending both <typeparamref name="T1"/> and <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="TChild"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    [return: MaybeDefaultIfInstanceDefault]
    public TChild CastToChild<TChild>() where TChild : class, T1, T2 => (TChild)_value;
    #endregion

    #region Other Methods
    /// <inheritdoc cref="IOrType2.GetWrappedType"/>
    /// <remarks>
    /// This method will throw a <see cref="NullReferenceException"/> if called on the default instance.
    /// </remarks>
    [DoesNotReturnIfInstanceDefault]
    public Type GetWrappedType() => _value.GetType();

    /// <summary>
    /// Gets the type of the value wrapped in this instance, or <see langword="null"/> if this instance is the default.
    /// </summary>
    /// <returns></returns>
    public Type? GetWrappedTypeOrNull() => _value?.GetType();

    /// <summary>
    /// Determines whether the current instance wraps a value of type <typeparamref name="T1"/> or is the default
    /// (in which case it wraps <see langword="null"/>).
    /// </summary>
    /// <returns></returns>
    public bool IsT1OrDefault() => IsDefault || this.IsT1();

    /// <summary>
    /// Determines whether the current instance wraps a value of type <typeparamref name="T2"/> or is the default
    /// (in which case it wraps <see langword="null"/>).
    /// </summary>
    /// <returns></returns>
    public bool IsT2OrDefault() => IsDefault || this.IsT2();

    /// <inheritdoc cref="object.ToString"/>
    public override string ToString() => _value is null ? "null" : _value.ToString();
    #endregion
}

