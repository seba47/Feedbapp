using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.ViewModels;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class RequestView : ContentPage
    {
        public RequestView()
        {
            InitializeComponent();
            //** Main Binding context on the XAML file **
            List<string> users = ((RequestViewModel)this.BindingContext).UsersList;
            foreach (var item in users)
            {
                pkrNombre.Items.Add(item);
            }
        }

        public async void OnRequestClicked(object sender, EventArgs args)
        {
            bool ret = await ((RequestViewModel)this.BindingContext).RequestFeedback();
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
