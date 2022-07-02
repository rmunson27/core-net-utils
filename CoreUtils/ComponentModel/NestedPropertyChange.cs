using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Rem.CoreUtils.ComponentModel;

#region Classes
/// <summary>
/// A base class for objects that notify of nested property changes.
/// </summary>
public abstract class NestedObservableObject
    : ObservableObject, INotifyNestedPropertyChanged, INotifyNestedPropertyChanging
{
    #region Events
    /// <inheritdoc cref="INotifyNestedPropertyChanged.NestedPropertyChanged"/>
    public event NestedPropertyChangedEventHandler? NestedPropertyChanged;

    /// <inheritdoc cref="INotifyNestedPropertyChanging.NestedPropertyChanging"/>
    public event NestedPropertyChangingEventHandler? NestedPropertyChanging;
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

    #region EventHandler Building Helpers
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
        OnNestedPropertyChanging(new(ImmutableStack.CreateRange(new[] { e.PropertyName, childPropertyName })));
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
        OnNestedPropertyChanged(new(ImmutableStack.CreateRange(new[] { e.PropertyName, childPropertyName })));
    }
    #endregion

    #region Event Triggers
    /// <summary>
    /// Raises the <see cref="ObservableObject.PropertyChanging"/> event, also raising the
    /// <see cref="NestedPropertyChanging"/> event with the property name supplied by the event arguments.
    /// </summary>
    /// <remarks>
    /// This method will not raise the <see cref="NestedPropertyChanging"/> event if the property name supplied by
    /// the event arguments is <see langword="null"/>.
    /// </remarks>
    /// <param name="e"></param>
    protected override void OnPropertyChanging(PropertyChangingEventArgs e)
    {
        base.OnPropertyChanging(e);
        if (e.PropertyName is not null) OnNestedPropertyChanging(new(e.PropertyName));
    }

    /// <summary>
    /// Raises the <see cref="NestedPropertyChanging"/> event.
    /// </summary>
    /// <param name="e"></param>
    protected virtual void OnNestedPropertyChanging(NestedPropertyChangingEventArgs e)
    {
        NestedPropertyChanging?.Invoke(this, e);
    }


    /// <summary>
    /// Raises the <see cref="ObservableObject.PropertyChanged"/> event, also raising the
    /// <see cref="NestedPropertyChanged"/> event with the property name supplied by the event arguments.
    /// </summary>
    /// <remarks>
    /// This method will not raise the <see cref="NestedPropertyChanged"/> event if the property name supplied by
    /// the event arguments is <see langword="null"/>.
    /// </remarks>
    /// <param name="e"></param>
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        if (e.PropertyName is not null) OnNestedPropertyChanged(new(e.PropertyName));
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

#region Event Handlers
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

