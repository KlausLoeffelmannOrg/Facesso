// https://github.com/dotnet/runtime/blob/419e949d258ecee4c40a460fb09c66d974229623/src/libraries/System.Private.CoreLib/src/System/Range.cs

using System.Runtime.CompilerServices;

namespace System;

/// <summary>Represent a range has start and end indexes.</summary>
internal readonly struct Range : IEquatable<Range>
{
    public Index Start { get; }
    public Index End { get; }

    public Range(Index start, Index end)
    {
        Start = start;
        End = end;
    }

    public override bool Equals(object? value) =>
        value is Range r &&
        r.Start.Equals(Start) &&
        r.End.Equals(End);

    public bool Equals(Range other) => other.Start.Equals(Start) && other.End.Equals(End);

    public override int GetHashCode()
    {
        return Start.GetHashCode() * 31 + End.GetHashCode();
    }

    public override string ToString()
    {
        return Start + ".." + End;
    }

    public static Range StartAt(Index start) => new(start, Index.End);
    public static Range EndAt(Index end) => new(Index.Start, end);
    public static Range All => new(Index.Start, Index.End);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public (int Offset, int Length) GetOffsetAndLength(int length)
    {
        int start;
        var startIndex = Start;
        if (startIndex.IsFromEnd)
            start = length - startIndex.Value;
        else
            start = startIndex.Value;

        int end;
        var endIndex = End;
        if (endIndex.IsFromEnd)
            end = length - endIndex.Value;
        else
            end = endIndex.Value;

        if ((uint)end > (uint)length || (uint)start > (uint)end)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }

        return (start, end - start);
    }
}
