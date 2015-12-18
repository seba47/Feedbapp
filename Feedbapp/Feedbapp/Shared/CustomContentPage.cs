using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Feedbapp.Views;
using Feedbapp.Styles;

namespace Feedbapp.Shared
{
    public class CustomContentPage: ContentPage
    {
        public CustomContentPage()
        {
            this.BackgroundColor = BackgroundColor = MainStyles.GetBackgroundColor();
        }        
    }
}
