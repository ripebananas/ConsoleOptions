namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static T? BitwiseOr<T>(this IEnumerable<T> values)
            where T : struct, Enum
        {
            T? result = null;

            foreach (var value in values)
            {
                if (result == null)
                {
                    result = value;
                }
                else
                {
                    // no bitwise OR for generic enums, hence the casts
                    result = (T)(object)((int)(object)result | (int)(object)value);
                }
            }

            return result;
        }
    }
}
