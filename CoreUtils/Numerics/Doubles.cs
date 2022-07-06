using Rem.CoreUtils.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.Numerics;

/// <summary>
/// Extension methods and static functionality for working with <see cref="double"/> values.
/// </summary>
public static class Doubles
{
    /// <summary>
    /// Determines if the current <see cref="double"/> value is finite (not infinity or NaN).
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static bool IsFinite(this double d) => !d.IsNotFinite();

    /// <summary>
    /// Determines if the current <see cref="double"/> value is not finite (infinity or NaN).
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static bool IsNotFinite(this double d) => double.IsInfinity(d) || double.IsNaN(d);

    /// <summary>
    /// Gets an object describing the type of the current <see cref="double"/> value.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    [return: NamedEnum] public static FloatValueType FloatType(this double d)
    {
        if (double.IsNaN(d)) return FloatValueType.NotANumber;
        if (double.IsPositiveInfinity(d)) return FloatValueType.PositiveInfinity;
        if (double.IsNegativeInfinity(d)) return FloatValueType.NegativeInfinity;

        return Math.Sign(d) switch
        {
            < 0 => FloatValueType.NegativeFinite,
            0 => FloatValueType.Zero,
            > 0 => FloatValueType.PositiveFinite,
        };
    }
}
