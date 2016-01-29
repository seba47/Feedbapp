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