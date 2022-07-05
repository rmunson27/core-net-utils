using Rem.CoreUtils.CodeAnalysis;
using Rem.CoreUtils.ComponentModel;
using Rem.CoreUtils.Helpers.Throw;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rem.CoreUtils;

/// <summary>
/// Static functionality relating to instances that represent a logical AND of two or more reference types.
/// </summary>
public static class ClassAnd
{
    #region Exceptions
    internal static InvalidCastException BadCastTo<TTarget>(this Type TSource)
        => new($"Cannot cast object of type {TSource} to type {typeof(TTarget)}.");

    internal static InvalidCastException BadCastTo<TTarget1, TTarget2>(this Type TSource)
        => new($"Expected instance of both {typeof(TTarget1)} and {typeof(TTarget2)}, but got instance of {TSource}.");
    #endregion

    #region Equality
    /// <summary>
    /// Determines equality of the two instances of <typeparamref name="T1"/> and <typeparamref name="T2"/>,
    /// returning <see langword="true"/> if either default equality comparer indicates equality.
    /// </summary>
    /// <remarks>
    /// This method uses unsafe casting operations and should only be used internally.
    /// </remarks>
    /// <param name="o1"></param>
    /// <param name="o2"></param>
    /// <param name="t1Comparer"></param>
    /// <param name="t2Comparer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool EqualsUnsafe<T1, T2>(object? o1, object? o2)
        where T1 : class
        where T2 : class
        => EqualsUnsafe(o1, o2, EqualityComparer<T1?>.Default, EqualityComparer<T2?>.Default);

    /// <summary>
    /// Determines equality of the two instances of <typeparamref name="T1"/> and <typeparamref name="T2"/>,
    /// returning <see langword="true"/> if either equality comparer passed in indicates equality.
    /// </summary>
    /// <remarks>
    /// This method uses unsafe casting operations and should only be used internally.
    /// </remarks>
    /// <param name="o1"></param>
    /// <param name="o2"></param>
    /// <param name="t1Comparer"></param>
    /// <param name="t2Comparer"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool EqualsUnsafe<T1, T2>(
        object? o1, object? o2, IEqualityComparer<T1?> t1Comparer, IEqualityComparer<T2?> t2Comparer)
        where T1 : class
        where T2 : class
        => t1Comparer.Equals(Unsafe.As<T1>(o1), Unsafe.As<T1>(o2))
            || t2Comparer.Equals(Unsafe.As<T2>(o1), Unsafe.As<T2>(o2));
    #endregion

    #region Casting
    /// <summary>
    /// A class containing casting methods for the first type in a class AND.
    /// </summary>
    /// <remarks>
    /// This class allows the generic arguments for its casting methods to be inferred by the compiler based on the
    /// method arguments.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public static class T1<T> where T : class
    {
        /// <summary>
        /// Creates a new <see cref="ClassAnd{T1, T2}"/> from the value passed in without casting.
        /// </summary>
        /// <typeparam name="TChild"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="child"></param>
        /// <returns></returns>
        [return: NotDefault, MaybeDefaultIfParameterDefault("child")]
        public static ClassAnd<T, T2> FromChild<TChild, T2>(ClassAnd<TChild, T2> child)
            where TChild : class, T
            where T2 : class
            => new(child._value);
    }

    /// <summary>
    /// A class containing casting methods for the second type in a class AND.
    /// </summary>
    /// <remarks>
    /// This class allows the generic arguments for its casting methods to be inferred by the compiler based on the
    /// method arguments.
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public static class T2<T> where T : class
    {
        /// <summary>
        /// Creates a new <see cref="ClassAnd{T1, T2}"/> from the value passed in without casting.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="child"></param>
        /// <returns></returns>
        [return: NotDefault, MaybeDefaultIfParameterDefault("child")]
        public static ClassAnd<T1, T> FromChild<T1, TChild>(ClassAnd<T1, TChild> child)
            where T1 : class
            where TChild : class, T
            => new(child._value);
    }
    #endregion
}

/// <summary>
/// Represents a logical AND of two reference types.
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
public readonly struct ClassAnd<T1, T2>
    : IAndType<T1, T2>, IDefaultDeterminableStruct, IEquatable<ClassAnd<T1, T2>>, IStructuralEquatable
    where T1 : class
    where T2 : class
{
    #region Properties
    /// <inheritdoc cref="IDefaultDeterminableStruct.IsDefault"/>
    public bool IsDefault => _value is null;

    /// <inheritdoc cref="IDefaultDeterminableStruct.IsNotDefault"/>
    public bool IsNotDefault => _value is not null;

    /// <inheritdoc cref="IAndType{T1, T2}.AsT1"/>
    [MaybeDefaultIfInstanceDefault] public T1 AsT1 => Unsafe.As<T1>(_value);

    /// <inheritdoc cref="IAndType{T1, T2}.AsT2"/>
    [MaybeDefaultIfInstanceDefault] public T2 AsT2 => Unsafe.As<T2>(_value);

    /// <summary>
    /// Gets the value wrapped in this instance typed as an <see cref="object"/>.
    /// </summary>
    [MaybeDefaultIfInstanceDefault] public object AsObject => _value;

    [MaybeDefaultIfInstanceDefault] internal readonly object _value;
    #endregion

    #region Construction
    /// <summary>
    /// Creates a new <see cref="ClassAnd{T1, T2}"/> instance from the value passed in.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Value"></param>
    /// <returns></returns>
    [return: NotDefault]
    public static ClassAnd<T1, T2> Make<T>(T Value) where T : T1, T2
        => new(Throw.IfArgNull(Value, nameof(Value)));

    internal ClassAnd(object Value) { _value = Value; }
    #endregion

    #region Equality
    /// <inheritdoc cref="object.Equals(object)"/>
    public override bool Equals(object? o) => o switch
    {
        null => IsDefault,
        T1 and T2 => ClassAnd.EqualsUnsafe<T1, T2>(_value, o),
        ClassAnd<T1, T2> other => Equals(other),
        ClassAnd<T2, T1> other => Equals(other),
        _ => false,
    };

    /// <inheritdoc cref="IStructuralEquatable.Equals(object, IEqualityComparer)"/>
    public bool Equals(object o, IEqualityComparer comparer) => o switch
    {
        null => IsDefault,
        T1 and T2 => comparer.Equals(_value, o),
        ClassAnd<T1, T2> other => comparer.Equals(this._value, other._value),
        ClassAnd<T2, T1> other => comparer.Equals(this._value, other._value),
        _ => false,
    };

    public static bool operator !=(ClassAnd<T1, T2> lhs, ClassAnd<T1, T2> rhs) => !lhs.Equals(rhs);
    public static bool operator ==(ClassAnd<T1, T2> lhs, ClassAnd<T1, T2> rhs) => lhs.Equals(rhs);

    /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
    public bool Equals(ClassAnd<T1, T2> other) => ClassAnd.EqualsUnsafe<T1, T2>(_value, other._value);

    public static bool operator !=(ClassAnd<T1, T2> lhs, ClassAnd<T2, T1> rhs) => !lhs.Equals(rhs);
    public static bool operator ==(ClassAnd<T1, T2> lhs, ClassAnd<T2, T1> rhs) => lhs.Equals(rhs);

    /// <summary>
    /// Indicates whether the current instance is equal to another <see cref="ClassAnd{T1, T2}"/> with the generic
    /// type parameters reordered.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(ClassAnd<T2, T1> other) => ClassAnd.EqualsUnsafe<T1, T2>(_value, other._value);

    public static bool operator !=(ClassAnd<T1, T2> lhs, T1? rhs) => !lhs.Equals(rhs);
    public static bool operator ==(ClassAnd<T1, T2> lhs, T1? rhs) => lhs.Equals(rhs);
    public static bool operator !=(T1? lhs, ClassAnd<T1, T2> rhs) => !rhs.Equals(lhs);
    public static bool operator ==(T1? lhs, ClassAnd<T1, T2> rhs) => rhs.Equals(lhs);

    /// <summary>
    /// Indicates whether the current instance is equal to an instance of type <typeparamref name="T1"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Equals(T1? value) => EqualityComparer<T1?>.Default.Equals(AsT1, value);

    public static bool operator !=(ClassAnd<T1, T2> lhs, T2? rhs) => !lhs.Equals(rhs);
    public static bool operator ==(ClassAnd<T1, T2> lhs, T2? rhs) => lhs.Equals(rhs);
    public static bool operator !=(T2? lhs, ClassAnd<T1, T2> rhs) => !rhs.Equals(lhs);
    public static bool operator ==(T2? lhs, ClassAnd<T1, T2> rhs) => rhs.Equals(lhs);

    /// <summary>
    /// Indicates whether the current instance is equal to an instance of type <typeparamref name="T2"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Equals(T2? value) => EqualityComparer<T2?>.Default.Equals(AsT2, value);

    /// <summary>
    /// Indicates whether the current instance is equal to an instance of a subtype of both <typeparamref name="T1"/>
    /// and <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="TChild"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool Equals<TChild>(TChild? value) where TChild : class, T1, T2
        => ClassAnd.EqualsUnsafe<T1, T2>(_value, value);

    /// <inheritdoc cref="ValueType.GetHashCode"/>
    public override int GetHashCode() => IsDefault ? 0 : _value.GetHashCode();

    /// <inheritdoc cref="IStructuralEquatable.GetHashCode(IEqualityComparer)"/>
    public int GetHashCode(IEqualityComparer comparer) => comparer.GetHashCode(_value);
    #endregion

    #region Conversions
    [return: MaybeDefaultIfParameterDefault("value")]
    public static implicit operator T1(ClassAnd<T1, T2> value) => value.AsT1;

    [return: MaybeDefaultIfParameterDefault("value")]
    public static implicit operator T2(ClassAnd<T1, T2> value) => value.AsT2;

    [return: MaybeDefaultIfParameterDefault("value")]
    public static implicit operator ClassAnd<T2, T1>(ClassAnd<T1, T2> value) => new(value._value);

    [return: NotDefault, MaybeDefaultIfParameterDefault("value")]
    public static explicit operator ClassAnd<T1, T2>(T1? value) => value switch
    {
        T2 => new(value),
        null => default,
        _ => throw value.GetType().BadCastTo<T2>(),
    };

    [return: NotDefault, MaybeDefaultIfParameterDefault("value")]
    public static explicit operator ClassAnd<T1, T2>(T2? value) => value switch
    {
        T1 => new(value),
        null => default,
        _ => throw value.GetType().BadCastTo<T1>(),
    };

    /// <summary>
    /// Creates a new <see cref="ClassAnd{T1, T2}"/> from the value passed in without casting.
    /// </summary>
    /// <typeparam name="T1Child"></typeparam>
    /// <typeparam name="T2Child"></typeparam>
    /// <param name="child"></param>
    /// <returns></returns>
    [return: NotDefault, MaybeDefaultIfParameterDefault("child")]
    public static ClassAnd<T1, T2> FromChild<T1Child, T2Child>(ClassAnd<T1Child, T2Child> child)
        where T1Child : class, T1
        where T2Child : class, T2
        => new(child._value);

    /// <summary>
    /// Performs an explicit cast of <typeparamref name="T1"/>, forming a new <see cref="ClassAnd{T1, T2}"/> with
    /// <typeparamref name="TChild1"/> replacing <typeparamref name="T1"/>.
    /// </summary>
    /// <typeparam name="TChild1"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    [return: NotDefault, MaybeDefaultIfInstanceDefault]
    public ClassAnd<TChild1, T2> ExplicitCast1<TChild1>() where TChild1 : class, T1 => new((TChild1)_value);

    /// <summary>
    /// Performs an explicit cast of <typeparamref name="T2"/>, forming a new <see cref="ClassAnd{T1, T2}"/> with
    /// <typeparamref name="TChild2"/> replacing <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="TChild2"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    [return: NotDefault, MaybeDefaultIfInstanceDefault]
    public ClassAnd<T1, TChild2> ExplicitCast2<TChild2>() where TChild2 : class, T2 => new((TChild2)_value);

    /// <summary>
    /// Performs an explicit cast of both <typeparamref name="T1"/> and <typeparamref name="T2"/>, forming a new
    /// <see cref="ClassAnd{T1, T2}"/> with <typeparamref name="TChild1"/> replacing <typeparamref name="T1"/> and
    /// <typeparamref name="TChild2"/> replacing <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="TChild1"></typeparam>
    /// <typeparam name="TChild2"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    [return: NotDefault, MaybeDefaultIfInstanceDefault]
    public ClassAnd<TChild1, TChild2> ExplicitCast<TChild1, TChild2>()
        where TChild1 : class, T1
        where TChild2 : class, T2
    {
        if (IsDefault) return default;

        if (_value is TChild1 and TChild2) return new(_value);
        else throw GetWrappedType().BadCastTo<TChild1, TChild2>();
    }

    /// <summary>
    /// Performs an explicit cast to a type extending both <typeparamref name="T1"/> and <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="TChild"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    [return: MaybeDefaultIfInstanceDefault]
    public TChild ExplicitCast<TChild>() where TChild : class, T1, T2 => (TChild)_value;
    #endregion

    #region Other Methods
    /// <inheritdoc cref="IAndType{T1, T2}.GetWrappedType"/>
    [DoesNotReturnIfInstanceDefault]
    public Type GetWrappedType() => _value.GetType();

    /// <summary>
    /// Gets the type of the value wrapped in this instance, or <see langword="null"/> if this instance is the default.
    /// </summary>
    /// <returns></returns>
    public Type? GetWrappedTypeOrNull() => _value?.GetType();

    /// <summary>
    /// Returns a string that represents the value wrapped in this instance.
    /// </summary>
    /// <returns>A string that represents the value wrapped in this instance.</returns>
    public override string ToString() => _value is null ? "null" : _value.ToString();
    #endregion
}

