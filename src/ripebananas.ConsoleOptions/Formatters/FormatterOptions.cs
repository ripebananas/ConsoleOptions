namespace ripebananas.ConsoleOptions.Formatters
{
    public class FormatterOptions
    {
        public virtual string CurrentIndicator { get; set; } = "→";

        public virtual string NotCurrentIndicator { get; set; } = " ";

        public virtual string SelectedIndicator { get; set; } = "[*]";

        public virtual string NotSelectedIndicator { get; set; } = "[ ]";

        public virtual string? Prompt { get; set; }

        public virtual Direction Direction { get; internal set; }

        public virtual bool MultiSelection { get; internal set; }
    }
}
