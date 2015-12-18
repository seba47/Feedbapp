﻿using Feedbapp.Styles;
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
            this.BackgroundColor = BackgroundColor = MainStyles.GetBackgroundColor();
        }

        async void GoToRequestView(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RequestOfferView(true));
        }
        async void GoToOfferView(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new RequestOfferView(false));
        }
        
    }
}
