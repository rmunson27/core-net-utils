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
    /// Determines if the <see cref="float"/> value passed in is finite (not infinity or NaN).
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    public static bool IsFinite(float f) => !IsNotFinite(f);

    /// <summary>
    /// Determines if the <see cref="float"/> value passed in is not finite (infinity or NaN).
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    public static bool IsNotFinite(float f) => float.IsInfinity(f) || float.IsNaN(f);
}
