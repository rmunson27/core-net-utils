using Rem.CoreUtils.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Rem.CoreUtils.Helpers;

/// <summary>
/// Constants and static functionality relating to enum types.
/// </summary>
/// <remarks>
/// This class offers methods for efficiently comparing and operating on enums of a given yet possibly unknown
/// type, as well as providing more efficient defined checks and value obtaining than is provided by .NET standard.
/// </remarks>
public static class Enums
{
    private static readonly Dictionary<Type, EnumUnderlyingType> UnderlyingTypeMap;

    static Enums()
    {
        UnderlyingTypeMap = new(8);
        UnderlyingTypeMap.Add(typeof(byte), EnumUnderlyingType.Byte);
        UnderlyingTypeMap.Add(typeof(sbyte), EnumUnderlyingType.SByte);
        UnderlyingTypeMap.Add(typeof(short), EnumUnderlyingType.Short);
        UnderlyingTypeMap.Add(typeof(ushort), EnumUnderlyingType.UShort);
        UnderlyingTypeMap.Add(typeof(int), EnumUnderlyingType.Int);
        UnderlyingTypeMap.Add(typeof(uint), EnumUnderlyingType.UInt);
        UnderlyingTypeMap.Add(typeof(long), EnumUnderlyingType.Long);
        UnderlyingTypeMap.Add(typeof(ulong), EnumUnderlyingType.ULong);
    }

    [return: NamedEnum]
    internal static EnumUnderlyingType Map(Type underlyingType)
        => UnderlyingTypeMap.TryGetValue(underlyingType, out var value)
            ? value
            : throw new InvalidOperationException($"invalid underlying enum type {underlyingType}");

    /// <summary>
    /// Computes the bitwise AND (&) of the values passed in.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static TEnum And<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum
        => EnumRep<TEnum>.And(lhs, rhs);

    /// <summary>
    /// Determines if the enum value passed in has the flag passed in.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <param name="flag"></param>
    /// <returns></returns>
    public static bool HasFlag<TEnum>(TEnum value, TEnum flag) where TEnum : struct, Enum
        => EnumRep<TEnum>.HasFlag(value, flag);

    /// <summary>
    /// Computes the bitwise OR (|) of the values passed in.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static TEnum Or<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum => EnumRep<TEnum>.Or(lhs, rhs);

    /// <summary>
    /// Computes the bitwise NOT (!) of the value passed in.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static TEnum Not<TEnum>(TEnum value) where TEnum : struct, Enum => EnumRep<TEnum>.Not(value);

    /// <summary>
    /// Computes the bitwise XOR (^) of the values passed in.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static TEnum XOr<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum
        => EnumRep<TEnum>.XOr(lhs, rhs);

    /// <summary>
    /// Determines if the first value passed in is less than the second.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool Less<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum
        => EnumRep<TEnum>.Less(lhs, rhs);

    /// <summary>
    /// Determines if the two values are equal.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool Equal<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum
        => EnumRep<TEnum>.Equal(lhs, rhs);

    /// <summary>
    /// Determines if the first value passed in is greater than the second.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool Greater<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum
        => EnumRep<TEnum>.Greater(lhs, rhs);

    /// <summary>
    /// Determines if the first value passed in is less than or equal to the second.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool LessOrEqual<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum
        => EnumRep<TEnum>.LessOrEqual(lhs, rhs);

    /// <summary>
    /// Determines if the first value passed in is greater than or equal to the second.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static bool GreaterOrEqual<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum
        => EnumRep<TEnum>.GreaterOrEqual(lhs, rhs);

    /// <summary>
    /// Compares the two values, returning an integer whose sign describes their relationship.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns>
    /// An integer that is less than 0 if <paramref name="lhs"/> is less than <paramref name="rhs"/>,
    /// equal to 0 if <paramref name="lhs"/> equals <paramref name="rhs"/>,
    /// and greater than 0 if <paramref name="lhs"/> is greater than <paramref name="rhs"/>.
    /// </returns>
    public static int CompareTo<TEnum>(TEnum lhs, TEnum rhs) where TEnum : struct, Enum
        => EnumRep<TEnum>.CompareTo(lhs, rhs);

    /// <summary>
    /// Determines if the enum value passed in is a named, defined value of type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsDefined<TEnum>(TEnum value) where TEnum : struct, Enum => EnumRep<TEnum>.IsDefined(value);

    /// <summary>
    /// Gets all named, defined values of the enum type <typeparamref name="TEnum"/>.
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    public static TEnum[] GetValues<TEnum>() where TEnum : struct, Enum => EnumRep<TEnum>.GetValues();
}

internal static class EnumRep<TEnum> where TEnum : struct, Enum
{
    private static readonly EnumOperations<TEnum> operations;

    private static readonly TEnum[] values = (TEnum[])Enum.GetValues(typeof(TEnum));

    private static readonly HashSet<TEnum> valuesSet = new(values);

    static EnumRep()
    {
#pragma warning disable CS8524 // All enum values in the map should be named
        operations = Enums.Map(typeof(TEnum).GetEnumUnderlyingType()) switch
#pragma warning restore CS8524
        {
            EnumUnderlyingType.Byte => new ByteEnumOperations<TEnum>(),
            EnumUnderlyingType.SByte => new SByteEnumOperations<TEnum>(),
            EnumUnderlyingType.Short => new ShortEnumOperations<TEnum>(),
            EnumUnderlyingType.UShort => new UShortEnumOperations<TEnum>(),
            EnumUnderlyingType.Int => new IntEnumOperations<TEnum>(),
            EnumUnderlyingType.UInt => new UIntEnumOperations<TEnum>(),
            EnumUnderlyingType.Long => new LongEnumOperations<TEnum>(),
            EnumUnderlyingType.ULong => new ULongEnumOperations<TEnum>(),
        };
    }

    public static TEnum And(TEnum lhs, TEnum rhs) => operations.And(lhs, rhs);

    public static bool HasFlag(TEnum value, TEnum flag) => operations.HasFlag(value, flag);

    public static TEnum Or(TEnum lhs, TEnum rhs) => operations.Or(lhs, rhs);

    public static TEnum Or(IEnumerable<TEnum> values) => operations.Or(values);

    public static TEnum Not(TEnum value) => operations.Not(value);

    public static TEnum XOr(TEnum lhs, TEnum rhs) => operations.XOr(lhs, rhs);

    public static bool Less(TEnum lhs, TEnum rhs) => operations.Less(lhs, rhs);

    public static bool Equal(TEnum lhs, TEnum rhs) => operations.Equal(lhs, rhs);

    public static bool Greater(TEnum lhs, TEnum rhs) => operations.Greater(lhs, rhs);

    public static bool LessOrEqual(TEnum lhs, TEnum rhs) => operations.LessOrEqual(lhs, rhs);

    public static bool GreaterOrEqual(TEnum lhs, TEnum rhs) => operations.GreaterOrEqual(lhs, rhs);

    public static int CompareTo(TEnum lhs, TEnum rhs) => operations.CompareTo(lhs, rhs);

    public static TEnum[] GetValues() => values.ToArray();

    public static bool IsDefined(TEnum value) => valuesSet.Contains(value);
}

/// <summary>
/// Represents the underlying type of an enum.
/// </summary>
internal enum EnumUnderlyingType : byte
{
    /// <summary>
    /// Indicates that an enum uses a <see cref="byte"/> as its underlying type.
    /// </summary>
    Byte,

    /// <summary>
    /// Indicates that an enum uses an <see cref="sbyte"/> as its underlying type.
    /// </summary>
    SByte,

    /// <summary>
    /// Indicates that an enum uses a <see cref="short"/> as its underlying type.
    /// </summary>
    Short,

    /// <summary>
    /// Indicates that an enum uses a <see cref="ushort"/> as its underlying type.
    /// </summary>
    UShort,

    /// <summary>
    /// Indicates that an enum uses an <see cref="int"/> as its underlying type.
    /// </summary>
    Int,

    /// <summary>
    /// Indicates that an enum uses a <see cref="uint"/> as its underlying type.
    /// </summary>
    UInt,

    /// <summary>
    /// Indicates that an enum uses a <see cref="long"/> as its underlying type.
    /// </summary>
    Long,

    /// <summary>
    /// Indicates that an enum uses a <see cref="ulong"/> as its underlying type.
    /// </summary>
    ULong,
}

#region EnumOperations
internal abstract class EnumOperations<TEnum> where TEnum : struct, Enum
{
    public abstract TEnum And(TEnum lhs, TEnum rhs);

    public abstract bool HasFlag(TEnum value, TEnum flag);

    public abstract TEnum Or(TEnum lhs, TEnum rhs);

    public abstract TEnum Or(IEnumerable<TEnum> values);

    public abstract TEnum Not(TEnum value);

    public abstract TEnum XOr(TEnum lhs, TEnum rhs);

    public abstract bool Greater(TEnum lhs, TEnum rhs);

    public abstract bool Equal(TEnum lhs, TEnum rhs);

    public abstract bool Less(TEnum lhs, TEnum rhs);

    public abstract bool GreaterOrEqual(TEnum lhs, TEnum rhs);

    public abstract bool LessOrEqual(TEnum lhs, TEnum rhs);

    public abstract int CompareTo(TEnum lhs, TEnum rhs);
}

internal sealed class ByteEnumOperations<TEnum> : EnumOperations<TEnum> where TEnum : struct, Enum
{
    public override TEnum And(TEnum lhs, TEnum rhs) => Enum(Byte(lhs) & Byte(rhs));

    public override bool HasFlag(TEnum value, TEnum flag)
    {
        var byteFlag = Byte(flag);
        return (Byte(value) & byteFlag) == byteFlag;
    }

    public override int CompareTo(TEnum lhs, TEnum rhs) => Byte(lhs).CompareTo(Byte(rhs));

    public override bool Equal(TEnum lhs, TEnum rhs) => Byte(lhs) == Byte(rhs);

    public override bool Greater(TEnum lhs, TEnum rhs) => Byte(lhs) > Byte(rhs);

    public override bool GreaterOrEqual(TEnum lhs, TEnum rhs) => Byte(lhs) >= Byte(rhs);

    public override bool Less(TEnum lhs, TEnum rhs) => Byte(lhs) < Byte(rhs);

    public override bool LessOrEqual(TEnum lhs, TEnum rhs) => Byte(lhs) <= Byte(rhs);

    public override TEnum Not(TEnum value) => Enum(~Byte(value));

    public override TEnum Or(TEnum lhs, TEnum rhs) => Enum(Byte(lhs) | Byte(rhs));

    public override TEnum Or(IEnumerable<TEnum> values)
    {
        byte byteResult = 0;
        foreach (var value in values) byteResult |= Byte(value);
        return Enum(byteResult);
    }

    public override TEnum XOr(TEnum lhs, TEnum rhs) => Enum(Byte(lhs) ^ Byte(rhs));

    private static byte Byte(TEnum value) => Unsafe.As<TEnum, byte>(ref value);

    private static TEnum Enum(int value) => Unsafe.As<int, TEnum>(ref value);
}

internal sealed class SByteEnumOperations<TEnum> : EnumOperations<TEnum> where TEnum : struct, Enum
{
    public override TEnum And(TEnum lhs, TEnum rhs) => Enum(SByte(lhs) & SByte(rhs));

    public override bool HasFlag(TEnum value, TEnum flag)
    {
        var sbyteFlag = SByte(flag);
        return (SByte(value) & sbyteFlag) == sbyteFlag;
    }

    public override int CompareTo(TEnum lhs, TEnum rhs) => SByte(lhs).CompareTo(SByte(rhs));

    public override bool Equal(TEnum lhs, TEnum rhs) => SByte(lhs) == SByte(rhs);

    public override bool Greater(TEnum lhs, TEnum rhs) => SByte(lhs) > SByte(rhs);

    public override bool GreaterOrEqual(TEnum lhs, TEnum rhs) => SByte(lhs) >= SByte(rhs);

    public override bool Less(TEnum lhs, TEnum rhs) => SByte(lhs) < SByte(rhs);

    public override bool LessOrEqual(TEnum lhs, TEnum rhs) => SByte(lhs) <= SByte(rhs);

    public override TEnum Not(TEnum value) => Enum(~SByte(value));

    public override TEnum Or(TEnum lhs, TEnum rhs) => Enum(SByte(lhs) | SByte(rhs));

    public override TEnum Or(IEnumerable<TEnum> values)
    {
        sbyte sbyteResult = 0;
        foreach (var value in values) sbyteResult |= SByte(value);
        return Enum(sbyteResult);
    }

    public override TEnum XOr(TEnum lhs, TEnum rhs) => Enum(SByte(lhs) ^ SByte(rhs));

    private static sbyte SByte(TEnum value) => Unsafe.As<TEnum, sbyte>(ref value);

    private static TEnum Enum(int value) => Unsafe.As<int, TEnum>(ref value);
}

internal sealed class ShortEnumOperations<TEnum> : EnumOperations<TEnum> where TEnum : struct, Enum
{
    public override TEnum And(TEnum lhs, TEnum rhs) => Enum(Short(lhs) & Short(rhs));

    public override bool HasFlag(TEnum value, TEnum flag)
    {
        var shortFlag = Short(flag);
        return (Short(value) & shortFlag) == shortFlag;
    }

    public override int CompareTo(TEnum lhs, TEnum rhs) => Short(lhs).CompareTo(Short(rhs));

    public override bool Equal(TEnum lhs, TEnum rhs) => Short(lhs) == Short(rhs);

    public override bool Greater(TEnum lhs, TEnum rhs) => Short(lhs) > Short(rhs);

    public override bool GreaterOrEqual(TEnum lhs, TEnum rhs) => Short(lhs) >= Short(rhs);

    public override bool Less(TEnum lhs, TEnum rhs) => Short(lhs) < Short(rhs);

    public override bool LessOrEqual(TEnum lhs, TEnum rhs) => Short(lhs) <= Short(rhs);

    public override TEnum Not(TEnum value) => Enum(~Short(value));

    public override TEnum Or(TEnum lhs, TEnum rhs) => Enum(Short(lhs) | Short(rhs));

    public override TEnum Or(IEnumerable<TEnum> values)
    {
        short shortResult = 0;
        foreach (var value in values) shortResult |= Short(value);
        return Enum(shortResult);
    }

    public override TEnum XOr(TEnum lhs, TEnum rhs) => Enum(Short(lhs) ^ Short(rhs));

    private static short Short(TEnum value) => Unsafe.As<TEnum, short>(ref value);

    private static TEnum Enum(int value) => Unsafe.As<int, TEnum>(ref value);
}

internal sealed class UShortEnumOperations<TEnum> : EnumOperations<TEnum> where TEnum : struct, Enum
{
    public override TEnum And(TEnum lhs, TEnum rhs) => Enum(UShort(lhs) & UShort(rhs));

    public override bool HasFlag(TEnum value, TEnum flag)
    {
        var ushortFlag = UShort(flag);
        return (UShort(value) & ushortFlag) == ushortFlag;
    }

    public override int CompareTo(TEnum lhs, TEnum rhs) => UShort(lhs).CompareTo(UShort(rhs));

    public override bool Equal(TEnum lhs, TEnum rhs) => UShort(lhs) == UShort(rhs);

    public override bool Greater(TEnum lhs, TEnum rhs) => UShort(lhs) > UShort(rhs);

    public override bool GreaterOrEqual(TEnum lhs, TEnum rhs) => UShort(lhs) >= UShort(rhs);

    public override bool Less(TEnum lhs, TEnum rhs) => UShort(lhs) < UShort(rhs);

    public override bool LessOrEqual(TEnum lhs, TEnum rhs) => UShort(lhs) <= UShort(rhs);

    public override TEnum Not(TEnum value) => Enum(~UShort(value));

    public override TEnum Or(TEnum lhs, TEnum rhs) => Enum(UShort(lhs) | UShort(rhs));

    public override TEnum Or(IEnumerable<TEnum> values)
    {
        ushort ushortResult = 0;
        foreach (var value in values) ushortResult |= UShort(value);
        return Enum(ushortResult);
    }

    public override TEnum XOr(TEnum lhs, TEnum rhs) => Enum(UShort(lhs) ^ UShort(rhs));

    private static ushort UShort(TEnum value) => Unsafe.As<TEnum, ushort>(ref value);

    private static TEnum Enum(int value) => Unsafe.As<int, TEnum>(ref value);
}

internal sealed class IntEnumOperations<TEnum> : EnumOperations<TEnum> where TEnum : struct, Enum
{
    public override TEnum And(TEnum lhs, TEnum rhs) => Enum(Int(lhs) & Int(rhs));

    public override bool HasFlag(TEnum value, TEnum flag)
    {
        var intFlag = Int(flag);
        return (Int(value) & intFlag) == intFlag;
    }

    public override int CompareTo(TEnum lhs, TEnum rhs) => Int(lhs).CompareTo(Int(rhs));

    public override bool Equal(TEnum lhs, TEnum rhs) => Int(lhs) == Int(rhs);

    public override bool Greater(TEnum lhs, TEnum rhs) => Int(lhs) > Int(rhs);

    public override bool GreaterOrEqual(TEnum lhs, TEnum rhs) => Int(lhs) >= Int(rhs);

    public override bool Less(TEnum lhs, TEnum rhs) => Int(lhs) < Int(rhs);

    public override bool LessOrEqual(TEnum lhs, TEnum rhs) => Int(lhs) <= Int(rhs);

    public override TEnum Not(TEnum value) => Enum(~Int(value));

    public override TEnum Or(TEnum lhs, TEnum rhs) => Enum(Int(lhs) | Int(rhs));

    public override TEnum Or(IEnumerable<TEnum> values)
    {
        int intResult = 0;
        foreach (var value in values) intResult |= Int(value);
        return Enum(intResult);
    }

    public override TEnum XOr(TEnum lhs, TEnum rhs) => Enum(Int(lhs) ^ Int(rhs));

    private static int Int(TEnum value) => Unsafe.As<TEnum, int>(ref value);

    private static TEnum Enum(int value) => Unsafe.As<int, TEnum>(ref value);
}

internal sealed class UIntEnumOperations<TEnum> : EnumOperations<TEnum> where TEnum : struct, Enum
{
    public override TEnum And(TEnum lhs, TEnum rhs) => Enum(UInt(lhs) & UInt(rhs));

    public override bool HasFlag(TEnum value, TEnum flag)
    {
        var uintFlag = UInt(flag);
        return (UInt(value) & uintFlag) == uintFlag;
    }

    public override int CompareTo(TEnum lhs, TEnum rhs) => UInt(lhs).CompareTo(UInt(rhs));

    public override bool Equal(TEnum lhs, TEnum rhs) => UInt(lhs) == UInt(rhs);

    public override bool Greater(TEnum lhs, TEnum rhs) => UInt(lhs) > UInt(rhs);

    public override bool GreaterOrEqual(TEnum lhs, TEnum rhs) => UInt(lhs) >= UInt(rhs);

    public override bool Less(TEnum lhs, TEnum rhs) => UInt(lhs) < UInt(rhs);

    public override bool LessOrEqual(TEnum lhs, TEnum rhs) => UInt(lhs) <= UInt(rhs);

    public override TEnum Not(TEnum value) => Enum(~UInt(value));

    public override TEnum Or(TEnum lhs, TEnum rhs) => Enum(UInt(lhs) | UInt(rhs));

    public override TEnum Or(IEnumerable<TEnum> values)
    {
        uint uintResult = 0;
        foreach (var value in values) uintResult |= UInt(value);
        return Enum(uintResult);
    }

    public override TEnum XOr(TEnum lhs, TEnum rhs) => Enum(UInt(lhs) ^ UInt(rhs));

    private static uint UInt(TEnum value) => Unsafe.As<TEnum, uint>(ref value);

    private static TEnum Enum(uint value) => Unsafe.As<uint, TEnum>(ref value);
}

internal sealed class LongEnumOperations<TEnum> : EnumOperations<TEnum> where TEnum : struct, Enum
{
    public override TEnum And(TEnum lhs, TEnum rhs) => Enum(Long(lhs) & Long(rhs));

    public override bool HasFlag(TEnum value, TEnum flag)
    {
        var longFlag = Long(flag);
        return (Long(value) & longFlag) == longFlag;
    }

    public override int CompareTo(TEnum lhs, TEnum rhs) => Long(lhs).CompareTo(Long(rhs));

    public override bool Equal(TEnum lhs, TEnum rhs) => Long(lhs) == Long(rhs);

    public override bool Greater(TEnum lhs, TEnum rhs) => Long(lhs) > Long(rhs);

    public override bool GreaterOrEqual(TEnum lhs, TEnum rhs) => Long(lhs) >= Long(rhs);

    public override bool Less(TEnum lhs, TEnum rhs) => Long(lhs) < Long(rhs);

    public override bool LessOrEqual(TEnum lhs, TEnum rhs) => Long(lhs) <= Long(rhs);

    public override TEnum Not(TEnum value) => Enum(~Long(value));

    public override TEnum Or(TEnum lhs, TEnum rhs) => Enum(Long(lhs) | Long(rhs));

    public override TEnum Or(IEnumerable<TEnum> values)
    {
        long longResult = 0;
        foreach (var value in values) longResult |= Long(value);
        return Enum(longResult);
    }

    public override TEnum XOr(TEnum lhs, TEnum rhs) => Enum(Long(lhs) ^ Long(rhs));

    private static long Long(TEnum value) => Unsafe.As<TEnum, long>(ref value);

    private static TEnum Enum(long value) => Unsafe.As<long, TEnum>(ref value);
}

internal sealed class ULongEnumOperations<TEnum> : EnumOperations<TEnum> where TEnum : struct, Enum
{
    public override TEnum And(TEnum lhs, TEnum rhs) => Enum(ULong(lhs) & ULong(rhs));

    public override bool HasFlag(TEnum value, TEnum flag)
    {
        var ulongFlag = ULong(flag);
        return (ULong(value) & ulongFlag) == ulongFlag;
    }

    public override int CompareTo(TEnum lhs, TEnum rhs) => ULong(lhs).CompareTo(ULong(rhs));

    public override bool Equal(TEnum lhs, TEnum rhs) => ULong(lhs) == ULong(rhs);

    public override bool Greater(TEnum lhs, TEnum rhs) => ULong(lhs) > ULong(rhs);

    public override bool GreaterOrEqual(TEnum lhs, TEnum rhs) => ULong(lhs) >= ULong(rhs);

    public override bool Less(TEnum lhs, TEnum rhs) => ULong(lhs) < ULong(rhs);

    public override bool LessOrEqual(TEnum lhs, TEnum rhs) => ULong(lhs) <= ULong(rhs);

    public override TEnum Not(TEnum value) => Enum(~ULong(value));

    public override TEnum Or(TEnum lhs, TEnum rhs) => Enum(ULong(lhs) | ULong(rhs));

    public override TEnum Or(IEnumerable<TEnum> values)
    {
        ulong ulongResult = 0;
        foreach (var value in values) ulongResult |= ULong(value);
        return Enum(ulongResult);
    }

    public override TEnum XOr(TEnum lhs, TEnum rhs) => Enum(ULong(lhs) ^ ULong(rhs));

    private static ulong ULong(TEnum value) => Unsafe.As<TEnum, ulong>(ref value);

    private static TEnum Enum(ulong value) => Unsafe.As<ulong, TEnum>(ref value);
}
#endregion

