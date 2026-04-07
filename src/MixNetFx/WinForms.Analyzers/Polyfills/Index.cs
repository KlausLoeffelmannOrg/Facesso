// https://github.com/dotnet/runtime/blob/419e949d258ecee4c40a460fb09c66d974229623/src/libraries/System.Private.CoreLib/src/System/Index.cs

using System.Runtime.CompilerServices;

namespace System;

/// <summary>Represent a type can be used to index a collection either from the start or the end.</summary>
internal readonly struct Index : IEquatable<Index>
{
    private readonly int _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Index(int value, bool fromEnd = false)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
        }

        if (fromEnd)
            _value = ~value;
        else
            _value = value;
    }

    private Index(int value)
    {
        _value = value;
    }

    public static Index Start => new Index(0);
    public static Index End => new Index(~0);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index FromStart(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
        }

        return new Index(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index FromEnd(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
        }

        return new Index(~value);
    }

    public int Value
    {
        get
        {
            if (_value < 0)
            {
                return ~_value;
            }
            else
            {
                return _value;
            }
        }
    }

    public bool IsFromEnd => _value < 0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetOffset(int length)
    {
        var offset = _value;
        if (IsFromEnd)
        {
            offset += length + 1;
        }
        return offset;
    }

    public override bool Equals(object? value) => value is Index && _value == ((Index)value)._value;
    public bool Equals(Index other) => _value == other._value;
    public override int GetHashCode() => _value;
    public static implicit operator Index(int value) => FromStart(value);

    public override string ToString()
    {
        if (IsFromEnd)
            return "^" + ((uint)Value).ToString();

        return ((uint)Value).ToString();
    }
}
