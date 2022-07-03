using Rem.CoreUtils.CodeAnalysis.Numerical;
using Rem.CoreUtils.ComponentModel;
using Rem.CoreUtils.Numerics;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rem.CoreUtils.Helpers.Throw;

/// <summary>
/// A series of extension methods offering a simple fluent API for throwing exceptions relating to invalid
/// numerical values.
/// </summary>
public static class BasicNumericThrowerExtensions
{
    #region Signs
    #region Signs.Byte
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static byte IfArgZero(this IBasicNumericThrower _, byte argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static byte IfPropSetZero(
        this IBasicNumericThrower _,
        byte propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;
    #endregion

    #region Signs.SByte
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static sbyte IfArgNegative(this IBasicNumericThrower _, sbyte argValue, string argName, string? message = null)
        => argValue < 0
            ? throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value cannot be negative.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static sbyte IfArgNotPositive(
        this IBasicNumericThrower _, sbyte argValue, string argName, string? message = null)
        => argValue > 0
            ? argValue
            : throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static sbyte IfArgZero(this IBasicNumericThrower _, sbyte argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static sbyte IfArgNotNegative(
        this IBasicNumericThrower _, sbyte argValue, string argName, string? message = null)
        => argValue < 0
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static sbyte IfArgPositive(this IBasicNumericThrower _, sbyte argValue, string argName, string? message = null)
        => argValue > 0
            ? throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value cannot be positive.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static sbyte IfPropSetNegative(
        this IBasicNumericThrower _, sbyte propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be negative.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static sbyte IfPropSetNotPositive(
        this IBasicNumericThrower _, sbyte propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static sbyte IfPropSetZero(
        this IBasicNumericThrower _, sbyte propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static sbyte IfPropSetNotNegative(
        this IBasicNumericThrower _, sbyte propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static sbyte IfPropSetPositive(
        this IBasicNumericThrower _, sbyte propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be positive.")
            : propSetValue;
    #endregion

    #region Signs.Short
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static short IfArgNegative(this IBasicNumericThrower _, short argValue, string argName, string? message = null)
        => argValue < 0
            ? throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value cannot be negative.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static short IfArgNotPositive(
        this IBasicNumericThrower _, short argValue, string argName, string? message = null)
        => argValue > 0
            ? argValue
            : throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static short IfArgZero(this IBasicNumericThrower _, short argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static short IfArgNotNegative(
        this IBasicNumericThrower _, short argValue, string argName, string? message = null)
        => argValue < 0
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static short IfArgPositive(this IBasicNumericThrower _, short argValue, string argName, string? message = null)
        => argValue > 0
            ? throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value cannot be positive.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static short IfPropSetNegative(
        this IBasicNumericThrower _, short propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be negative.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static short IfPropSetNotPositive(
        this IBasicNumericThrower _, short propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static short IfPropSetZero(
        this IBasicNumericThrower _, short propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static short IfPropSetNotNegative(
        this IBasicNumericThrower _, short propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static short IfPropSetPositive(
        this IBasicNumericThrower _, short propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be positive.")
            : propSetValue;
    #endregion

    #region Signs.UShort
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static ushort IfArgZero(
        this IBasicNumericThrower _, ushort argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static ushort IfPropSetZero(
        this IBasicNumericThrower _, ushort propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;
    #endregion

    #region Signs.Int
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static int IfArgNegative(this IBasicNumericThrower _, int argValue, string argName, string? message = null)
        => argValue < 0
            ? throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value cannot be negative.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static int IfArgNotPositive(this IBasicNumericThrower _, int argValue, string argName, string? message = null)
        => argValue > 0
            ? argValue
            : throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static int IfArgZero(this IBasicNumericThrower _, int argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static int IfArgNotNegative(this IBasicNumericThrower _, int argValue, string argName, string? message = null)
        => argValue < 0
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static int IfArgPositive(this IBasicNumericThrower _, int argValue, string argName, string? message = null)
        => argValue > 0
            ? throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value cannot be positive.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static int IfPropSetNegative(
        this IBasicNumericThrower _, int propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be negative.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static int IfPropSetNotPositive(
        this IBasicNumericThrower _, int propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static int IfPropSetZero(this IBasicNumericThrower _, int propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static int IfPropSetNotNegative(
        this IBasicNumericThrower _, int propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static int IfPropSetPositive(
        this IBasicNumericThrower _, int propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be positive.")
            : propSetValue;
    #endregion

    #region Signs.UInt
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static uint IfArgZero(this IBasicNumericThrower _, uint argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static uint IfPropSetZero(this IBasicNumericThrower _, uint propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;
    #endregion

    #region Signs.Long
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static long IfArgNegative(this IBasicNumericThrower _, long argValue, string argName, string? message = null)
        => argValue < 0
            ? throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value cannot be negative.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static long IfArgNotPositive(this IBasicNumericThrower _, long argValue, string argName, string? message = null)
        => argValue > 0
            ? argValue
            : throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static long IfArgZero(this IBasicNumericThrower _, long argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static long IfArgNotNegative(this IBasicNumericThrower _, long argValue, string argName, string? message = null)
        => argValue < 0
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static long IfArgPositive(this IBasicNumericThrower _, long argValue, string argName, string? message = null)
        => argValue > 0
            ? throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value cannot be positive.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static long IfPropSetNegative(
        this IBasicNumericThrower _, long propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be negative.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static long IfPropSetNotPositive(
        this IBasicNumericThrower _, long propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static long IfPropSetZero(
        this IBasicNumericThrower _, long propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static long IfPropSetNotNegative(
        this IBasicNumericThrower _, long propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static long IfPropSetPositive(
        this IBasicNumericThrower _, long propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be positive.")
            : propSetValue;
    #endregion

    #region Signs.ULong
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static ulong IfArgZero(this IBasicNumericThrower _, ulong argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static ulong IfPropSetZero(
        this IBasicNumericThrower _, ulong propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;
    #endregion

    #region Signs.Float
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static float IfArgNegative(this IBasicNumericThrower _, float argValue, string argName, string? message = null)
        => argValue < 0
            ? throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value cannot be negative.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static float IfArgNotPositive(
        this IBasicNumericThrower _, float argValue, string argName, string? message = null)
        => argValue > 0
            ? argValue
            : throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static float IfArgZero(this IBasicNumericThrower _, float argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static float IfArgNotNegative(
        this IBasicNumericThrower _, float argValue, string argName, string? message = null)
        => argValue < 0
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static float IfArgPositive(this IBasicNumericThrower _, float argValue, string argName, string? message = null)
        => argValue > 0
            ? throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value cannot be positive.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is not finite.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not finite.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Finite]
    public static float IfArgNotFinite(this IBasicNumericThrower _, float argValue, string argName, string? message = null)
        => Floats.IsFinite(argValue)
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be finite.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is not a number
    /// (<see cref="float.NaN"/>).
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not a number.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNaN]
    public static float IfArgNaN(this IBasicNumericThrower _, float argValue, string argName, string? message = null)
        => float.IsNaN(argValue)
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be NaN.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static float IfPropSetNegative(
        this IBasicNumericThrower _, float propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be negative.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static float IfPropSetNotPositive(
        this IBasicNumericThrower _, float propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static float IfPropSetZero(
        this IBasicNumericThrower _, float propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static float IfPropSetNotNegative(
        this IBasicNumericThrower _, float propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static float IfPropSetPositive(
        this IBasicNumericThrower _, float propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be positive.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is not finite.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not finite.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Finite]
    public static float IfPropSetNotFinite(
        this IBasicNumericThrower _, float propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => Floats.IsFinite(propSetValue)
            ? propSetValue
            : throw new PropertySetOutOfRangeException(propName!, propSetValue, message ?? "Value must be finite.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the argument value passed in is not a number
    /// (<see cref="float.NaN"/>).
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not a number.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNaN]
    public static float IfPropSetNaN(
        this IBasicNumericThrower _, float propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => float.IsNaN(propSetValue)
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be NaN.")
            : propSetValue;
    #endregion

    #region Signs.Double
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static double IfArgNegative(this IBasicNumericThrower _, double argValue, string argName, string? message = null)
        => argValue < 0
            ? throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value cannot be negative.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static double IfArgNotPositive(
        this IBasicNumericThrower _, double argValue, string argName, string? message = null)
        => argValue > 0
            ? argValue
            : throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static double IfArgZero(this IBasicNumericThrower _, double argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static double IfArgNotNegative(
        this IBasicNumericThrower _, double argValue, string argName, string? message = null)
        => argValue < 0
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static double IfArgPositive(this IBasicNumericThrower _, double argValue, string argName, string? message = null)
        => argValue > 0
            ? throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value cannot be positive.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is not finite.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not finite.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Finite]
    public static double IfArgNotFinite(
        this IBasicNumericThrower _, double argValue, string argName, string? message = null)
        => Doubles.IsFinite(argValue)
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be finite.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is not a number
    /// (<see cref="double.NaN"/>).
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not a number.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNaN]
    public static double IfArgNaN(this IBasicNumericThrower _, double argValue, string argName, string? message = null)
        => double.IsNaN(argValue)
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be NaN.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static double IfPropSetNegative(
        this IBasicNumericThrower _, double propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be negative.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static double IfPropSetNotPositive(
        this IBasicNumericThrower _, double propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static double IfPropSetZero(
        this IBasicNumericThrower _, double propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static double IfPropSetNotNegative(
        this IBasicNumericThrower _, double propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static double IfPropSetPositive(
        this IBasicNumericThrower _, double propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be positive.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is not finite.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not finite.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Finite]
    public static double IfPropSetNotFinite(
        this IBasicNumericThrower _, double propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => Doubles.IsFinite(propSetValue)
            ? propSetValue
            : throw new PropertySetOutOfRangeException(propName!, propSetValue, message ?? "Value must be finite.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the argument value passed in is not a number
    /// (<see cref="double.NaN"/>).
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not a number.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNaN]
    public static double IfPropSetNaN(
        this IBasicNumericThrower _, double propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => double.IsNaN(propSetValue)
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be NaN.")
            : propSetValue;
    #endregion

    #region Signs.Decimal
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static decimal IfArgNegative(
        this IBasicNumericThrower _, decimal argValue, string argName, string? message = null)
        => argValue < 0
            ? throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value cannot be negative.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static decimal IfArgNotPositive(
        this IBasicNumericThrower _, decimal argValue, string argName, string? message = null)
        => argValue > 0
            ? argValue
            : throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static decimal IfArgZero(
        this IBasicNumericThrower _, decimal argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static decimal IfArgNotNegative(
        this IBasicNumericThrower _, decimal argValue, string argName, string? message = null)
        => argValue < 0
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static decimal IfArgPositive(
        this IBasicNumericThrower _, decimal argValue, string argName, string? message = null)
        => argValue > 0
            ? throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value cannot be positive.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static decimal IfPropSetNegative(
        this IBasicNumericThrower _, decimal propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be negative.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static decimal IfPropSetNotPositive(
        this IBasicNumericThrower _, decimal propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static decimal IfPropSetZero(
        this IBasicNumericThrower _, decimal propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static decimal IfPropSetNotNegative(
        this IBasicNumericThrower _, decimal propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static decimal IfPropSetPositive(
        this IBasicNumericThrower _, decimal propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be positive.")
            : propSetValue;
    #endregion

    #region Signs.BigInteger
    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static BigInteger IfArgNegative(
        this IBasicNumericThrower _, in BigInteger argValue, string argName, string? message = null)
        => argValue < 0
            ? throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value cannot be negative.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static BigInteger IfArgNotPositive(
        this IBasicNumericThrower _, in BigInteger argValue, string argName, string? message = null)
        => argValue > 0
            ? argValue
            : throw new ArgumentOutOfRangeException(
                argName, argValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is zero.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static BigInteger IfArgZero(
        this IBasicNumericThrower _, in BigInteger argValue, string argName, string? message = null)
        => argValue == 0
            ? throw new ArgumentOutOfRangeException(argName, message ?? "Value cannot be zero.")
            : argValue;

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is non-negative.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static BigInteger IfArgNotNegative(
        this IBasicNumericThrower _, in BigInteger argValue, string argName, string? message = null)
        => argValue < 0
            ? argValue
            : throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws an <see cref="ArgumentOutOfRangeException"/> if the argument value passed in is positive.
    /// </summary>
    /// <param name="argValue">The value of the argument.</param>
    /// <param name="argName">The name of the argument.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="ArgumentOutOfRangeException">The argument value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static BigInteger IfArgPositive(
        this IBasicNumericThrower _, in BigInteger argValue, string argName, string? message = null)
        => argValue > 0
            ? throw new ArgumentOutOfRangeException(argName, argValue, message ?? "Value cannot be positive.")
            : argValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonNegative]
    public static BigInteger IfPropSetNegative(
        this IBasicNumericThrower _, in BigInteger propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be negative.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Positive]
    public static BigInteger IfPropSetNotPositive(
        this IBasicNumericThrower _, in BigInteger propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be positive.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is zero.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was zero.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonZero]
    public static BigInteger IfPropSetZero(
        this IBasicNumericThrower _, in BigInteger propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue == 0
            ? throw new PropertySetOutOfRangeException(propName!, message ?? "Value cannot be zero.")
            : propSetValue;

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is non-negative.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was not negative.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: Negative]
    public static BigInteger IfPropSetNotNegative(
        this IBasicNumericThrower _, in BigInteger propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue < 0
            ? propSetValue
            : throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value must be negative.");

    /// <summary>
    /// Throws a <see cref="PropertySetOutOfRangeException"/> if the property set value passed in is positive.
    /// </summary>
    /// <param name="propSetValue">The value the property is being set to.</param>
    /// <param name="propName">The name of the property.</param>
    /// <param name="message">
    /// An optional message to construct the exception with, or <see langword="null"/> to use a default message.
    /// </param>
    /// <returns>The value passed in.</returns>
    /// <exception cref="PropertySetOutOfRangeException">The property set value was positive.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NonPositive]
    public static BigInteger IfPropSetPositive(
        this IBasicNumericThrower _, in BigInteger propSetValue, [CallerMemberName] string? propName = null, string? message = null)
        => propSetValue > 0
            ? throw new PropertySetOutOfRangeException(
                propName!, propSetValue, message ?? "Value cannot be positive.")
            : propSetValue;
    #endregion
    #endregion
}

/// <summary>
/// An interface allowing access to the extension methods in <see cref="BasicNumericThrowerExtensions"/>.
/// </summary>
public interface IBasicNumericThrower { }
