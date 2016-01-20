using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.ViewModels;

using Xamarin.Forms;
using Feedbapp.Styles;
using Feedbapp.Entities;

namespace Feedbapp.Views
{
    public partial class RequestOfferView : ContentPage
    {
        public RequestOfferView(bool requestMode)
        {
            InitializeComponent();
            this.BackgroundColor = BackgroundColor = MainStyles.GetBackgroundColor();
            if (requestMode)
                this.BindingContext = new RequestViewModel();
            else
                this.BindingContext = new OfferViewModel();

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
                BaseReqOffViewModel context = ((BaseReqOffViewModel)this.BindingContext);                
                context.SelectedSender = context.UsersList[pkrSender.SelectedIndex];
                context.SelectedRecipient = context.UsersList[pkrRecipient.SelectedIndex];
                bool sentOk = await context.Send();
                if (sentOk)
                {
                    ResetControls();
                    GoToSuccessfullPage(context);                    
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo solicitar el feedback", "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("Error", "El solicitante y el solicitado no pueden ser la misma persona", "Aceptar");
            }
        }

        private async void GoToSuccessfullPage(BaseReqOffViewModel context)
        {
            SentView sView = new SentView(context.getSentText());
            await Navigation.PushAsync(sView);
            NavigationPage.SetHasBackButton(sView, false);
        }

        private void ResetControls()
        {
            pkrSender.SelectedIndex = -1;
            pkrRecipient.SelectedIndex = -1;
            editorComments.Text = "";
        }
    }
}
