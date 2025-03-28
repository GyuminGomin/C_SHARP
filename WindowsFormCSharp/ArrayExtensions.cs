/**
 * toStringCustom method is an extension method for the Array class.
 */
namespace WindowsFormCSharp
{
    public static class ArrayExtensions
    {
        // array to string
        public static string ToStringCustom<T>(this T[] array)
        {
            return "[" + string.Join(", ", array) + "]";
        }

        public static string ToStringCustom<T>(this List<T> list)
        {
            return "[" + string.Join(", ", list) + "]";
        }

        // Extract number array from array
        public static string[] ExtractNumbersCustom(this string[] array)
        {
            return Array.FindAll(array, x => decimal.TryParse(x, out _));
        }

        // Extract non-number array from array
        public static string[] ExtractNonNumbersCustom(this string[] array)
        {
            return Array.FindAll(array, x => !decimal.TryParse(x, out _));
        }

        // Remove Null from array
        public static T[] RemoveNullCustom<T>(this T[] array)
        {
            return Array.FindAll(array, x => x != null);
        }

        // Reverse String
        public static string ReverseStringCustom(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}


