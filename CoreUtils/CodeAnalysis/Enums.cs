using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.CodeAnalysis;

/// <summary>
/// Indicates that an enumeration-type property, field or return value is always a named, defined value
/// of its type.
/// </summary>
[AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
        AllowMultiple = false,
        Inherited = true)]
public class NamedEnumAttribute : Attribute { }

/// <summary>
/// Indicates that an enumeration-type parameter should always be a named, defined value of its type, or that a
/// <see langword="ref"/> or <see langword="out"/> parameter will be a named, defined value of its type when the
/// method returns.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public class NamedEnumParameterAttribute : Attribute { }

