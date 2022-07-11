using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rem.CoreUtils.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rem.CoreUtilsTest;

/// <summary>
/// Assertion extensions used in this library.
/// </summary>
public static class AssertExt
{
    /// <summary>
    /// Asserts that the <typeparamref name="TStruct"/> value passed in is the default value of its type.
    /// </summary>
    /// <typeparam name="TStruct"></typeparam>
    /// <param name="_"></param>
    /// <param name="value"></param>
    public static void IsDefault<TStruct>(this Assert _, in TStruct value)
        where TStruct : struct, IDefaultDeterminableStruct
        => Assert.IsTrue(value.IsDefault);

    /// <summary>
    /// Asserts that the <typeparamref name="TStruct"/> value passed in is not the default value of its type.
    /// </summary>
    /// <typeparam name="TStruct"></typeparam>
    /// <param name="_"></param>
    /// <param name="value"></param>
    public static void IsNotDefault<TStruct>(this Assert _, in TStruct value)
        where TStruct : struct, IDefaultDeterminableStruct
        => Assert.IsTrue(value.IsNotDefault);

    /// <summary>
    /// Asserts that the <see cref="Action"/> passed in throws an instance of <see cref="InvalidCastException"/>
    /// (and not a subtype) when run.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    public static InvalidCastException ThrowsCastException(this Assert _, Action action)
        => Assert.ThrowsException<InvalidCastException>(action);
}
