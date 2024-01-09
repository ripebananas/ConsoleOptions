using System;

namespace ripebananas.ConsoleOptions
{
    public class OptionDescription<T>
    {
        public T Value { get; }

        public string Description { get; }

        public OptionDescription(T value, string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException(description);
            }

            Value = value;
            Description = description;
        }
    }
}