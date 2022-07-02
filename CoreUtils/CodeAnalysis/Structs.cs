using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.CodeAnalysis;

/// <summary>
/// Indicates that a struct type property, field, return value or generic type parameter constrained to be a value
/// type will never be the default value of its type.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property
        | AttributeTargets.Field
        | AttributeTargets.ReturnValue
        | AttributeTargets.GenericParameter,
    AllowMultiple = false,
    Inherited = true)]
public sealed class NotDefaultAttribute : Attribute { }

/// <summary>
/// Indicates that a struct type parameter should never be the default value of its type, or that a
/// <see langword="ref"/> or <see langword="out"/> struct parameter will not be the default value of its type when
/// the method returns.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class NotDefaultParameterAttribute : Attribute { }

/// <summary>
/// Specifies that an instance property, field or method return value of a struct type may be the default value
/// of its type if the instance is the default, even if other attributes indicate otherwise.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = false)]
public sealed class MaybeDefaultIfInstanceDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that a return value may be the default value of its type if the given parameter is the default
/// value of its type, even if the corresponding type disallows it or other attributes indicate otherwise.
/// </summary>
[AttributeUsage(AttributeTargets.ReturnValue)]
public sealed class MaybeDefaultIfParameterDefaultAttribute : Attribute
{
    /// <summary>
    /// The name of the parameter whose default status determines the nullability of the return value.
    /// </summary>
    public string ParameterName { get; }

    public MaybeDefaultIfParameterDefaultAttribute(string ParameterName)
    {
        this.ParameterName = ParameterName;
    }
}

/// <summary>
/// Specifies that an instance property or method of a struct type does not return (i.e. throws an exception) if the
/// instance is the default.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public sealed class DoesNotReturnIfInstanceDefaultAttribute : Attribute { }

/// <summary>
/// Indicates that when the method returns <see cref="ReturnValue"/>, the struct type parameter may be the default
/// even if other attributes indicate otherwise.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public sealed class MaybeDefaultWhenAttribute : Attribute
{
    public bool ReturnValue { get; }

    public MaybeDefaultWhenAttribute(bool ReturnValue) { this.ReturnValue = ReturnValue; }
}

/// <summary>
/// Indicates that a struct type field, property, parameter or return value may be default, even if other attributes
/// indicate otherwise.
/// </summary>
[AttributeUsage(
    AttributeTargets.Field | AttributeTargets.ReturnValue | AttributeTargets.Property | AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
public sealed class MaybeDefaultAttribute : Attribute { }

/// <summary>
/// Specifies that a structure type implementing <see cref="IDefaultDeterminableStruct"/> should be considered
/// defaultable if and only if the type parameter it is applied to is defaultable.
/// </summary>
[AttributeUsage(AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public sealed class DefaultableWithTypeParameterAttribute : Attribute
{
    /// <summary>
    /// The name of the type parameter that determines the type's defaultability.
    /// </summary>
    public string ParameterName { get; }

    public DefaultableWithTypeParameterAttribute(string ParameterName) { this.ParameterName = ParameterName; }
}

