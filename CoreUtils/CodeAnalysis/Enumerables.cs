using System;
using System.Collections.Generic;
using System.Text;

namespace REMuns.CoreUtils.CodeAnalysis;

/// <summary>
/// Specifies that the value of an enumerable property, field or return value is non-empty.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = true)]
public sealed class NonEmptyAttribute : Attribute { }

/// <summary>
/// Specifies that the value of an enumerable parameter should never be empty.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class NonEmptyParameterAttribute : Attribute { }
