using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rem.CoreUtils;

/// <summary>
/// Represents a simple reference to a value of any type.
/// </summary>
/// <remarks>
/// This class can be useful when dealing with cases in which a <see langword="ref"/> parameter is not allowed, such
/// as passing an argument by reference when using an async method.
/// </remarks>
/// <typeparam name="T"></typeparam>
public sealed class Ref<T> : ObservableObject
{
    /// <summary>
    /// Gets or sets the value wrapped in this reference.
    /// </summary>
    public T Value
    {
        get => _value;
        set => SetProperty(ref _value, value);
    }
    private T _value;

    /// <summary>
    /// Constructs a new instance of the <see cref="Ref{T}"/> class wrapping the initial value passed in.
    /// </summary>
    /// <param name="initialValue"></param>
    public Ref(T initialValue)
    {
        _value = initialValue;
    }
}
