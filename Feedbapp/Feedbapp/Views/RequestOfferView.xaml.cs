using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class RequestOfferView : ContentPage
    {
        public RequestOfferView()
        {
            InitializeComponent();
        }

        async void GoToRequestView(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RequestView());
        }
    }
}
