
namespace EchoBlaze.Components.Pages
{
    public partial class Notes
    {
        /* "FontSize" is variable which stores chosen font size of the text document, reieved from Settings.razor */
        public int FontSize { get; set; } = Settings.FontSize;

        /* "Content" is variable for saving the document's content (the text) */
        public static string Content { get; set; }

    }
}
