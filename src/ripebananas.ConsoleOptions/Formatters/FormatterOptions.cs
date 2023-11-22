namespace ripebananas.ConsoleOptions.Formatters
{
    public class FormatterOptions
    {
        public string CurrentIndicator { get; set; } = "→";

        public string NotCurrentIndicator { get; set; } = " ";

        public string SelectedIndicator { get; set; } = "[*]";

        public string NotSelectedIndicator { get; set; } = "[ ]";
    }
}
