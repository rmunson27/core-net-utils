using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Text;

namespace Rem.CoreUtils.Numerics;

using static FloatValueCategory;

/// <summary>
/// Extensions and static functionality for the <see cref="FloatValueCategory"/> enum.
/// </summary>
/// <remarks>
/// This class contains extension methods for the <see cref="FloatValueCategory"/> enum, as well as some useful
/// compound <see cref="FloatValueCategory"/> constants not named explicitly in the <see cref="FloatValueCategory"/>
/// enum definition.
/// </remarks>
public static class FloatCategories
{
    #region Constants
    /// <summary>
    /// Indicates that a value is a non-zero numeric value.
    /// </summary>
    public const FloatValueCategory NonZeroNumeric = NonZero & Numeric;

    /// <summary>
    /// Indicates that a value is a non-zero finite value.
    /// </summary>
    public const FloatValueCategory NonZeroFinite = NonZero & Finite;

    /// <summary>
    /// Indicates that a value is a non-negative numeric value.
    /// </summary>
    public const FloatValueCategory NonNegativeNumeric = NonNegative & Numeric;

    /// <summary>
    /// Indicates that a value is a non-negative finite value.
    /// </summary>
    public const FloatValueCategory NonNegativeFinite = NonNegative & Finite;

    /// <summary>
    /// Indicates that a value is a non-positive numeric value.
    /// </summary>
    public const FloatValueCategory NonPositiveNumeric = NonPositive & Numeric;

    /// <summary>
    /// Indicates that a value is a non-positive finite value.
    /// </summary>
    public const FloatValueCategory NonPositiveFinite = NonPositive & Finite;
    #endregion

    #region Fields
    private static readonly IEnumerable<FloatValueType> AllValueTypes
        = (FloatValueType[])Enum.GetValues(typeof(FloatValueType));
    #endregion

    #region Methods
    /// <summary>
    /// Determines whether the current <see cref="FloatValueCategory"/> is a subset of the other
    /// <see cref="FloatValueCategory"/> passed in.
    /// </summary>
    /// <remarks>
    /// This method returns <see langword="true"/> if the current instance is equal to <paramref name="other"/>.
    /// </remarks>
    /// <param name="c"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static bool IsSubsetOf(this FloatValueCategory c, FloatValueCategory other) => other.IsSupersetOf(c);

    /// <summary>
    /// Gets all <see cref="FloatValueType"/> values contained in the current <see cref="FloatValueCategory"/>.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static ImmutableHashSet<FloatValueType> GetContainedTypes(this FloatValueCategory c)
    {
        var builder = ImmutableHashSet.CreateBuilder<FloatValueType>();
        foreach (var type in AllValueTypes) if (c.ContainsType(type)) { builder.Add(type); }
        return builder.ToImmutable();
    }

    /// <summary>
    /// Determines whether the current <see cref="FloatValueCategory"/> contains the <see cref="FloatValueType"/>
    /// passed in.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool ContainsType(this FloatValueCategory c, FloatValueType type) => c.IsSupersetOf((FloatValueCategory)type);

    /// <summary>
    /// Determines whether the current <see cref="FloatValueCategory"/> is a superset of the other
    /// <see cref="FloatValueCategory"/> passed in.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    /// This method returns <see langword="true"/> if the current instance is equal to <paramref name="other"/>.
    /// </para>
    /// 
    /// <para>
    /// This method implements a more efficient version of <see cref="Enum.HasFlag(Enum)"/>, and can be used in place
    /// of the latter both for performance and semantic reasons.
    /// </para>
    /// </remarks>
    /// 
    /// <param name="c"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static bool IsSupersetOf(this FloatValueCategory c, FloatValueCategory other) => (c & other) == other;
    #endregion
}

/// <summary>
/// Describes categories of float values.
/// </summary>
/// <remarks>
/// Values of this type can be treated as sets of <see cref="FloatValueType"/> values.
/// </remarks>
[Flags]
public enum FloatValueCategory : byte
{
    #region Atomic Flags
    /// <inheritdoc cref="FloatValueType.Zero"/>
    Zero = FloatValueType.Zero,

    /// <inheritdoc cref="FloatValueType.PositiveFinite"/>
    PositiveFinite = FloatValueType.PositiveFinite,

    /// <inheritdoc cref="FloatValueType.PositiveInfinity"/>
    PositiveInfinity = FloatValueType.PositiveInfinity,

    /// <inheritdoc cref="FloatValueType.NegativeFinite"/>
    NegativeFinite = FloatValueType.NegativeFinite,

    /// <inheritdoc cref="FloatValueType.NegativeInfinity"/>
    NegativeInfinity = FloatValueType.NegativeInfinity,

    /// <inheritdoc cref="FloatValueType.NotANumber"/>
    NotANumber = FloatValueType.NotANumber,
    #endregion

    #region Basic
    /// <summary>
    /// Indicates that a value could be any possible float value of its type.
    /// </summary>
    Any = NegativeInfinity | NegativeFinite | Zero | PositiveFinite | PositiveInfinity | NotANumber,

    /// <summary>
    /// Indicates that a value is positive.
    /// </summary>
    Positive = PositiveFinite | PositiveInfinity,

    /// <summary>
    /// Indicates that a value is negative.
    /// </summary>
    Negative = NegativeFinite | NegativeInfinity,

    /// <summary>
    /// Indicates that a value is a number (i.e. is not a not-a-number value).
    /// </summary>
    Numeric = (~NotANumber) & Any,

    /// <summary>
    /// Indicates that a value is finite.
    /// </summary>
    Finite = NegativeFinite | Zero | PositiveFinite,

    /// <summary>
    /// Indicates that a value is infinity.
    /// </summary>
    Infinity = PositiveInfinity | NegativeInfinity,
    #endregion

    #region Negation
    /// <summary>
    /// Indicates that a value is not finite.
    /// </summary>
    NonFinite = (~Finite) & Any,

    /// <summary>
    /// Indicates that a value is non-zero.
    /// </summary>
    NonZero = (~Zero) & Any,

    /// <summary>
    /// Indicates that a value is non-negative.
    /// </summary>
    NonNegative = (~Negative) & Any,

    /// <summary>
    /// Indicates that a value is non-positive.
    /// </summary>
    NonPositive = (~Positive) & Any,
    #endregion
}

/// <summary>
/// Extension methods and static functionality for the <see cref="FloatValueType"/> enum.
/// </summary>
public static class FloatValueTypes
{
    /// <summary>
    /// Determines if the current <see cref="FloatValueType"/> is contained as an element of the
    /// <see cref="FloatValueCategory"/> passed in.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="category"></param>
    /// <returns></returns>
    public static bool IsElementOf(this FloatValueType t, FloatValueCategory category) => category.ContainsType(t);

    /// <summary>
    /// Gets a <see cref="FloatValueCategory"/> that exactly describes the current
    /// <see cref="FloatValueType"/> instance.
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    /// <exception cref="InvalidEnumArgumentException">
    /// The current instance was not a named, defined value of type <see cref="FloatValueType"/>.
    /// </exception>
    public static FloatValueCategory ToCategory(this FloatValueType t)
        => (FloatValueCategory)Throw.IfEnumArgUnnamed(t, nameof(t));
}

/// <summary>
/// Describes the type of a float value.
/// </summary>
/// <remarks>
/// This is essentially an extension of the concept of sign for floating point types.
/// </remarks>
public enum FloatValueType : byte
{
    /// <summary>
    /// Indicates that a value is zero.
    /// </summary>
    Zero = 1,

    /// <summary>
    /// Indicates that a value is a positive finite value.
    /// </summary>
    PositiveFinite = 2,

    /// <summary>
    /// Indicates that a value is positive infinity.
    /// </summary>
    PositiveInfinity = 4,

    /// <summary>
    /// Indicates that a value is a negative finite value.
    /// </summary>
    NegativeFinite = 8,

    /// <summary>
    /// Indicates that a value is negative infinity.
    /// </summary>
    NegativeInfinity = 16,

    /// <summary>
    /// Indicates that a value is a not-a-number (NaN) value.
    /// </summary>
    NotANumber = 32,
}
