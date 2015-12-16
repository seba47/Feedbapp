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
            bool ret = await ((BaseReqOffViewModel)this.BindingContext).Send();
            if (ret)
            {
                bool exit = await DisplayAlert("Solicitud de Feedback", "¡Gracias! Se le ha enviado una solicitud a " + pkrNombre.ToString() + " para agendar una instancia de feedback. Recibirás una notificación en cuanto responda.", "Salir", "Nueva Solicitud");
                if(exit)
                {
                    await Navigation.PopAsync();                    
                }
                else
                {
                    //clean the view for a new request
                }

            }
            else
            {
                await DisplayAlert("No se pudo solicitar el feedback", "", "Aceptar");
            }
        }
    }
}
