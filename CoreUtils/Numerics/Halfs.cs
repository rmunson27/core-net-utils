#if NET5_0_OR_GREATER

using Rem.CoreUtils.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.Numerics;

/// <summary>
/// Extension methods and static functionality for working with <see cref="Half"/> values.
/// </summary>
public static class Halfs
{
    /// <summary>
    /// Determines if the current <see cref="Half"/> value is finite (not infinity or NaN).
    /// </summary>
    /// <param name="h"></param>
    /// <returns></returns>
    public static bool IsFinite(this Half h) => !h.IsNotFinite();

    /// <summary>
    /// Determines if the current <see cref="Half"/> value is not finite (infinity or NaN).
    /// </summary>
    /// <param name="h"></param>
    /// <returns></returns>
    public static bool IsNotFinite(this Half h) => Half.IsInfinity(h) || Half.IsNaN(h);

    /// <summary>
    /// Gets an object describing the type of the current <see cref="Half"/> value.
    /// </summary>
    /// <param name="h"></param>
    /// <returns></returns>
    [return: NamedEnum] public static FloatValueType FloatType(this Half h)
    {
        if (Half.IsNaN(h)) return FloatValueType.NotANumber;
        if (Half.IsPositiveInfinity(h)) return FloatValueType.PositiveInfinity;
        if (Half.IsNegativeInfinity(h)) return FloatValueType.NegativeInfinity;

        return Sign(h) switch
        {
            < 0 => FloatValueType.NegativeFinite,
            0 => FloatValueType.Zero,
            > 0 => FloatValueType.PositiveFinite,
        };
    }

    /// <summary>
    /// Returns an integer that indicates the sign of a half-precision floating point value. 
    /// </summary>
    /// <seealso cref="Math.Sign(float)"/>
    /// <param name="value"></param>
    /// <returns></returns>
    /// <exception cref="ArithmeticException">
    /// <paramref name="value"/> was equal to <see cref="Half.NaN"/>.
    /// </exception>
    public static int Sign(Half value)
    {
        if (Half.IsNaN(value)) throw new ArithmeticException(
            "Function does not accept floating point Not-A-Number values.");

        return Math.Sign((float)value) switch
        {
            < 0 => -1,
            0 => 0,
            > 0 => 1,
        };
    }
}

#endif
