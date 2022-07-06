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
}
