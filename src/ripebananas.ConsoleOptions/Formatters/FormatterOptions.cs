namespace ripebananas.ConsoleOptions.Formatters
{
    public class FormatterOptions
    {
        public virtual string CurrentIndicator { get; set; } = "→";

        public virtual string NotCurrentIndicator { get; set; } = " ";

        public virtual string SelectedIndicator { get; set; } = "[*]";

        public virtual string NotSelectedIndicator { get; set; } = "[ ]";
    }
}
