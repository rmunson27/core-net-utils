﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Rem.CoreUtils.ComponentModel;

#region Classes
/// <summary>
/// A base class for <see cref="IMutableModelGetState{TImmutable}"/> implementations that should trigger property
/// change events when the state of the object is changed.
/// </summary>
/// <typeparam name="TImmutable"></typeparam>
public abstract class ObservableMutableModelGetState<TImmutable>
    : ObservableObject, IMutableModelGetState<TImmutable>
    where TImmutable : notnull
{
    /// <inheritdoc cref="IMutableModelGetState{TImmutable}.CurrentState"/>
    public abstract TImmutable CurrentState { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ObservableMutableModelGetState{TImmutable}"/> class.
    /// </summary>
    protected ObservableMutableModelGetState()
    {
        PropertyChanging += This_PropertyChanging;
        PropertyChanged += This_PropertyChanged;
    }

    private void This_PropertyChanging(object? _, PropertyChangingEventArgs e)
        => OnPropertyChanging(nameof(CurrentState));

    private void This_PropertyChanged(object? _, PropertyChangedEventArgs e)
        => OnPropertyChanged(nameof(CurrentState));
}

/// <summary>
/// A base class for <see cref="IMutableModelGetState{TImmutable}"/> implementations that should trigger nested property
/// change events when the state of the object is changed.
/// </summary>
/// <typeparam name="TImmutable"></typeparam>
public abstract class NestedObservableMutableModelGetState<TImmutable>
    : NestedObservableObject, IMutableModelGetState<TImmutable>
    where TImmutable : notnull
{
    /// <inheritdoc cref="IMutableModelGetState{TImmutable}.CurrentState"/>
    public abstract TImmutable CurrentState { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NestedObservableMutableModelGetState{TImmutable}"/> class.
    /// </summary>
    protected NestedObservableMutableModelGetState()
    {
        PropertyChanging += This_PropertyChanging;
        PropertyChanged += This_PropertyChanged;
    }

    private void This_PropertyChanging(object? _, PropertyChangingEventArgs e)
        => OnPropertyChanging(nameof(CurrentState));

    private void This_PropertyChanged(object? _, PropertyChangedEventArgs e)
        => OnPropertyChanged(nameof(CurrentState));
}
#endregion

#region Interfaces
#region Full
/// <summary>
/// An interface for types that represent mutable versions of an immutable type <typeparamref name="TImmutable"/>,
/// and that can be queried for a <typeparamref name="TImmutable"/> instance representing the current state.
/// </summary>
/// <typeparam name="TImmutable"></typeparam>
public interface IMutableModelGetState<out TImmutable> where TImmutable : notnull
{
    /// <summary>
    /// Gets a <typeparamref name="TImmutable"/> instance representing the current state of this object.
    /// </summary>
    public TImmutable CurrentState { get; }
}

/// <summary>
/// An interface for types that represent mutable versions of an immutable type <typeparamref name="TImmutable"/>,
/// and that can have their state set to describe a given <typeparamref name="TImmutable"/> instance.
/// </summary>
/// <typeparam name="TImmutable"></typeparam>
public interface IMutableModelSetState<in TImmutable> where TImmutable : notnull
{
    /// <summary>
    /// Sets the current state of this object to describe the <typeparamref name="TImmutable"/> passed in.
    /// </summary>
    /// <param name="state"></param>
    public void SetState(TImmutable state);
}

/// <summary>
/// An interface for types that represent mutable versions of an immutable type <typeparamref name="TImmutable"/>,
/// can be queried for a <typeparamref name="TImmutable"/> instance representing the current state,
/// and can have their state set to describe a given <typeparamref name="TImmutable"/>.
/// </summary>
/// <typeparam name="TImmutable"></typeparam>
public interface IMutableModel<TImmutable>
    : IMutableModelGetState<TImmutable>, IMutableModelSetState<TImmutable>
    where TImmutable : notnull
{
    //
}
#endregion

#region Partial
/// <summary>
/// Extension methods for the <see cref="IMutablePartialModelGetState{TImmutable}"/> interface.
/// </summary>
public static class MutablePartialModelGetStateExtensions
{
    /// <summary>
    /// Throws an <see cref="InvalidMutableModelStateException"/> if the current
    /// <see cref="IMutablePartialModelGetState{TImmutable}"/> instance is not in a valid state.
    /// </summary>
    /// <typeparam name="TImmutable"></typeparam>
    /// <param name="model"></param>
    /// <exception cref="InvalidMutableModelStateException"></exception>
    public static void ThrowIfNotInValidState<TImmutable>(this IMutablePartialModelGetState<TImmutable> model)
        where TImmutable : notnull
    {
        if (!model.IsInValidState) throw new InvalidMutableModelStateException(
            $"Object implementing {typeof(IMutablePartialModelGetState<TImmutable>)} was in an invalid state (and"
                + $" therefore did not represent an instance of type {typeof(TImmutable)}).");
    }
}

/// <summary>
/// An interface for types that represent mutable versions of an immutable type <typeparamref name="TImmutable"/>,
/// and that can be queried for a <typeparamref name="TImmutable"/> instance representing the current state, but may be
/// in an invalid state not representing an instance of <typeparamref name="TImmutable"/>.
/// </summary>
/// <typeparam name="TImmutable"></typeparam>
public interface IMutablePartialModelGetState<out TImmutable> where TImmutable : notnull
{
    /// <summary>
    /// Gets whether or not this object is in a valid state that represents an instance of
    /// <typeparamref name="TImmutable"/>.
    /// </summary>
    public bool IsInValidState { get; }

    /// <summary>
    /// Gets a <typeparamref name="TImmutable"/> instance representing the current state of this object, or throws
    /// an exception if this object is not in a valid state.
    /// </summary>
    /// <exception cref="InvalidMutableModelStateException">
    /// This object was not in a valid state.
    /// </exception>
    public TImmutable CurrentState { get; }

    /// <summary>
    /// Gets a <typeparamref name="TImmutable"/> instance representing the current state of this object, or
    /// <see langword="null"/> if this object is not in a valid state.
    /// </summary>
    public TImmutable? CurrentStateOrNull { get; }
}

/// <summary>
/// An interface for types that represent mutable versions of an immutable type <typeparamref name="TImmutable"/>,
/// can be queried for a <typeparamref name="TImmutable"/> instance representing the current state,
/// and can have their state set to describe a given <typeparamref name="TImmutable"/>, but may be in an invalid state
/// not representing an instance of type <typeparamref name="TImmutable"/>.
/// </summary>
/// <typeparam name="TImmutable"></typeparam>
public interface IMutablePartialModel<TImmutable>
    : IMutablePartialModelGetState<TImmutable>, IMutableModelSetState<TImmutable>
    where TImmutable : notnull
{
    //
}

/// <summary>
/// An exception thrown when an attempt is made to access an <see cref="IMutablePartialModelGetState{TImmutable}"/>
/// instance that is in an invalid state.
/// </summary>
public class InvalidMutableModelStateException : InvalidOperationException
{
    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidMutableModelStateException"/> class.
    /// </summary>
    public InvalidMutableModelStateException() { }

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidMutableModelStateException"/> class with the specified
    /// error message.
    /// </summary>
    /// <param name="message"></param>
    public InvalidMutableModelStateException(string message) : base(message) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidMutableModelStateException"/> class with the specified
    /// error message and inner exception.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public InvalidMutableModelStateException(string message, Exception innerException) : base(message, innerException)
    { }

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidMutableModelStateException"/> class from the serialization
    /// data passed in (serialization constructor).
    /// </summary>
    /// <param name="info"></param>
    /// <param name="context"></param>
    protected InvalidMutableModelStateException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }
}
#endregion
#endregion
