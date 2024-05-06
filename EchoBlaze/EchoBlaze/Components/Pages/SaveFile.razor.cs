using Microsoft.JSInterop;

namespace EchoBlaze.Components.Pages
{
    public partial class SaveFile
    {
        /* This variable stores text of variable "Content" from Notes.razor */
        private readonly string? Content = $"Content: {Notes.Content}";

        /* File name which is displayed on Save page and can be changed by input in HTML*/
        private string? FileName = "default";

        /* Method to call JavaScript function "downloadFile" to download the document as txt */
        public async void Download()
        {
            await JSRuntime.InvokeVoidAsync("downloadFile", FileName, Content);
        }
    }
}
