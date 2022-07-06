using Rem.CoreUtils.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.Numerics;

/// <summary>
/// Extension methods and static functionality for working with <see cref="float"/> values.
/// </summary>
public static class Floats
{
    /// <summary>
    /// Determines if the current <see cref="float"/> value is finite (not infinity or NaN).
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    public static bool IsFinite(this float f) => !f.IsNotFinite();

    /// <summary>
    /// Determines if the current <see cref="float"/> value is not finite (infinity or NaN).
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    public static bool IsNotFinite(this float f) => float.IsInfinity(f) || float.IsNaN(f);

    /// <summary>
    /// Gets an object describing the type of the current <see cref="float"/> value.
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    [return: NamedEnum] public static FloatValueType FloatType(this float f)
    {
        if (float.IsNaN(f)) return FloatValueType.NotANumber;
        if (float.IsPositiveInfinity(f)) return FloatValueType.PositiveInfinity;
        if (float.IsNegativeInfinity(f)) return FloatValueType.NegativeInfinity;

        return Math.Sign(f) switch
        {
            < 0 => FloatValueType.NegativeFinite,
            0 => FloatValueType.Zero,
            > 0 => FloatValueType.PositiveFinite,
        };
    }
}
