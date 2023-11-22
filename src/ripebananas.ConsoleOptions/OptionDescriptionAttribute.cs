using System;

namespace ripebananas.ConsoleOptions
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class OptionDescriptionAttribute : Attribute
    {
        public string Description { get; }

        public OptionDescriptionAttribute(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(description);
            }
            Description = description;
        }
    }
}