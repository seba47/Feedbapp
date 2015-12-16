using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Styles
{
    public class MainStyles
    {

        public static string GetBackgroundColor(bool withSimbol)
        {
            return withSimbol ? "#212830" : "212830";
        }
    }
}
