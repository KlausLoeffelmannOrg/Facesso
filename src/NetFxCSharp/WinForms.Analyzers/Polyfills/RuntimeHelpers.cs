// https://github.com/dotnet/runtime/blob/419e949d258ecee4c40a460fb09c66d974229623/src/libraries/System.Private.CoreLib/src/System/RuntimeHelpers.cs

namespace System;

internal static class RuntimeHelpers
{
    /// <summary>
    /// Slices the specified array using the specified range.
    /// </summary>
    public static T[] GetSubArray<T>(T[] array, Range range)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        (int offset, int length) = range.GetOffsetAndLength(array.Length);

        if (default(T) != null || typeof(T[]) == array.GetType())
        {
            if (length == 0)
            {
                return Array.Empty<T>();
            }

            var dest = new T[length];
            Array.Copy(array, offset, dest, 0, length);
            return dest;
        }
        else
        {
            var dest = (T[])Array.CreateInstance(array.GetType().GetElementType(), length);
            Array.Copy(array, offset, dest, 0, length);
            return dest;
        }
    }
}
