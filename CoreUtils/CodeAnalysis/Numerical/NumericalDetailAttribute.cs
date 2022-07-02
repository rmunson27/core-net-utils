using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.CodeAnalysis.Numerical;

/// <summary>
/// The base class for all attributes provided by this library that indicate details about numerical values.
/// </summary>
public abstract class NumericalDetailAttribute : Attribute
{
    private protected NumericalDetailAttribute() { }
}
