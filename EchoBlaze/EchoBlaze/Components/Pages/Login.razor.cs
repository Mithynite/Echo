using Microsoft.JSInterop;

namespace EchoBlaze.Components.Pages
{
    public partial class Login
    {
        #region Colour of User

        /* "UserCoulour" stores current string of rgba of the chosen user's colour */
        public static string UserColour { get; set; } = "linear-gradient(219deg, #00ccff,#ff0033,#bed31d)";

        /* "UpdateColours()" recieves the string from JavaScript method "updateDisplayColor" */
        private async Task UpdateColours()
        {
            UserColour = await JSRuntime.InvokeAsync<string>("updateDisplayColor");
            Console.WriteLine(UserColour);
        }
        #endregion

        private string Username; // User's username
        private string Password; // User's password

        /* "GetLoginCredentials()" recieves written username and password from JavaScript funcition "sendUserCresentials" */
        private async Task GetLoginCredentials()
        {
            string[] creds = await JSRuntime.InvokeAsync<string[]>("sendUserCresentials");
            Username = creds[0];
            Password = creds[1];
            Console.WriteLine(Username);
            Console.WriteLine(Password);
        }
    }
}
