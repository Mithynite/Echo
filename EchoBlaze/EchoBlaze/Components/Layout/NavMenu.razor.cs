using EchoBlaze.Components.Pages;

namespace EchoBlaze.Components.Layout
{
    public partial class NavMenu
    {
        #region Change Background

        /* "PageMenuBG" stores background color of this menu */
        private readonly string? PageMenuBG = Settings.Selected_MenuBackgroundColor;

        #endregion

        #region Counting

        
        private static string? Content = "";
        private int WordCount  = 0;
        private int CharCount = 0;

        /* This variable stores the field of delimiters used to split the text so it is in propper format */
        private readonly char[] delimiters = [' ', '\r', '\n', '\t'];
        
        /* Method which counts words of the document */
        private void CountTheWords()
        {
            Content = Notes.Content; // Here I assign value of variable "Content" from Notes (it stores the text from the document) to local variable "Content"
            if (!string.IsNullOrEmpty(Content))
            {
                WordCount = Content.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            }
            else
            {
                WordCount = 0;
            }
        }

        /* Method which counts characters of the document */
        private void CountTheChars()
        {
            Content = Notes.Content;
            if (!string.IsNullOrEmpty(Content))
            {
                CharCount = Content.Replace(" ", "").Length;
            }
            else
            {
                CharCount = 0;
            }
        }

        #endregion

        #region Get User's Colour
        
            /* Variable to store user's colour which he chose previously during login */
            private readonly string? colour = Login.UserColour;
        
        #endregion
    }
}

