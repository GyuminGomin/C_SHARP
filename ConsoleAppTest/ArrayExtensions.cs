using System;

/**
 * toStringCustom method is an extension method for the Array class.
 */
namespace ArrayExtensions
{
    public static class ArrayExtensions
    {
        public static string ToStringCustom<T>(this T[] array)
        {
            return "[" + string.Join(", ", array) + "]";
        }
    }
}


