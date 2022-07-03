using Rem.CoreUtils.CodeAnalysis;
using Rem.CoreUtils.ComponentModel;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rem.CoreUtils.Helpers.Throw;

/// <summary>
/// A series of extension methods offering a simple fluent API for throwing exceptions relating to comparable values.
/// </summary>
public static class BasicComparisonThrowerExtensions
{
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is greater than the maximum
    /// value passed in.
    /// </summary>
    /// <param name="max">The maximum value to check against.</param>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The argument value was greater than the maximum.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: LessThanOrEqualToParameter("max")]
    public static TNumber IfArgGreaterThan<TNumber>(
        this IBasicNumericThrower _, in TNumber max, in TNumber argValue, string argName, string? message = null)
        where TNumber : IComparable<TNumber>
        => argValue.CompareTo(max) > 0
            ? throw new ArgumentOutOfRangeException(
                argName,
                argValue,
                message ?? $"Value must be greater than {max}.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is greater than or equal
    /// to the maximum value passed in.
    /// </summary>
    /// <param name="max">The maximum value to check against.</param>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The argument value was greater than or equal to the maximum.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: LessThanParameter("max")]
    public static TNumber IfArgGreaterThanOrEqualTo<TNumber>(
        this IBasicNumericThrower _, in TNumber max, in TNumber argValue, string argName, string? message = null)
        where TNumber : IComparable<TNumber>
        => argValue.CompareTo(max) >= 0
            ? throw new ArgumentOutOfRangeException(
                argName,
                argValue,
                message ?? $"Value must be greater than {max}.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is less than or equal
    /// to the minimum value passed in.
    /// </summary>
    /// <param name="min">The minimum value to check against.</param>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The argument value was less than or equal to the minimum.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: GreaterThanParameter("min")]
    public static TNumber IfArgLessThanOrEqualTo<TNumber>(
        this IBasicNumericThrower _, in TNumber min, in TNumber argValue, string argName, string? message = null)
        where TNumber : IComparable<TNumber>
        => argValue.CompareTo(min) <= 0
            ? throw new ArgumentOutOfRangeException(
                argName,
                argValue,
                message ?? $"Value must be greater than {min}.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is less than the minimum
    /// value passed in.
    /// </summary>
    /// <param name="min">The minimum value to check against.</param>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The argument value was less than the minimum.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: GreaterThanOrEqualToParameter("min")]
    public static TNumber IfArgLessThan<TNumber>(
        this IBasicNumericThrower _, in TNumber min, in TNumber argValue, string argName, string? message = null)
        where TNumber : IComparable<TNumber>
        => argValue.CompareTo(min) < 0
            ? throw new ArgumentOutOfRangeException(
                argName,
                argValue,
                message ?? $"Value must be greater than {min}.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is greater than the
    /// maximum value passed in.
    /// </summary>
    /// <param name="max">The maximum value to check against.</param>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">
    /// The property set value was greater than the maximum.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: LessThanOrEqualToParameter("max")]
    public static TNumber IfPropSetGreaterThan<TNumber>(
        this IBasicNumericThrower _,
        in TNumber max, in TNumber propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        where TNumber : IComparable<TNumber>
        => propSetValue.CompareTo(max) > 0
            ? throw new PropertySetOutOfRangeException(
                propName!,
                propSetValue,
                message ?? $"Value must be greater than {max}.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is greater than or
    /// equal to the maximum value passed in.
    /// </summary>
    /// <param name="max">The maximum value to check against.</param>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">
    /// The property set value was greater than or equal to the maximum.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: LessThanParameter("max")]
    public static TNumber IfPropSetGreaterThanOrEqualTo<TNumber>(
        this IBasicNumericThrower _,
        in TNumber max, in TNumber propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        where TNumber : IComparable<TNumber>
        => propSetValue.CompareTo(max) >= 0
            ? throw new PropertySetOutOfRangeException(
                propName!,
                propSetValue,
                message ?? $"Value must be greater than {max}.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is less than or equal
    /// to the minimum value passed in.
    /// </summary>
    /// <param name="min">The minimum value to check against.</param>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">
    /// The property set value was less than or equal to the minimum.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: GreaterThanParameter("min")]
    public static TNumber IfPropSetLessThanOrEqualTo<TNumber>(
        this IBasicNumericThrower _,
        in TNumber min, in TNumber propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        where TNumber : IComparable<TNumber>
        => propSetValue.CompareTo(min) <= 0
            ? throw new PropertySetOutOfRangeException(
                propName!,
                propSetValue,
                message ?? $"Value must be greater than {min}.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is less than the
    /// minimum value passed in.
    /// </summary>
    /// <param name="min">The minimum value to check against.</param>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// The property set value was less than the minimum.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: GreaterThanOrEqualToParameter("min")]
    public static TNumber IfPropSetLessThan<TNumber>(
        this IBasicNumericThrower _,
        in TNumber min, in TNumber propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        where TNumber : IComparable<TNumber>
        => propSetValue.CompareTo(min) < 0
            ? throw new PropertySetOutOfRangeException(
                propName!,
                propSetValue,
                message ?? $"Value must be greater than {min}.")
            : propSetValue;
}

/// <summary>
/// An interface allowing access to the extension methods in <see cref="BasicComparisonThrowerExtensions"/>.
/// </summary>
public interface IBasicComparisonThrower { }

