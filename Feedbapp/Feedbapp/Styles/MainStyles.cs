using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Feedbapp.Styles
{
    public class MainStyles
    {
        private const string backgroundColor = "212830"; //"FFFFFF";
        private const string secondBackgroundColor = "212830";
        private const string buttonColor = "0e8c92";

        public static string GetBackgroundColor(bool withSimbol)
        {
            return withSimbol ? "#" + backgroundColor : backgroundColor;
        }

        public static Color GetBackgroundColor()
        {
            return Color.FromHex(backgroundColor);
        }

        public static Color GetButtonColor()
        {
            return Color.FromHex(buttonColor);
        }

        public static Color GetSecondBackgroundColor()
        {
            return Color.FromHex(secondBackgroundColor);
        }
    }
}