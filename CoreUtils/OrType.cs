using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils;

/// <summary>
/// Static functionality relating to instances that represent a logical OR of two types.
/// </summary>
public static class OrType2
{
    /// <summary>
    /// A series of type flags indicating the type of a value wrapped in a logical OR of two types.
    /// </summary>
    [Flags]
    public enum TypeFlags : byte
    {
        /// <summary>
        /// An empty set of type flags.
        /// </summary>
        /// <remarks>
        /// This case can be used to represent a <see langword="null"/> case in logical OR types where the components
        /// are nullable reference types.
        /// </remarks>
        None = 0,

        /// <summary>
        /// Indicates that the value wrapped in a logical OR instance is an instance of the first type.
        /// </summary>
        T1 = 1,

        /// <summary>
        /// Indicates that the value wrapped in a logical OR instance is an instance of the second type.
        /// </summary>
        T2 = 2,

        /// <summary>
        /// Indicates that the value wrapped in a logical OR instance is an instance of both types.
        /// </summary>
        Both = T1 | T2,
    }

    /// <summary>
    /// Gets whether or not the value wrapped in the current instance is a value of the first type in the logical OR.
    /// </summary>
    /// <typeparam name="TOr"></typeparam>
    public static bool IsT1<TOr>(this TOr orValue)
        where TOr : IOrType2
        => orValue.TypeFlags.HasTypeFlag(TypeFlags.T1);

    /// <summary>
    /// Gets whether or not the value wrapped in the current instance is a value of the first type in the logical OR
    /// and not the second.
    /// </summary>
    /// <typeparam name="TOr"></typeparam>
    public static bool IsOnlyT1<TOr>(this TOr orValue)
        where TOr : IOrType2
        => orValue.TypeFlags == TypeFlags.T1;

    /// <summary>
    /// Gets whether or not the value wrapped in the current instance is a value of the second type in the logical OR.
    /// </summary>
    /// <typeparam name="TOr"></typeparam>
    public static bool IsT2<TOr>(this TOr orValue)
        where TOr : IOrType2
        => orValue.TypeFlags.HasTypeFlag(TypeFlags.T2);

    /// <summary>
    /// Gets whether or not the value wrapped in the current instance is a value of the second type in the logical OR
    /// and not the first.
    /// </summary>
    /// <typeparam name="TOr"></typeparam>
    public static bool IsOnlyT2<TOr>(this TOr orValue)
        where TOr : IOrType2
        => orValue.TypeFlags == TypeFlags.T2;

    /// <summary>
    /// Gets whether or not the value wrapped in the current instance is a value of both types in the logical OR.
    /// </summary>
    /// <typeparam name="TOr"></typeparam>
    /// <param name="orValue"></param>
    /// <returns></returns>
    public static bool IsBothTypes<TOr>(this TOr orValue) where TOr : IOrType2 => orValue.TypeFlags == TypeFlags.Both;

    /// <summary>
    /// Determines whether or not the current instance has the type flag passed in set.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="flag"></param>
    /// <returns></returns>
    public static bool HasTypeFlag(this TypeFlags value, TypeFlags flag) => (value & flag) == flag;

    /// <summary>
    /// Gets the <see cref="TypeFlags"/> instance equal to the current instance with the set flags switched if a
    /// single flag is set, returning all other values as-is.
    /// </summary>
    /// <remarks>
    /// This method will return unnamed enum values as-is.
    /// </remarks>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TypeFlags Switched(this TypeFlags value) => value switch
    {
        TypeFlags.T1 => TypeFlags.T2,
        TypeFlags.T2 => TypeFlags.T1,
        _ => value,
    };

    /// <summary>
    /// Describes the type of the object passed in with respect to <typeparamref name="T1"/>
    /// and <typeparamref name="T2"/>.
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TypeFlags DescribeType<T1, T2>(object? value) => value switch
    {
        T1 => value is T2 ? TypeFlags.T1 | TypeFlags.T2 : TypeFlags.T1,

        // Can't be T1, since that would have been caught by the first case
        T2 => TypeFlags.T2,

        _ => TypeFlags.None,
    };
}

/// <summary>
/// A generic interface for types that act as a logical OR of two types.
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
public interface IOrType<out T1, out T2> : IOrType2
{
    /// <summary>
    /// Casts the value wrapped in this instance to an instance of <typeparamref name="T1"/>.
    /// </summary>
    /// <returns>The result of the cast.</returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    public T1 CastToT1();

    /// <summary>
    /// Casts the value wrapped in this instance to an instance of <typeparamref name="T2"/>.
    /// </summary>
    /// <returns>The result of the cast.</returns>
    /// <exception cref="InvalidCastException">The cast was invalid.</exception>
    public T2 CastToT2();
}

/// <summary>
/// A non-generic interface for types that act as a logical OR of two types.
/// </summary>
/// <remarks>
/// This interface exists primarily to make extension methods saner, and should not be implemented directly.
/// Instead, implement the <see cref="IOrType{T1, T2}"/> generic interface.
/// </remarks>
public interface IOrType2
{
    /// <summary>
    /// Gets type flags describing the type of the value wrapped in this instance.
    /// </summary>
    public OrType2.TypeFlags TypeFlags { get; }

    /// <summary>
    /// Gets the type of the value wrapped in this instance.
    /// </summary>
    /// <returns></returns>
    public Type GetWrappedType();
}
