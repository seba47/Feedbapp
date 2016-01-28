using Feedbapp.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            BackgroundColor = MainStyles.GetBackgroundColor();
            Random r = new Random();
            int rInt = r.Next(1, 2); //for ints
            BackgroundImage = "home" + rInt.ToString() + ".png";
        }

        private async void GoToRequestView(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RequestOfferView(true));
        }

        private async void GoToOfferView(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RequestOfferView(false));
        }
    }
}