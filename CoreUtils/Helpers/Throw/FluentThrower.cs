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
/// This class is mainly intended to offer a less verbose way of throwing exceptions in cases that commonly arise
/// in code.
/// It has no functionality of its own; rather, the <see cref="BasicExtensions"/> namespace contains basic extension
/// methods providing the functionality, so that users can extend the functionality by providing their own
/// extension methods.
/// </para>
/// 
/// <para>
/// Instances of the type can be used to throw exceptions as follows (assuming the contents of the
/// <see cref="BasicExtensions"/> namespace have been properly imported):
/// <code>
/// <see langword="var"/> throw = <see cref="Throw"/>;
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
/// </remarks>
public sealed class FluentThrower
{
    /// <summary>
    /// An object that can be used to fluently throw exceptions.
    /// </summary>
    public static readonly FluentThrower Throw = new();

    private FluentThrower() { }
}

