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
        private const string backgroundColor = "212830" ;

        public static string GetBackgroundColor(bool withSimbol)
        {
            return withSimbol ? "#" + backgroundColor : backgroundColor;
        }

        public static Color GetBackgroundColor()
        {            
            return Color.FromHex(backgroundColor);
        }
    }
}
