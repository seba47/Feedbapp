using Feedbapp.Entities;
using Feedbapp.Styles;
using Feedbapp.ViewModels;
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
            entrySender.Suggestions = users;
            entryRecipient.Suggestions = users;
        }

        public async void MainButtonClicked(object sender, EventArgs args)
        {
            string senderName = string.Empty;
            string recipientName = string.Empty;

            IList<View> entries = entryLayout.Children;

            if (((Shared.AutoCompleteView)entries[0]).SelectedItem != null && ((Shared.AutoCompleteView)entries[1]).SelectedItem != null)
            {
                senderName = ((Shared.AutoCompleteView)entries[0]).SelectedItem.ToString();
                recipientName = ((Shared.AutoCompleteView)entries[1]).SelectedItem.ToString();

                BaseReqOffViewModel context = ((BaseReqOffViewModel)this.BindingContext);
                if (!senderName.Equals(recipientName))
                {
                    context.SelectedSender = context.UsersList.FirstOrDefault(item => item.ToString().Equals(senderName));
                    context.SelectedRecipient = context.UsersList.FirstOrDefault(item => item.ToString().Equals(recipientName));

                    if (context.SelectedSender != null && context.SelectedRecipient != null)
                    {
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
                }
                else
                {
                    await DisplayAlert("Error", "El solicitante y el solicitado no pueden ser la misma persona", "Aceptar");
                }
            }
            else
            {
                await DisplayAlert("Error", "El o los usuarios ingresados no existen en el sistema.", "Aceptar");
            }
        }

        private async void GoToSuccessfullPage(BaseReqOffViewModel context)
        {
            SentView sView = new SentView(context.getSentText());
            await Navigation.PushAsync(sView);
            NavigationPage.SetHasBackButton(sView, false);
        }

        public void ResetControls()
        {
            entryRecipient.ClearField();
            editorComments.Text = "";
        }
    }
}