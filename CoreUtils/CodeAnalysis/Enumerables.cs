using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.CodeAnalysis;

/// <summary>
/// Specifies that an enumerable property, field or return value is never empty.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = true)]
public sealed class NonEmptyAttribute : Attribute { }

/// <summary>
/// Specifies that the value of an enumerable parameter should never be empty, or that a <see langword="ref"/> or
/// <see langword="out"/> parameter will not be empty when the method returns.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class NonEmptyParameterAttribute : Attribute { }
