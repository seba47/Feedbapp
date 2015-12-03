using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            
        }

        public async void OnLoginClicked(object sender, EventArgs args)
        {
            Services.RestService restService = new Services.RestService();
            var json =  await restService.GetUser(etyUsername.Text);


            if (!string.IsNullOrWhiteSpace(json))
            {
                //Redirect();
            }
            else
            {
                await DisplayAlert("Login incorrecto", "El usuario no existe", "Cancelar");
            }

            //await Navigation.PopModalAsync();
            //var root = Navigation.NavigationStack[0];
            //Navigation.InsertPageBefore(this, root);
            //await Navigation.PopAsync();
        }

        public async void Redirect()
        {
            var root = Navigation.NavigationStack[0];
            Navigation.InsertPageBefore(new CustomMasterDetailPage(), root);
            await Navigation.PopAsync();
        }


       
    }
}
