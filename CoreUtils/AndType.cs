using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils;

/// <summary>
/// An interface for types that act as a logical AND of two types.
/// </summary>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
public interface IAndType<out T1, out T2>
{
    /// <summary>
    /// Gets the value wrapped in this instance typed as an instance of <typeparamref name="T1"/>.
    /// </summary>
    public T1 AsT1 { get; }

    /// <summary>
    /// Gets the value wrapped in this instance typed as an instance of <typeparamref name="T2"/>.
    /// </summary>
    public T2 AsT2 { get; }

    /// <summary>
    /// Gets the type of the value wrapped in this instance.
    /// </summary>
    /// <returns></returns>
    public Type GetWrappedType();
}

