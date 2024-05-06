using Microsoft.JSInterop;

namespace EchoBlaze.Components.Pages
{
    public partial class Settings
    {
        /* Method to increment "FontSize" */
        private static void IncrementCount()
        {
            FontSize++;
        }

        /* Method to decrement "FontSize" */
        private static void DecrementCount()
        {
            if (!(FontSize < 2))
            {
                FontSize--;
            }
        }

        /* Variable to store current font size*/
        public static int FontSize { get; set; } = 2;

        #region Set of colour variables that can be applied as Background theme

        private static readonly string AverageOrange = "linear-gradient(90deg, #c72f3c,#492751,#c7540f)";
        private static readonly string Lagoon = "linear-gradient(90deg, #197dc8,#16424d,#0f2760)";
        private static readonly string Midnight = "linear-gradient(90deg, #6b12dd,#67339a,#2aa9de)";
        private static readonly string Default = "linear-gradient(90deg, #2909c8,#a72606,#4d0548)";

        #endregion

        #region Set of colour variables that can be applied as Menu background theme

        private static readonly string Dark = "rgba(3, 3, 3, 0.77)";
        private static readonly string Cyan = "rgba(53, 176, 164, 0.79)";
        private static readonly string Gold = "rgba(157, 155, 26, 0.89)";
        private static string Transparent = Default;

        #endregion

        /* Currently selected Background */
        public static string Selected_BackgroundColor = Default;
        /* Currently selected Menu background */
        public static string Selected_MenuBackgroundColor = Selected_BackgroundColor;

        /* Method that loads current themes from LocalStorage on page reload */
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
           if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("loadValue");
                await UpdateRadioButtonSelection();
            }

        }

        /* "UpdateRadioButtonSelection()" assigns propper colour strings to variables */
        protected async Task UpdateRadioButtonSelection()
        {
            /* These variables store values of currently selected radio buttons from HTML */
            string tmp_menu_bg = await JSRuntime.InvokeAsync<string>("interopFunctions.getSelectedRadioButtonID", "radio-menu");
            string tmp_bg = await JSRuntime.InvokeAsync<string>("interopFunctions.getSelectedRadioButtonID", "radio-bg");
            
            Transparent = SetBackgroundColor(tmp_bg); // Transparent Menu background colour is always the same as current Background colour
            
            StateHasChanged();

            Selected_MenuBackgroundColor = SetMenuBackgroundColor(tmp_menu_bg);
            Selected_BackgroundColor = SetBackgroundColor(tmp_bg);
        }

        /* Returns Background colour based on the input */
        private string SetBackgroundColor(string value)
        {
            switch (value)
            {
                case "mid":
                    return Midnight;
                   
                case "lag":
                    return Lagoon;
                    
                case "avg":
                    return AverageOrange;
                    
                default:
                    return Default;    
            }
        }

        /* Returns Menu background colour based on the input */
        private string SetMenuBackgroundColor(string value)
        {
            switch (value)
            {
                case "dar":
                    return Dark;

                case "gol":
                    return Gold;

                case "cya":
                    return Cyan;

                default:
                    return Transparent;
            }
        }

        /* Calls JavaScript function to save colour values into LocalStorage */
        private async Task SaveValue(char option)
        {
            await JSRuntime.InvokeVoidAsync("saveValue", option);
        }

        /* Calls JavaScript function to reload page */
        private async Task ReloadPage()
        {
            await JSRuntime.InvokeVoidAsync("reloadPage"); 
        }
}
}

