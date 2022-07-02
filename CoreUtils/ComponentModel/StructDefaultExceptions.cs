using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Rem.CoreUtils.ComponentModel;

/// <summary>
/// An exception thrown when a <see langword="struct"/> argument is the default value of its type when that is not
/// permitted by the method being called.
/// </summary>
public class StructArgumentDefaultException : ArgumentException
{
    public StructArgumentDefaultException() { }

    /// <summary>
    /// Constructs a new instance of the <see cref="StructArgumentDefaultException"/> class with a default error
    /// message including the name of the parameter that caused the exception.
    /// </summary>
    /// <param name="paramName"></param>
    public StructArgumentDefaultException(string paramName)
        : base($"Value cannot be default. (Parameter '{paramName}')") { }

    /// <summary>
    /// Constructs a new instance of the <see cref="StructArgumentDefaultException"/> class with an error message
    /// including the supplied message and the name of the parameter that caused the exception.
    /// </summary>
    /// <param name="paramName"></param>
    /// <param name="message"></param>
    public StructArgumentDefaultException(string paramName, string message)
        : base($"{message} (Parameter '{paramName}')") { }

    /// <summary>
    /// Constructs a new instance of the <see cref="StructArgumentDefaultException"/> class with the supplied error
    /// message and inner exception.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public StructArgumentDefaultException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="StructArgumentDefaultException"/> from the serialization info and
    /// streaming context passed in (serialization constructor).
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected StructArgumentDefaultException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}

/// <summary>
/// An exception thrown when a <see langword="struct"/> property is set to the default value of its type when that
/// is not permitted by the current state of the object.
/// </summary>
public class StructPropertySetDefaultException : PropertySetException
{
    public StructPropertySetDefaultException() { }

    /// <summary>
    /// Constructs a new instance of the <see cref="StructPropertySetDefaultException"/> class with a default error
    /// message including the name of the property that was set to an invalid default value.
    /// </summary>
    /// <param name="propName"></param>
    public StructPropertySetDefaultException(string propName)
        : base($"Value cannot be default. (Property '{propName}')") { }

    /// <summary>
    /// Constructs a new instance of the <see cref="StructPropertySetDefaultException"/> class with an error message
    /// including the supplied message and the name of the property that was set to an invalid default value.
    /// </summary>
    /// <param name="propName"></param>
    /// <param name="message"></param>
    public StructPropertySetDefaultException(string propName, string message)
        : base($"{message} (Property '{propName}')") { }

    /// <summary>
    /// Constructs a new instance of the <see cref="StructPropertySetDefaultException"/> class with the supplied error
    /// message and inner exception.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public StructPropertySetDefaultException(string message, Exception innerException)
        : base(message, innerException) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="StructPropertySetDefaultException"/> from the serialization info
    /// and streaming context passed in (serialization constructor).
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected StructPropertySetDefaultException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}

