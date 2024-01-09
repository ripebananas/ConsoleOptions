using System;
using System.Collections.Generic;
using System.Reflection;

namespace ripebananas.ConsoleOptions
{
    public static class OptionDescriptions
    {
        public static IEnumerable<OptionDescription<T>> GetFromEnum<T>()
            where T : struct, Enum
        {
            var values = Enum.GetValues(typeof(T));

            foreach (T value in values)
            {
                var name = value.ToString();

                var attr = typeof(T)
                    .GetField(name)?
                    .GetCustomAttribute<OptionDescriptionAttribute>();

                yield return new OptionDescription<T>(value, attr?.Description ?? name);
            }
        }
    }
}