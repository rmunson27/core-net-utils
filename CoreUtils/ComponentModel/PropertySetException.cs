using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Rem.CoreUtils.ComponentModel;

/// <summary>
/// An exception thrown when a property is set to a value outside the range of acceptable values for the current
/// state of the object.
/// </summary>
public class PropertySetOutOfRangeException : PropertySetException
{
    public override string Message
        => ActualValue is null
            ? base.Message
            : base.Message + Environment.NewLine + $"Actual value was {ActualValue}.";

    private const string DefaultMessage = "Specified property set value was out of the range of valid values.";

    /// <summary>
    /// Gets the property set value that caused the exception.
    /// </summary>
    public virtual object? ActualValue { get; }

    public PropertySetOutOfRangeException() { }

    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetOutOfRangeException"/> class with the name of the
    /// property that was set to an invalid value.
    /// </summary>
    /// <param name="propName"></param>
    public PropertySetOutOfRangeException(string propName) : this(propName, DefaultMessage) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetOutOfRangeException"/> class with the name of the
    /// property that was set to an invalid value, the invalid value itself, and the specified error message.
    /// </summary>
    /// <param name="propName"></param>
    /// <param name="actualValue"></param>
    /// <param name="message"></param>
    public PropertySetOutOfRangeException(string propName, object? actualValue, string message)
        : this(propName, message)
    {
        this.ActualValue = actualValue;
    }

    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetOutOfRangeException"/> class with the name of the
    /// property that was set to an invalid value and the specified error message.
    /// </summary>
    /// <param name="propName"></param>
    /// <param name="message"></param>
    public PropertySetOutOfRangeException(string propName, string message)
        : base($"{message} (Property '{propName}')")
    { }

    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetOutOfRangeException"/> class with the specified
    /// error message and inner exception.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public PropertySetOutOfRangeException(string message, Exception innerException)
        : base(message, innerException)
    { }

    /// <summary>
    /// Allows instances of this class to be deserialized (deserialization constructor).
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected PropertySetOutOfRangeException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        ActualValue = info.GetValue(nameof(ActualValue), typeof(object));
    }

    /// <summary>
    /// Sets the <see cref="SerializationInfo"/> with the invalid property set value and additional
    /// exception information.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(ActualValue), ActualValue);
    }
}

/// <summary>
/// An exception thrown when a property is (inappropriately) set to <see langword="null"/>.
/// </summary>
public class PropertySetNullException : PropertySetException
{
    public PropertySetNullException() { }

    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetNullException"/> class with an error message
    /// including the name of the property that was set to <see langword="null"/>.
    /// </summary>
    /// <param name="propName"></param>
    public PropertySetNullException(string propName)
        : base($"Value cannot be null. (Property '{propName}')") { }

    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetNullException"/> class with an error message
    /// including the specified error message and the name of the property that was set to <see langword="null"/>.
    /// </summary>
    /// <param name="propName"></param>
    /// <param name="message"></param>
    public PropertySetNullException(string propName, string message)
        : base($"{message} (Property '{propName}')") { }
        
    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetNullException"/> class with the specified error
    /// message and inner exception.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public PropertySetNullException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Allows instances of this class to be deserialized (deserialization constructor).
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected PropertySetNullException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

/// <summary>
/// An exception thrown when a property is set to an invalid value.
/// </summary>
public class PropertySetException : InvalidOperationException
{
    public PropertySetException() { }

    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetException"/> class with the specified error message.
    /// </summary>
    /// <param name="message"></param>
    public PropertySetException(string message) : base(message) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="PropertySetException"/> class with the specified error message
    /// and inner exception.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public PropertySetException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Allows instances of this class to be deserialized (serialization constructor).
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected PropertySetException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
