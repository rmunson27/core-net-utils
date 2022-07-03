using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Rem.CoreUtils.CodeAnalysis.Numerical;

#region Greater
/// <summary>
/// Specifies that a numerical property, field or return value is always greater than a given integer value.
/// </summary>
public sealed class GreaterThanIntegerAttribute : GreaterThanAttribute
{
    /// <summary>
    /// The value that the numerical property, field or return value is always greater than.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class indicating that the target
    /// is greater than the given <see cref="long"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public GreaterThanIntegerAttribute(long Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class indicating that the target
    /// is greater than the given <see cref="ulong"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public GreaterThanIntegerAttribute(ulong Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class indicating that the target
    /// is greater than the <see cref="BigInteger"/> value with the given string representation.
    /// </summary>
    /// <param name="Value"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="Representation"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// <paramref name="Representation"/> could not be parsed as an instance of <see cref="BigInteger"/>.
    /// </exception>
    public GreaterThanIntegerAttribute(string Representation)
    {
        this.Value = BigInteger.Parse(Representation);
    }
}

/// <summary>
/// Specifies that a numerical property, field or return value is always greater than a given value.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = true)]
public abstract class GreaterThanAttribute : NumericalRangeAttribute
{
    private protected GreaterThanAttribute() { }
}

/// <summary>
/// Specifies that a numerical parameter should always be greater than a given integer value, or that a numerical
/// <see langword="ref"/> or <see langword="out"/> parameter will be greater than a given integer value when the
/// method returns.
/// </summary>
public sealed class ParameterGreaterThanIntegerAttribute : ParameterGreaterThanAttribute
{
    /// <summary>
    /// The value that the numerical parameter should be greater than.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterGreaterThanIntegerAttribute"/> class indicating that the
    /// target is greater than the given <see cref="long"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public ParameterGreaterThanIntegerAttribute(long Value) { this.Value = Value; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterGreaterThanIntegerAttribute"/> class indicating that the
    /// target is greater than the given <see cref="ulong"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public ParameterGreaterThanIntegerAttribute(ulong Value) { this.Value = Value; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterGreaterThanIntegerAttribute"/> class indicating that the
    /// target is greater than the <see cref="BigInteger"/> value with the given string representation.
    /// </summary>
    /// <param name="Value"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="Representation"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// <paramref name="Representation"/> could not be parsed as an instance of <see cref="BigInteger"/>.
    /// </exception>
    public ParameterGreaterThanIntegerAttribute(string Representation)
    {
        this.Value = BigInteger.Parse(Representation);
    }
}

/// <summary>
/// Specifies that a numerical parameter should always be greater than a given value, or that a numerical
/// <see langword="ref"/> or <see langword="out"/> parameter will be greater than a given value when the
/// method returns.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
public abstract class ParameterGreaterThanAttribute : NumericalRangeAttribute
{
    private protected ParameterGreaterThanAttribute() { }
}

/// <summary>
/// Specifies that a numerical parameter should always be greater than a given numerical parameter, that a numerical
/// return value is always greater than a given numerical parameter, or that a numerical <see langword="ref"/> or
/// <see langword="out"/> parameter will always be greater than a given numerical parameter when the method returns.
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
#endregion

#region Greater Or Equal
/// <summary>
/// Specifies that a numerical property, field or return value is always greater than or equal to a given integer value.
/// </summary>
public sealed class GreaterThanOrEqualToIntegerAttribute : GreaterThanAttribute
{
    /// <summary>
    /// The value that the numerical property, field or return value is always greater than or equal to.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class indicating that the target
    /// is greater than or equal to the given <see cref="long"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public GreaterThanOrEqualToIntegerAttribute(long Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class indicating that the target
    /// is greater than or equal to the given <see cref="ulong"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public GreaterThanOrEqualToIntegerAttribute(ulong Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="GreaterThanIntegerAttribute"/> class indicating that the target
    /// is greater than or equal to the <see cref="BigInteger"/> value with the given string representation.
    /// </summary>
    /// <param name="Value"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="Representation"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// <paramref name="Representation"/> could not be parsed as an instance of <see cref="BigInteger"/>.
    /// </exception>
    public GreaterThanOrEqualToIntegerAttribute(string Representation)
    {
        this.Value = BigInteger.Parse(Representation);
    }
}

/// <summary>
/// Specifies that a numerical property, field or return value is always greater than or equal to a given value.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = true)]
public abstract class GreaterThanOrEqualToAttribute : NumericalRangeAttribute
{
    private protected GreaterThanOrEqualToAttribute() { }
}

/// <summary>
/// Specifies that a numerical parameter should always be greater than or equal to a given integer value, or that a
/// numerical <see langword="ref"/> or <see langword="out"/> parameter will be greater than a given integer value when
/// the method returns.
/// </summary>
public sealed class ParameterGreaterThanOrEqualToIntegerAttribute : ParameterGreaterThanOrEqualToAttribute
{
    /// <summary>
    /// The value that the numerical parameter should be greater than or equal to.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterGreaterThanIntegerAttribute"/> class indicating that the
    /// target is greater than or equal to the given <see cref="long"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public ParameterGreaterThanOrEqualToIntegerAttribute(long Value) { this.Value = Value; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterGreaterThanIntegerAttribute"/> class indicating that the
    /// target is greater than or equal to the given <see cref="ulong"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public ParameterGreaterThanOrEqualToIntegerAttribute(ulong Value) { this.Value = Value; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterGreaterThanIntegerAttribute"/> class indicating that the
    /// target is greater than or equal to the <see cref="BigInteger"/> value with the given string representation.
    /// </summary>
    /// <param name="Value"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="Representation"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// <paramref name="Representation"/> could not be parsed as an instance of <see cref="BigInteger"/>.
    /// </exception>
    public ParameterGreaterThanOrEqualToIntegerAttribute(string Representation)
    {
        this.Value = BigInteger.Parse(Representation);
    }
}

/// <summary>
/// Specifies that a numerical parameter should always be greater than or equal to a given value, or that a numerical
/// <see langword="ref"/> or <see langword="out"/> parameter will be greater than or equal to a given value when the
/// method returns.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
public abstract class ParameterGreaterThanOrEqualToAttribute : NumericalRangeAttribute
{
    private protected ParameterGreaterThanOrEqualToAttribute() { }
}

/// <summary>
/// Specifies that a numerical parameter should always be greater than or equal to a given numerical parameter, that
/// a numerical return value is always greater than or equal to a given numerical parameter, or that a numerical
/// <see langword="ref"/> or <see langword="out"/> parameter will always be greater than or equal to a given numerical
/// parameter when the method returns.
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
#endregion

#region Less Or Equal
/// <summary>
/// Specifies that a numerical property, field or return value is always less than or equal to a given integer value.
/// </summary>
public sealed class LessThanOrEqualToIntegerAttribute : LessThanAttribute
{
    /// <summary>
    /// The value that the numerical property, field or return value is always less than or equal to.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class indicating that the target
    /// is less than or equal to the given <see cref="long"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public LessThanOrEqualToIntegerAttribute(long Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class indicating that the target
    /// is less than or equal to the given <see cref="ulong"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public LessThanOrEqualToIntegerAttribute(ulong Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class indicating that the target
    /// is less than or equal to the <see cref="BigInteger"/> value with the given string representation.
    /// </summary>
    /// <param name="Value"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="Representation"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// <paramref name="Representation"/> could not be parsed as an instance of <see cref="BigInteger"/>.
    /// </exception>
    public LessThanOrEqualToIntegerAttribute(string Representation)
    {
        this.Value = BigInteger.Parse(Representation);
    }
}

/// <summary>
/// Specifies that a numerical property, field or return value is always less than or equal to a given value.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = true)]
public abstract class LessThanOrEqualToAttribute : NumericalRangeAttribute
{
    private protected LessThanOrEqualToAttribute() { }
}

/// <summary>
/// Specifies that a numerical parameter should always be less than or equal to a given integer value, or that a
/// numerical <see langword="ref"/> or <see langword="out"/> parameter will be less than or equal to a given integer
/// value when the method returns.
/// </summary>
public sealed class ParameterLessThanOrEqualToIntegerAttribute : ParameterLessThanOrEqualToAttribute
{
    /// <summary>
    /// The value that the numerical parameter should be less than or equal to.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterLessThanIntegerAttribute"/> class indicating that the
    /// target is less than or equal to the given <see cref="long"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public ParameterLessThanOrEqualToIntegerAttribute(long Value) { this.Value = Value; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterLessThanIntegerAttribute"/> class indicating that the
    /// target is less than or equal to the given <see cref="ulong"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public ParameterLessThanOrEqualToIntegerAttribute(ulong Value) { this.Value = Value; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterLessThanIntegerAttribute"/> class indicating that the
    /// target is less than or equal to the <see cref="BigInteger"/> value with the given string representation.
    /// </summary>
    /// <param name="Value"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="Representation"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// <paramref name="Representation"/> could not be parsed as an instance of <see cref="BigInteger"/>.
    /// </exception>
    public ParameterLessThanOrEqualToIntegerAttribute(string Representation)
    {
        this.Value = BigInteger.Parse(Representation);
    }
}

/// <summary>
/// Specifies that a numerical parameter should always be less than or equal to a given value, or that a numerical
/// <see langword="ref"/> or <see langword="out"/> parameter will be less than or equal to a given value when the
/// method returns.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
public abstract class ParameterLessThanOrEqualToAttribute : NumericalRangeAttribute
{
    private protected ParameterLessThanOrEqualToAttribute() { }
}

/// <summary>
/// Specifies that a numerical parameter should always be less than or equal to a given numerical parameter, that
/// a numerical return value is always less than or equal to a given numerical parameter, or that a numerical
/// <see langword="ref"/> or <see langword="out"/> parameter will always be less than or equal to a given numerical
/// parameter when the method returns.
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
#endregion

#region Less
/// <summary>
/// Specifies that a numerical property, field or return value is always less than a given integer value.
/// </summary>
public sealed class LessThanIntegerAttribute : LessThanAttribute
{
    /// <summary>
    /// The value that the numerical property, field or return value is always less than.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class indicating that the target
    /// is less than the given <see cref="long"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public LessThanIntegerAttribute(long Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class indicating that the target
    /// is less than the given <see cref="ulong"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public LessThanIntegerAttribute(ulong Value)
    {
        this.Value = Value;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="LessThanIntegerAttribute"/> class indicating that the target
    /// is less than the <see cref="BigInteger"/> value with the given string representation.
    /// </summary>
    /// <param name="Value"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="Representation"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// <paramref name="Representation"/> could not be parsed as an instance of <see cref="BigInteger"/>.
    /// </exception>
    public LessThanIntegerAttribute(string Representation)
    {
        this.Value = BigInteger.Parse(Representation);
    }
}

/// <summary>
/// Specifies that a numerical property, field or return value is always less than a given value.
/// </summary>
[AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue,
    AllowMultiple = false,
    Inherited = true)]
public abstract class LessThanAttribute : NumericalRangeAttribute
{
    private protected LessThanAttribute() { }
}

/// <summary>
/// Specifies that a numerical parameter should always be less than a given integer value, or that a numerical
/// <see langword="ref"/> or <see langword="out"/> parameter will be less than a given integer value when the
/// method returns.
/// </summary>
public sealed class ParameterLessThanIntegerAttribute : ParameterLessThanAttribute
{
    /// <summary>
    /// The value that the numerical parameter should be less than.
    /// </summary>
    public BigInteger Value { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterLessThanIntegerAttribute"/> class indicating that the
    /// target is less than the given <see cref="long"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public ParameterLessThanIntegerAttribute(long Value) { this.Value = Value; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterLessThanIntegerAttribute"/> class indicating that the
    /// target is less than the given <see cref="ulong"/> value.
    /// </summary>
    /// <param name="Value"></param>
    public ParameterLessThanIntegerAttribute(ulong Value) { this.Value = Value; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ParameterLessThanIntegerAttribute"/> class indicating that the
    /// target is less than the <see cref="BigInteger"/> value with the given string representation.
    /// </summary>
    /// <param name="Value"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="Representation"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="FormatException">
    /// <paramref name="Representation"/> could not be parsed as an instance of <see cref="BigInteger"/>.
    /// </exception>
    public ParameterLessThanIntegerAttribute(string Representation)
    {
        this.Value = BigInteger.Parse(Representation);
    }
}

/// <summary>
/// Specifies that a numerical parameter should always be less than a given value, or that a numerical
/// <see langword="ref"/> or <see langword="out"/> parameter will be less than a given value when the
/// method returns.
/// </summary>
[AttributeUsage(
    AttributeTargets.Parameter,
    AllowMultiple = false,
    Inherited = false)]
public abstract class ParameterLessThanAttribute : NumericalRangeAttribute
{
    private protected ParameterLessThanAttribute() { }
}

/// <summary>
/// Specifies that a numerical parameter should always be less than a given numerical parameter, that a numerical
/// return value is always less than a given numerical parameter, or that a numerical <see langword="ref"/> or
/// <see langword="out"/> parameter will always be less than a given numerical parameter when the method returns.
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
#endregion

#region Base
/// <summary>
/// Indicates a detail about the range of a numerical value.
/// </summary>
public abstract class NumericalRangeAttribute : NumericalDetailAttribute
{
    private protected NumericalRangeAttribute() { }
}
#endregion

