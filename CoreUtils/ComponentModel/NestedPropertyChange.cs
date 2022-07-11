using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Rem.CoreUtils.ComponentModel;

using static GenericPropertyChange;

#region Classes
#region NestedObservableObject
/// <summary>
/// A base class for objects that notify of nested property changes.
/// </summary>
/// <remarks>
/// The <see cref="NestedPropertyChanging"/> and <see cref="NestedPropertyChanged"/> events
/// implemented by this class will be triggered whenever the <see cref="ObservableObject.PropertyChanging"/> and
/// <see cref="ObservableObject.PropertyChanged"/> events are triggered, respectively.
/// </remarks>
public abstract class NestedObservableObject
    : ObservableObject, INotifyNestedPropertyChanged, INotifyNestedPropertyChanging
{
    #region Events
    /// <inheritdoc cref="INotifyNestedPropertyChanged.NestedPropertyChanged"/>
    public event NestedPropertyChangedEventHandler? NestedPropertyChanged;

    /// <inheritdoc cref="INotifyNestedPropertyChanging.NestedPropertyChanging"/>
    public event NestedPropertyChangingEventHandler? NestedPropertyChanging;
    #endregion

    #region Constructor
    /// <summary>
    /// Constructs a new instance of the <see cref="NestedObservableObject"/> class.
    /// </summary>
    protected NestedObservableObject()
    {
        // Ensure that nested property changes are fired whenever property changes are
        PropertyChanging += This_PropertyChanging;
        PropertyChanged += This_PropertyChanged;
    }
    #endregion

    #region Property Setters
    /// <summary>
    /// Sets a property that notifies of nested changes, handling the shuffling of events before setting the value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <param name="newValue"></param>
    /// <param name="changing"></param>
    /// <param name="changed"></param>
    /// <param name="propertyName"></param>
    protected void SetNestedChangeProperty<T>(
        [NotNullIfNotNull("newValue")] ref T field, T newValue,
        NestedPropertyChangingEventHandler changing, NestedPropertyChangedEventHandler changed,
        [CallerMemberName] string? propertyName = null)
        where T : INotifyNestedPropertyChanging?, INotifyNestedPropertyChanged?
    {
        OnPropertyChanging(propertyName);

        // Remove old events
        if (field is not null)
        {
            field.NestedPropertyChanging -= changing;
            field.NestedPropertyChanged -= changed;
        }

        // Set the field
        field = newValue;

        // Add new events
        if (field is not null)
        {
            field.NestedPropertyChanging += changing;
            field.NestedPropertyChanged += changed;
        }

        OnPropertyChanged(propertyName);
    }

    /// <summary>
    /// Sets a property that notifies of nested changes, handling the shuffling of events before setting the value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <param name="newValue"></param>
    /// <param name="changing"></param>
    /// <param name="propertyName"></param>
    protected void SetNestedChangeProperty<T>(
        [NotNullIfNotNull("newValue")] ref T field, T newValue,
        NestedPropertyChangingEventHandler changing,
        [CallerMemberName] string? propertyName = null)
        where T : INotifyNestedPropertyChanging?
    {
        OnPropertyChanging(propertyName);

        // Remove old event
        if (field is not null)
        {
            field.NestedPropertyChanging -= changing;
        }

        // Set the field
        field = newValue;

        // Add new event
        if (field is not null)
        {
            field.NestedPropertyChanging += changing;
        }

        OnPropertyChanged(propertyName);
    }

    /// <summary>
    /// Sets a property that notifies of nested changes, handling the shuffling of events before setting the value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <param name="newValue"></param>
    /// <param name="changed"></param>
    /// <param name="propertyName"></param>
    protected void SetNestedChangeProperty<T>(
        [NotNullIfNotNull("newValue")] ref T field, T newValue,
        NestedPropertyChangedEventHandler changed,
        [CallerMemberName] string? propertyName = null)
        where T : INotifyNestedPropertyChanged?
    {
        OnPropertyChanging(propertyName);

        // Remove old event
        if (field is not null)
        {
            field.NestedPropertyChanged -= changed;
        }

        // Set the field
        field = newValue;

        // Add new event
        if (field is not null)
        {
            field.NestedPropertyChanged += changed;
        }

        OnPropertyChanged(propertyName);
    }

    /// <summary>
    /// Sets a property that notifies of nested changes, handling the shuffling of events before setting the value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <param name="newValue"></param>
    /// <param name="changing"></param>
    /// <param name="changed"></param>
    /// <param name="propertyName"></param>
    protected void SetChangeProperty<T>(
        [NotNullIfNotNull("newValue")] ref T field, T newValue,
        PropertyChangingEventHandler changing, PropertyChangedEventHandler changed,
        [CallerMemberName] string? propertyName = null)
        where T : INotifyPropertyChanging?, INotifyPropertyChanged?
    {
        OnPropertyChanging(propertyName);

        // Remove old events
        if (field is not null)
        {
            field.PropertyChanging -= changing;
            field.PropertyChanged -= changed;
        }

        // Set the field
        field = newValue;

        // Add new events
        if (field is not null)
        {
            field.PropertyChanging += changing;
            field.PropertyChanged += changed;
        }

        OnPropertyChanged(propertyName);
    }

    /// <summary>
    /// Sets a property that notifies of nested changes, handling the shuffling of events before setting the value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <param name="newValue"></param>
    /// <param name="changing"></param>
    /// <param name="propertyName"></param>
    protected void SetChangeProperty<T>(
        [NotNullIfNotNull("newValue")] ref T field, T newValue,
        PropertyChangingEventHandler changing,
        [CallerMemberName] string? propertyName = null)
        where T : INotifyPropertyChanging?, INotifyPropertyChanged?
    {
        OnPropertyChanging(propertyName);

        // Remove old event
        if (field is not null)
        {
            field.PropertyChanging -= changing;
        }

        // Set the field
        field = newValue;

        // Add new event
        if (field is not null)
        {
            field.PropertyChanging += changing;
        }

        OnPropertyChanged(propertyName);
    }

    /// <summary>
    /// Sets a property that notifies of nested changes, handling the shuffling of events before setting the value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="field"></param>
    /// <param name="newValue"></param>
    /// <param name="changed"></param>
    /// <param name="propertyName"></param>
    protected void SetChangeProperty<T>(
        [NotNullIfNotNull("newValue")] ref T field, T newValue,
        PropertyChangedEventHandler changed,
        [CallerMemberName] string? propertyName = null)
        where T : INotifyPropertyChanging?, INotifyPropertyChanged?
    {
        OnPropertyChanging(propertyName);

        // Remove old event
        if (field is not null)
        {
            field.PropertyChanged -= changed;
        }

        // Set the field
        field = newValue;

        // Add new event
        if (field is not null)
        {
            field.PropertyChanged += changed;
        }

        OnPropertyChanged(propertyName);
    }
    #endregion

    #region Event Handlers
    /// <summary>
    /// Fires the <see cref="NestedPropertyChanging"/> event whenever the
    /// <see cref="ObservableObject.PropertyChanging"/> event is triggered (so long as the property name wrapped in
    /// the event arguments is not <see langword="null"/>).
    /// </summary>
    /// <param name="_"></param>
    /// <param name="e"></param>
    private void This_PropertyChanging(object? _, PropertyChangingEventArgs e)
    {
        if (e.PropertyName is not null) OnNestedPropertyChanging(new(e.PropertyName));
    }

    /// <summary>
    /// Fires the <see cref="NestedPropertyChanged"/> event whenever the <see cref="ObservableObject.PropertyChanged"/>
    /// event is triggered (so long as the property name wrapped in the event arguments is not <see langword="null"/>).
    /// </summary>
    /// <param name="_"></param>
    /// <param name="e"></param>
    private void This_PropertyChanged(object? _, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is not null) OnNestedPropertyChanged(new(e.PropertyName));
    }
    #endregion

    #region Event Handler Building Helpers
    /// <summary>
    /// Raises the <see cref="NestedPropertyChanging"/> event with arguments created by adding the child property name
    /// to the event arguments passed in.
    /// </summary>
    /// <param name="childPropertyName"></param>
    /// <param name="e"></param>
    protected void OnChildNestedPropertyChanging(string childPropertyName, NestedPropertyChangingEventArgs e)
    {
        OnNestedPropertyChanging(new(e.PropertyPath.Push(childPropertyName)));
    }

    /// <summary>
    /// Raises the <see cref="NestedPropertyChanging"/> event with arguments created by adding the child property
    /// name to the event arguments passed in.
    /// </summary>
    /// <param name="childPropertyName"></param>
    /// <param name="e"></param>
    protected void OnChildPropertyChanging(string childPropertyName, PropertyChangingEventArgs e)
    {
        if (e.PropertyName is not null)
        {
            OnNestedPropertyChanging(new(ImmutableStack.CreateRange(new[] { e.PropertyName, childPropertyName })));
        }
    }

    /// <summary>
    /// Raises the <see cref="NestedPropertyChanged"/> event with arguments created by adding the child property name
    /// to the event arguments passed in.
    /// </summary>
    /// <param name="childPropertyName"></param>
    /// <param name="e"></param>
    protected void OnChildNestedPropertyChanged(string childPropertyName, NestedPropertyChangedEventArgs e)
    {
        OnNestedPropertyChanged(new(e.PropertyPath.Push(childPropertyName)));
    }

    /// <summary>
    /// Raises the <see cref="NestedPropertyChanged"/> event with arguments created by adding the child property name
    /// to the event arguments passed in.
    /// </summary>
    /// <param name="childPropertyName"></param>
    /// <param name="e"></param>
    protected void OnChildPropertyChanged(string childPropertyName, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is not null)
        {
            OnNestedPropertyChanged(new(ImmutableStack.CreateRange(new[] { e.PropertyName, childPropertyName })));
        }
    }
    #endregion

    #region Event Triggers
    /// <summary>
    /// Raises the <see cref="NestedPropertyChanging"/> event.
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnNestedPropertyChanging(NestedPropertyChangingEventArgs e)
    {
        NestedPropertyChanging?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="NestedPropertyChanged"/> event.
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnNestedPropertyChanged(NestedPropertyChangedEventArgs e)
    {
        NestedPropertyChanged?.Invoke(this, e);
    }
    #endregion
}
#endregion

#region GenericPropertyChange
/// <summary>
/// The internal generic class providing functionality for the generic methods in the non-generic
/// <see cref="GenericPropertyChange"/> class.
/// </summary>
/// 
/// <typeparam name="TNotifier">
/// The generic reference type that potentially exposes property change events this class can be used to subscribe to
/// and unsubscribe from.
/// </typeparam>
internal static class GenericPropertyChangeNotifier<TNotifier> where TNotifier : class
{
    private static readonly NotifierTypeDescription TNotifierTypeDescription;

    static GenericPropertyChangeNotifier()
    {
        if (typeof(TNotifier).IsSubclassOf(typeof(NestedObservableObject))
                || typeof(TNotifier) == typeof(NestedObservableObject))
        {
            TNotifierTypeDescription = NotifierTypeDescription.NestedObservableObject;
        }
        else // Need to look at the interfaces implemented by TNotifier
        {
            TNotifierTypeDescription = NotifierTypeDescription.None;
            var tNotifierInterfaces = new HashSet<Type>(typeof(TNotifier).GetInterfaces());

            if (tNotifierInterfaces.Contains(typeof(INotifyNestedPropertyChanging))
                    || typeof(TNotifier) == typeof(INotifyNestedPropertyChanging))
            {
                TNotifierTypeDescription |= NotifierTypeDescription.NestedPropertyChanging;
            }
            else if (tNotifierInterfaces.Contains(typeof(INotifyPropertyChanging))
                        || typeof(TNotifier) == typeof(INotifyPropertyChanging))
            {
                TNotifierTypeDescription |= NotifierTypeDescription.PropertyChanging;
            }

            if (tNotifierInterfaces.Contains(typeof(INotifyNestedPropertyChanged))
                    || typeof(TNotifier) == typeof(INotifyNestedPropertyChanged))
            {
                TNotifierTypeDescription |= NotifierTypeDescription.NestedPropertyChanged;
            }
            else if (tNotifierInterfaces.Contains(typeof(INotifyPropertyChanged))
                        || typeof(TNotifier) == typeof(INotifyPropertyChanged))
            {
                TNotifierTypeDescription |= NotifierTypeDescription.PropertyChanged;
            }
        }
    }

    /// <summary>
    /// Subscribes to any relevant property change events on the <typeparamref name="TNotifier"/> value passed in.
    /// </summary>
    /// 
    /// <param name="value"></param>
    /// <param name="propertyChanging"></param>
    /// <param name="propertyChanged"></param>
    /// <param name="nestedPropertyChanging"></param>
    /// <param name="nestedPropertyChanged"></param>
    /// <param name="ignoreSingularIfNested">
    /// Whether or not to ignore singular (<see cref="INotifyPropertyChanging"/>, <see cref="INotifyPropertyChanged"/>)
    /// interfaces when subscribing if their nested analogs are implemented.
    /// </param>
    public static void SubscribeTo(
        TNotifier? value,
        PropertyChangingEventHandler? propertyChanging,
        PropertyChangedEventHandler? propertyChanged,
        NestedPropertyChangingEventHandler? nestedPropertyChanging,
        NestedPropertyChangedEventHandler? nestedPropertyChanged,
        bool ignoreSingularIfNested)
    {
        if (value is not null)
        {
            if (TNotifierTypeDescription.HasDescriptionFlag(NotifierTypeDescription.NestedPropertyChanging))
            {
                Unsafe.As<INotifyNestedPropertyChanging>(value).NestedPropertyChanging += nestedPropertyChanging;
                if (!ignoreSingularIfNested)
                {
                    Unsafe.As<INotifyPropertyChanging>(value).PropertyChanging += propertyChanging;
                }
            }
            else if (TNotifierTypeDescription.HasDescriptionFlag(NotifierTypeDescription.PropertyChanging))
            {
                Unsafe.As<INotifyPropertyChanging>(value).PropertyChanging += propertyChanging;
            }

            if (TNotifierTypeDescription.HasDescriptionFlag(NotifierTypeDescription.NestedPropertyChanged))
            {
                Unsafe.As<INotifyNestedPropertyChanged>(value).NestedPropertyChanged += nestedPropertyChanged;
                if (!ignoreSingularIfNested)
                {
                    Unsafe.As<INotifyPropertyChanged>(value).PropertyChanged += propertyChanged;
                }
            }
            else if (TNotifierTypeDescription.HasDescriptionFlag(NotifierTypeDescription.PropertyChanged))
            {
                Unsafe.As<INotifyPropertyChanged>(value).PropertyChanged += propertyChanged;
            }
        }
    }

    /// <summary>
    /// Unsubscribes from any relevant property change events on the <typeparamref name="TNotifier"/> value passed in.
    /// </summary>
    /// 
    /// <param name="value"></param>
    /// <param name="propertyChanging"></param>
    /// <param name="propertyChanged"></param>
    /// <param name="nestedPropertyChanging"></param>
    /// <param name="nestedPropertyChanged"></param>
    public static void UnsubscribeFrom(
        TNotifier? value,
        PropertyChangingEventHandler? propertyChanging,
        PropertyChangedEventHandler? propertyChanged,
        NestedPropertyChangingEventHandler? nestedPropertyChanging,
        NestedPropertyChangedEventHandler? nestedPropertyChanged)
    {
        if (value is not null)
        {
            if (TNotifierTypeDescription.HasDescriptionFlag(NotifierTypeDescription.NestedPropertyChanging))
            {
                Unsafe.As<INotifyNestedPropertyChanging>(value).NestedPropertyChanging -= nestedPropertyChanging;
                Unsafe.As<INotifyPropertyChanging>(value).PropertyChanging -= propertyChanging;
            }
            else if (TNotifierTypeDescription.HasDescriptionFlag(NotifierTypeDescription.PropertyChanging))
            {
                Unsafe.As<INotifyPropertyChanging>(value).PropertyChanging -= propertyChanging;
            }

            if (TNotifierTypeDescription.HasDescriptionFlag(NotifierTypeDescription.NestedPropertyChanged))
            {
                Unsafe.As<INotifyNestedPropertyChanged>(value).NestedPropertyChanged -= nestedPropertyChanged;
                Unsafe.As<INotifyPropertyChanged>(value).PropertyChanged -= propertyChanged;
            }
            else if (TNotifierTypeDescription.HasDescriptionFlag(NotifierTypeDescription.PropertyChanged))
            {
                Unsafe.As<INotifyPropertyChanged>(value).PropertyChanged -= propertyChanged;
            }
        }
    }
}

/// <summary>
/// A class containing helper methods for subscribing to and unsubscribing from property change notification events
/// implemented by a given generic reference type.
/// </summary>
/// 
/// <remarks>
/// This class can be useful when extending <see cref="NestedObservableObject"/> and attempting to yield accurate
/// nested property change notifications on a generic reference type property that may not be known to implement
/// property change notifications.
/// </remarks>
public static class GenericPropertyChange
{
    /// <summary>
    /// Shuffles the events subscribed to from an old <typeparamref name="TNotifier"/> value to a new
    /// <typeparamref name="TNotifier"/> value, according to the property change notifications implemented by the type.
    /// </summary>
    /// 
    /// <remarks>
    /// This method assumes that it is sufficient to subscribe to nested events rather than their singular
    /// counterparts if possible; e.g. if <typeparamref name="TNotifier"/> implements
    /// <see cref="INotifyNestedPropertyChanged"/>, then the method will subscribe to the
    /// <see cref="INotifyNestedPropertyChanged.NestedPropertyChanged"/> event and ignore the
    /// <see cref="INotifyPropertyChanged.PropertyChanged"/> event inherited by that interface.
    /// </remarks>
    /// 
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    /// <param name="propertyChanging"></param>
    /// <param name="propertyChanged"></param>
    /// <param name="nestedPropertyChanging"></param>
    /// <param name="nestedPropertyChanged"></param>
    /// <param name="ignoreSingularIfNested">
    /// Whether or not to ignore singular (<see cref="INotifyPropertyChanging"/>, <see cref="INotifyPropertyChanged"/>)
    /// interfaces when subscribing if their nested analogs are implemented.
    /// </param>
    /// 
    /// <typeparam name="TNotifier">
    /// The generic reference type that potentially exposes property change events that this method can be used to
    /// subscribe to and unsubscribe from.
    /// </typeparam>
    public static void ShuffleHandlers<TNotifier>(
        TNotifier? oldValue, TNotifier? newValue,
        PropertyChangingEventHandler? propertyChanging,
        PropertyChangedEventHandler? propertyChanged,
        NestedPropertyChangingEventHandler? nestedPropertyChanging,
        NestedPropertyChangedEventHandler? nestedPropertyChanged,
        bool ignoreSingularIfNested = true)
        where TNotifier : class
    {
        // Unsubscribe from any relevant event handlers on the old value
        UnsubscribeFrom(oldValue, propertyChanging, propertyChanged, nestedPropertyChanging, nestedPropertyChanged);

        // Subscribe to any relevant event handlers on the new value
        SubscribeTo(
            newValue,
            propertyChanging, propertyChanged, nestedPropertyChanging, nestedPropertyChanged,
            ignoreSingularIfNested);
    }

    /// <summary>
    /// Subscribes to any relevant property change events on the <typeparamref name="TNotifier"/> value passed in.
    /// </summary>
    /// 
    /// <param name="value"></param>
    /// <param name="propertyChanging"></param>
    /// <param name="propertyChanged"></param>
    /// <param name="nestedPropertyChanging"></param>
    /// <param name="nestedPropertyChanged"></param>
    /// <param name="ignoreSingularIfNested">
    /// Whether or not to ignore singular (<see cref="INotifyPropertyChanging"/>, <see cref="INotifyPropertyChanged"/>)
    /// interfaces when subscribing if their nested analogs are implemented.
    /// </param>
    /// 
    /// <typeparam name="TNotifier">
    /// The generic reference type that potentially exposes property change events that this method can be used to
    /// subscribe to.
    /// </typeparam>
    public static void SubscribeTo<TNotifier>(
        TNotifier? value,
        PropertyChangingEventHandler? propertyChanging,
        PropertyChangedEventHandler? propertyChanged,
        NestedPropertyChangingEventHandler? nestedPropertyChanging,
        NestedPropertyChangedEventHandler? nestedPropertyChanged,
        bool ignoreSingularIfNested = true)
        where TNotifier : class
        => GenericPropertyChangeNotifier<TNotifier>.SubscribeTo(
            value,
            propertyChanging, propertyChanged, nestedPropertyChanging, nestedPropertyChanged,
            ignoreSingularIfNested);

    /// <summary>
    /// Unsubscribes from any relevant property change events on the <typeparamref name="TNotifier"/> value passed in.
    /// </summary>
    /// 
    /// <param name="value"></param>
    /// <param name="propertyChanging"></param>
    /// <param name="propertyChanged"></param>
    /// <param name="nestedPropertyChanging"></param>
    /// <param name="nestedPropertyChanged"></param>
    /// 
    /// <typeparam name="TNotifier">
    /// The generic reference type that potentially exposes property change events that this method can be used to
    /// unsubscribe from.
    /// </typeparam>
    public static void UnsubscribeFrom<TNotifier>(
        TNotifier? value,
        PropertyChangingEventHandler? propertyChanging,
        PropertyChangedEventHandler? propertyChanged,
        NestedPropertyChangingEventHandler? nestedPropertyChanging,
        NestedPropertyChangedEventHandler? nestedPropertyChanged)
        where TNotifier : class
        => GenericPropertyChangeNotifier<TNotifier>.UnsubscribeFrom(
            value,
            propertyChanging, propertyChanged, nestedPropertyChanging, nestedPropertyChanged);

    /// <summary>
    /// Describes the type of property changes implemented by a given type.
    /// </summary>
    /// <remarks>
    /// This enum respects the interface design of nested property change notifications; i.e. the
    /// <see cref="NestedPropertyChanged"/> value has the <see cref="PropertyChanged"/> flag set because the
    /// <see cref="INotifyNestedPropertyChanged"/> interface extends the <see cref="INotifyPropertyChanged"/>
    /// interface.
    /// </remarks>
    internal enum NotifierTypeDescription : byte
    {
        /// <summary>
        /// The type does not implement any property change notifications.
        /// </summary>
        None = 0,

        /// <summary>
        /// The type implements <see cref="INotifyPropertyChanging"/>.
        /// </summary>
        PropertyChanging = 1,

        /// <summary>
        /// The type implements <see cref="INotifyPropertyChanged"/>.
        /// </summary>
        PropertyChanged = 2,

        /// <summary>
        /// The type implements <see cref="INotifyNestedPropertyChanging"/> (and therefore
        /// also <see cref="INotifyPropertyChanging"/>).
        /// </summary>
        NestedPropertyChanging = PropertyChanging | 4,

        /// <summary>
        /// The type implements <see cref="INotifyNestedPropertyChanged"/> (and therefore
        /// also <see cref="INotifyPropertyChanged"/>).
        /// </summary>
        NestedPropertyChanged = PropertyChanged | 8,

        /// <summary>
        /// The type extends <see cref="NestedObservableObject"/>, and therefore implements
        /// both <see cref="INotifyNestedPropertyChanging"/> and <see cref="INotifyNestedPropertyChanged"/>, and the
        /// <see cref="ObservableObject.PropertyChanging"/> and <see cref="ObservableObject.PropertyChanged"/> events
        /// are guaranteed to fire <see cref="NestedObservableObject.NestedPropertyChanging"/> and
        /// <see cref="NestedObservableObject.NestedPropertyChanged"/> events, respectively.
        /// </summary>
        /// <remarks>
        /// This is useful information, as a generic subscriber can subscribe to only the object's nested property
        /// change handlers and trust that these will yield complete information about the changes happening in
        /// the object.
        /// </remarks>
        NestedObservableObject = NestedPropertyChanging | NestedPropertyChanged | 16,
    }

    /// <summary>
    /// A more efficient verison of <see cref="Enum.HasFlag(Enum)"/> for the
    /// <see cref="NotifierTypeDescription"/> enum.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="flag"></param>
    /// <returns></returns>
    internal static bool HasDescriptionFlag(this NotifierTypeDescription value, NotifierTypeDescription flag)
        => (value & flag) == flag;
}
#endregion
#endregion

#region Interfaces
/// <summary>
/// An interface for objects that notify when nested properties have changed.
/// </summary>
public interface INotifyNestedPropertyChanged : INotifyPropertyChanged
{
    /// <summary>
    /// Occurs when a nested property changes.
    /// </summary>
    public event NestedPropertyChangedEventHandler? NestedPropertyChanged;
}

/// <summary>
/// An interface for objects that notify when nested properties are changing.
/// </summary>
public interface INotifyNestedPropertyChanging : INotifyPropertyChanging
{
    /// <summary>
    /// Occurs when a nested property is changing.
    /// </summary>
    public event NestedPropertyChangingEventHandler? NestedPropertyChanging;
}
#endregion

#region Event Handler Delegates
/// <summary>
/// An event indicating that a nested property is changing.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
public delegate void NestedPropertyChangingEventHandler(object sender, NestedPropertyChangingEventArgs e);

/// <summary>
/// An event indicating that a nested property has changed.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
public delegate void NestedPropertyChangedEventHandler(object sender, NestedPropertyChangedEventArgs e);
#endregion

#region Event Arguments
/// <summary>
/// An event argument class that describes a nested property changed event.
/// </summary>
public class NestedPropertyChangingEventArgs : NestedPropertyChangeEventArgs
{
    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangingEventArgs"/> class with the property
    /// name passed in.
    /// </summary>
    /// <param name="PropertyName"></param>
    public NestedPropertyChangingEventArgs(string PropertyName) : base(PropertyName) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangingEventArgs"/> class with the property
    /// path passed in.
    /// </summary>
    /// <param name="PropertyPath"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="PropertyPath"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="PropertyPath"/> was empty.
    /// </exception>
    public NestedPropertyChangingEventArgs(IEnumerable<string> PropertyPath) : base(PropertyPath) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangingEventArgs"/> class with the property
    /// path passed in.
    /// </summary>
    /// <param name="PropertyPath"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="PropertyPath"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="PropertyPath"/> was empty.
    /// </exception>
    public NestedPropertyChangingEventArgs(ImmutableStack<string> PropertyPath) : base(PropertyPath) { }
}

/// <summary>
/// An event argument class that describes a nested property changed event.
/// </summary>
public class NestedPropertyChangedEventArgs : NestedPropertyChangeEventArgs
{
    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangedEventArgs"/> class with the property
    /// name passed in.
    /// </summary>
    /// <param name="PropertyName"></param>
    public NestedPropertyChangedEventArgs(string PropertyName) : base(PropertyName) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangedEventArgs"/> class with the property
    /// path passed in.
    /// </summary>
    /// <param name="PropertyPath"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="PropertyPath"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="PropertyPath"/> was empty.
    /// </exception>
    public NestedPropertyChangedEventArgs(IEnumerable<string> PropertyPath) : base(PropertyPath) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangedEventArgs"/> class with the property
    /// path passed in.
    /// </summary>
    /// <param name="PropertyPath"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="PropertyPath"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="PropertyPath"/> was empty.
    /// </exception>
    public NestedPropertyChangedEventArgs(ImmutableStack<string> PropertyPath) : base(PropertyPath) { }
}

/// <summary>
/// A base class for event arguments that describe a nested property change.
/// </summary>
public abstract class NestedPropertyChangeEventArgs : EventArgs
{
    /// <summary>
    /// The path of the property for which the change occurs.
    /// </summary>
    public ImmutableStack<string> PropertyPath { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangeEventArgs"/> class with the property
    /// name passed in.
    /// </summary>
    /// <param name="PropertyName"></param>
    private protected NestedPropertyChangeEventArgs(string PropertyName) : this(ImmutableStack.Create(PropertyName)) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangeEventArgs"/> class with the property
    /// path passed in.
    /// </summary>
    /// <param name="PropertyPath"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="PropertyPath"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="PropertyPath"/> was empty.
    /// </exception>
    private protected NestedPropertyChangeEventArgs(IEnumerable<string> PropertyPath)
        : this(ImmutableStack.CreateRange(PropertyPath.Reverse())) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="NestedPropertyChangeEventArgs"/> class with the property
    /// path passed in.
    /// </summary>
    /// <param name="PropertyPath"></param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="PropertyPath"/> was <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="PropertyPath"/> was empty.
    /// </exception>
    private protected NestedPropertyChangeEventArgs(ImmutableStack<string> PropertyPath)
    {
        if (PropertyPath is null) throw new ArgumentNullException(nameof(PropertyPath));
        if (PropertyPath.IsEmpty) throw new ArgumentException(
            $"Cannot construct a {nameof(NestedPropertyChangeEventArgs)} instance with an empty property path.");
        this.PropertyPath = PropertyPath;
    }

    /// <summary>
    /// Determines if the change described by these event arguments implies the change described by the property
    /// path passed in.
    /// </summary>
    /// <param name="otherPropertyPath"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="otherPropertyPath"/> was <see langword="null"/>.
    /// </exception>
    public bool ImpliesChangeOf(params string[] otherPropertyPath)
        => ImpliesChangeOf(otherPropertyPath as IEnumerable<string>);

    /// <summary>
    /// Determines if the change described by these event arguments implies the change described by the property
    /// path passed in.
    /// </summary>
    /// <param name="otherPropertyPath"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="otherPropertyPath"/> was <see langword="null"/>.
    /// </exception>
    public bool ImpliesChangeOf(IEnumerable<string> otherPropertyPath)
        => PathImpliesChangeOf(
            PropertyPath,
            otherPropertyPath ?? throw new ArgumentNullException(nameof(otherPropertyPath)));

    /// <summary>
    /// Determines if the change described by the property path passed in implies the change described by these
    /// event arguments.
    /// </summary>
    /// <param name="otherPropertyPath"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="otherPropertyPath"/> was <see langword="null"/>.
    /// </exception>
    public bool ChangeImpliedBy(params string[] otherPropertyPath)
        => ChangeImpliedBy(otherPropertyPath as IEnumerable<string>);

    /// <summary>
    /// Determines if the change described by the property path passed in implies the change described by these
    /// event arguments.
    /// </summary>
    /// <param name="otherPropertyPath"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="otherPropertyPath"/> was <see langword="null"/>.
    /// </exception>
    public bool ChangeImpliedBy(IEnumerable<string> otherPropertyPath)
        => PathImpliesChangeOf(
            otherPropertyPath ?? throw new ArgumentNullException(nameof(otherPropertyPath)),
            PropertyPath);

    private static bool PathImpliesChangeOf(IEnumerable<string> lhs, IEnumerable<string> rhs)
        // If the left property path is a substack of the right, then the property change described by the left
        // path implies the change described by the right since the right path describes a child property of the
        // property described by the left
        => PartialComparePaths(lhs, rhs) <= 0;

    /// <summary>
    /// Compares the two property paths passed in starting at the top and moving down.
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns>
    /// An integer describing a subset, superset or equality relationship between the paths, or <see langword="null"/>
    /// if the paths do not share such a relationship.
    /// </returns>
    private static int? PartialComparePaths(IEnumerable<string> lhs, IEnumerable<string> rhs)
    {
        using var leftEnum = lhs.GetEnumerator();
        using var rightEnum = rhs.GetEnumerator();

        while (true)
        {
            bool leftHasNext = leftEnum.MoveNext(), rightHasNext = rightEnum.MoveNext();
            if (leftHasNext)
            {
                if (rightHasNext)
                {
                    if (leftEnum.Current != rightEnum.Current) return null; // Elements do not agree
                    else continue;
                }
                else return 1; // Left stack is longer than right
            }
            else if (rightHasNext) return -1; // Right stack is longer than left
            else return 0; // Both ended at the same time
        }
    }
}
#endregion

