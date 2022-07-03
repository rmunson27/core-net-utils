using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.Helpers.Throw;

/// <summary>
/// A class offering a simple fluent interface for throwing exceptions using the extension methods defined in
/// this namespace.
/// </summary>
/// 
/// <remarks>
/// <para>
/// This class is mainly intended to offer a less verbose way of throwing exceptions in cases that commonly arise in code.
/// It has no functionality of its own; rather, it implements empty interfaces for which there are extension
/// methods in this namespace.
/// </para>
/// 
/// <para>
/// Instances of the type can be used to throw exceptions as follows:
/// <code>
/// <see langword="var"/> throw = <see langword="new"/> <see cref="FluentThrower"/>();
/// throw.IfArgNull(arg, <see langword="nameof"/>(arg)); // Will throw an ArgumentNullException if arg is null
/// </code>
/// 
/// The values passed in to the argument or property set exception methods will also be returned by the methods:
/// <code>
/// <see langword="var"/> x = throw.IfArgNull(arg, <see langword="nameof"/>(arg));
/// </code>
/// </para>
/// 
/// <para>
/// The property set methods provided have their <c>propName</c> arguments decorated with instances of
/// <see cref="System.Runtime.CompilerServices.CallerMemberNameAttribute"/>, and so will infer the name of the
/// property they are called in.  Therefore, the argument can usually be left out:
/// 
/// <code>
/// throw.IfPropSetNull(value);
/// </code>
/// </para>
///
/// <para>
/// Other classes can implement the interfaces provided in this library to be able to use the extension methods, or
/// can use the same extension strategy to add further exception-throwing methods.
/// </para>
/// </remarks>
public class FluentThrower : IBasicComparisonThrower, IBasicNumericThrower, IInvalidDefaultValueThrower
{
    //
}

/// <summary>
/// Wraps a single instance of <see cref="FluentThrower"/> to be used for throwing exceptions.
/// </summary>
/// <remarks>
/// This instance can be globally exposed via <see langword="global"/> <see langword="using"/> directive as follows:
/// <code>
/// <see langword="global"/> <see langword="using"/> <see langword="static"/> <see cref="FluentThrowerWrapper"/>;
/// </code>
/// </remarks>
public static class FluentThrowerWrapper
{
    /// <summary>
    /// An object that can be used to fluently throw exceptions.
    /// </summary>
    public static readonly FluentThrower Throw = new();
}
