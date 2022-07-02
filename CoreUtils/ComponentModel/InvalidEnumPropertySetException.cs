using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Rem.CoreUtils.ComponentModel;

/// <summary>
/// An exception thrown when a property is set to an invalid enum value.
/// </summary>
public class InvalidEnumPropertySetException : PropertySetException
{
    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidEnumPropertySetException"/> class.
    /// </summary>
    public InvalidEnumPropertySetException() { }

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidEnumPropertySetException"/> class with the message
    /// passed in.
    /// </summary>
    /// <param name="message"></param>
    public InvalidEnumPropertySetException(string message) : base(message) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidEnumPropertySetException"/> class with the message and inner
    /// exception passed in.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public InvalidEnumPropertySetException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidEnumPropertySetException"/> class from the serialization
    /// info and streaming context passed in (serialization constructor).
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected InvalidEnumPropertySetException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
}
