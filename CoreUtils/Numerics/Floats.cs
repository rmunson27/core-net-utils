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
}
