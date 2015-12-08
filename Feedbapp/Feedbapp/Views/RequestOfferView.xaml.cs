using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.ViewModels;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class RequestOfferView : ContentPage
    {
        public RequestOfferView(bool requestMode)
        {
            InitializeComponent();
            if (requestMode)
            {
                this.BindingContext = new RequestViewModel();
            }
            else
            {
                this.BindingContext = new OfferViewModel();
            }            

            //** Main Binding context on the XAML file **
            List<string> users = ((BaseReqOffViewModel)this.BindingContext).NamesList;
            foreach (var item in users)
            {
                pkrNombre.Items.Add(item);
            }
        }

        public async void MainButtonClicked(object sender, EventArgs args)
        {
            bool ret = await ((RequestViewModel)this.BindingContext).Send();
            if (ret)
            {
                await DisplayAlert("Solicitar Feedback", "Feedback solicitado!", "Aceptar");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Login incorrecto", "El usuario no existe", "Cancelar");
            }
        }
    }
}
