using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.ViewModels;

using Xamarin.Forms;
using Feedbapp.Styles;

namespace Feedbapp.Views
{
    public partial class RequestOfferView : ContentPage
    {
        public RequestOfferView(bool requestMode)
        {
            InitializeComponent();
            this.BackgroundColor = BackgroundColor = MainStyles.GetBackgroundColor();
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
                pkrSender.Items.Add(item);
                pkrRecipient.Items.Add(item);
            }
        }

        public async void MainButtonClicked(object sender, EventArgs args)
        {
            if (pkrRecipient.SelectedIndex != pkrSender.SelectedIndex)
            {
                bool ret = true;// await ((BaseReqOffViewModel)this.BindingContext).Send();
                if (ret)
                {
                    //bool exit = await DisplayAlert("Solicitud de Feedback", "¡Gracias! Se le ha enviado una solicitud a " + pkrRecipient.ToString() + " para agendar una instancia de feedback. Recibirás una notificación en cuanto responda.", "Salir", "Nueva Solicitud");
                    bool exit = await DisplayAlert("Solicitud de Feedback", "¡Gracias! Se le ha enviado una solicitud a " + pkrRecipient.Items[pkrRecipient.SelectedIndex] + " para agendar una instancia de feedback. Recibirás un mail de confirmación.", "Salir", "Nueva Solicitud");
                    if (exit)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        //clean the view for a new request
                        editorComments.Text = string.Empty;
                    }
                }
                else
                {
                    await DisplayAlert("No se pudo solicitar el feedback", "", "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("El solicitante y el solicitado no pueden ser la misma persona", "", "Aceptar");
            }
        }
    }
}
