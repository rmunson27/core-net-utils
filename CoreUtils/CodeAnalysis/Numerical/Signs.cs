using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils.CodeAnalysis.Numerical;

#region Base
/// <summary>
/// Indicates a detail about the sign of a numeric value.
/// </summary>
public abstract class SignAttribute : NumericalDetailAttribute
{
    /// <summary>
    /// Prevents this from being directly constructed.
    /// </summary>
    private protected SignAttribute() { }
}
#endregion

#region Inherited
/// <summary>
/// Indicates a detail about the sign of a numeric return value, property, or field.
/// </summary>
[AttributeUsage(
    AttributeTargets.ReturnValue | AttributeTargets.Property | AttributeTargets.Field,
    AllowMultiple = false,
    Inherited = true)]
public abstract class MemberSignAttribute : SignAttribute
{
    /// <summary>
    /// Prevents this from being directly constructed.
    /// </summary>
    private protected MemberSignAttribute() { }
}

/// <summary>
/// Indicates that a numeric return value, property or field is always positive.
/// </summary>
public sealed class PositiveAttribute : MemberSignAttribute, IPositiveAttribute { }

/// <summary>
/// Indicates that a numeric return value, property or field is always negative.
/// </summary>
public sealed class NegativeAttribute : MemberSignAttribute, INegativeAttribute { }

/// <summary>
/// Indicates that a numeric return value, property or field is never negative.
/// </summary>
public sealed class NonNegativeAttribute : MemberSignAttribute, INonNegativeAttribute { }

/// <summary>
/// Indicates that a numeric return value, property or field is never positive.
/// </summary>
public sealed class NonPositiveAttribute : MemberSignAttribute, INonPositiveAttribute { }

/// <summary>
/// Indicates that a numeric return value, property or field is never zero.
/// </summary>
public sealed class NonZeroAttribute : MemberSignAttribute, INonZeroAttribute { }

/// <summary>
/// Indicates that a numeric return value, property or field is always finite (i.e. not infinity or NaN).
/// </summary>
public sealed class FiniteAttribute : MemberSignAttribute, IFiniteAttribute { }

/// <summary>
/// Indicates that a numeric return value, property or field is never NaN.
/// </summary>
public sealed class NotNaNAttribute : MemberSignAttribute, INotNaNAttribute { }
#endregion

#region Parameter
/// <summary>
/// Indicates a detail about the sign of a method parameter.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
public abstract class ParameterSignAttribute : SignAttribute
{
    /// <summary>
    /// Prevents this from being directly constructed.
    /// </summary>
    private protected ParameterSignAttribute() { }
}

/// <summary>
/// Indicates that a numerical parameter should always be positive, or that a numerical <see langword="ref"/> or
/// <see langword="out"/> parameter will be positive when the method returns.
/// </summary>
public sealed class PositiveParameterAttribute : ParameterSignAttribute, IPositiveAttribute { }

/// <summary>
/// Indicates that a numerical parameter should always be negative, or that a numerical <see langword="ref"/> or
/// <see langword="out"/> parameter will be negative when the method returns.
/// </summary>
public sealed class NegativeParameterAttribute : ParameterSignAttribute, INegativeAttribute { }

/// <summary>
/// Indicates that a numerical parameter should never be negative, or that a numerical <see langword="ref"/> or
/// <see langword="out"/> parameter will not be negative when the method returns.
/// </summary>
public sealed class NonNegativeParameterAttribute : ParameterSignAttribute, INonNegativeAttribute { }

/// <summary>
/// Indicates that a numerical parameter should never be positive, or that a numerical <see langword="ref"/> or
/// <see langword="out"/> parameter will not be positive when the method returns.
/// </summary>
public sealed class NonPositiveParameterAttribute : ParameterSignAttribute, INonPositiveAttribute { }

/// <summary>
/// Indicates that a numerical parameter should never be zero, or that a numerical <see langword="ref"/> or
/// <see langword="out"/> parameter will not be zero when the method returns.
/// </summary>
public sealed class NonZeroParameterAttribute : ParameterSignAttribute, INonZeroAttribute { }

/// <summary>
/// Indicates that a numerical parameter should always be finite (i.e. not infinity or NaN), or that a
/// numerical <see langword="ref"/> or <see langword="out"/> parameter will be finite when the method returns.
/// </summary>
public sealed class FiniteParameterAttribute : ParameterSignAttribute, IFiniteAttribute { }

/// <summary>
/// Indicates that a numerical parameter should never be NaN, or that a numerical <see langword="ref"/> or
/// <see langword="out"/> parameter will not be NaN when the method returns.
/// </summary>
public sealed class NotNaNParameterAttribute : ParameterSignAttribute, INotNaNAttribute { }
#endregion

#region Interfaces
/// <summary>
/// An interface for attributes that indicate that a numeric value is non-positive.
/// </summary>
public interface INonPositiveAttribute { }

/// <summary>
/// An interface for attributes that indicate that a numeric value is non-negative.
/// </summary>
public interface INonNegativeAttribute { }

/// <summary>
/// An interface for attributes that indicate that a numeric value is positive.
/// </summary>
public interface IPositiveAttribute : INonZeroAttribute, INotNaNAttribute { }

/// <summary>
/// An interface for attributes that indicate that a numeric value is negative.
/// </summary>
public interface INegativeAttribute : INonZeroAttribute, INotNaNAttribute { }

/// <summary>
/// An interface for attributes that indicate that a numeric value is non-zero.
/// </summary>
public interface INonZeroAttribute { }

/// <summary>
/// An interface for attributes that indicate that a numeric value is finite.
/// </summary>
public interface IFiniteAttribute : INotNaNAttribute { }

/// <summary>
/// An interface for attributes that indicate that a numeric value is not NaN.
/// </summary>
public interface INotNaNAttribute { }
#endregion
