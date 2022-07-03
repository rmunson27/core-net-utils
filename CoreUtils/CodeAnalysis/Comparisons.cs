using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.CodeAnalysis;

/// <summary>
/// Specifies that a parameter should always be greater than a given parameter, that a return value is always greater
/// than a given parameter, or that a <see langword="ref"/> or <see langword="out"/> parameter will always be greater
/// than a given parameter when the method returns.
/// </summary>
[AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class GreaterThanParameterAttribute : Attribute
{
    /// <summary>
    /// The name of the parameter that the target is greater than.
    /// </summary>
    public string ParameterName { get; }

    public GreaterThanParameterAttribute(string ParameterName) { this.ParameterName = ParameterName; }
}

/// <summary>
/// Specifies that a parameter should always be greater than or equal to a given parameter, that a return value is
/// always greater than or equal to a given parameter, or that a <see langword="ref"/> or <see langword="out"/>
/// parameter will always be greater than or equal to a given parameter when the method returns.
/// </summary>
[AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class GreaterThanOrEqualToParameterAttribute : Attribute
{
    /// <summary>
    /// The name of the parameter that the target is greater than or equal to.
    /// </summary>
    public string ParameterName { get; }

    public GreaterThanOrEqualToParameterAttribute(string ParameterName) { this.ParameterName = ParameterName; }
}

/// <summary>
/// Specifies that a parameter should always be less than or equal to a given parameter, that a return value is always
/// less than or equal to a given parameter, or that a <see langword="ref"/> or <see langword="out"/> parameter will
/// always be less than or equal to a given parameter when the method returns.
/// </summary>
[AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class LessThanOrEqualToParameterAttribute : Attribute
{
    /// <summary>
    /// The name of the parameter that the target is less than or equal to.
    /// </summary>
    public string ParameterName { get; }

    public LessThanOrEqualToParameterAttribute(string ParameterName) { this.ParameterName = ParameterName; }
}

/// <summary>
/// Specifies that a parameter should always be less than a given parameter, that a return value is always less than
/// a given parameter, or that a <see langword="ref"/> or <see langword="out"/> parameter will always be less than a
/// given parameter when the method returns.
/// </summary>
[AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class LessThanParameterAttribute : Attribute
{
    /// <summary>
    /// The name of the parameter that the target is less than.
    /// </summary>
    public string ParameterName { get; }

    public LessThanParameterAttribute(string ParameterName) { this.ParameterName = ParameterName; }
}
