using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rem.CoreUtils.ComponentModel;

/// <summary>
/// An interface for structure types that can determine if they are the default value.
/// </summary>
public interface IDefaultDeterminableStruct
{
    /// <summary>
    /// Gets whether or not this struct value is default (not initialized).
    /// </summary>
    public bool IsDefault { get; }

    /// <summary>
    /// Gets whether or not this struct value is initialized (not default).
    /// </summary>
    public bool IsNotDefault { get; }
}
