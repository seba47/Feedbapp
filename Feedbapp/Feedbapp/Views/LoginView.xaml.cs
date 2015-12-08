using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.ViewModels;
using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        public async void OnLoginClicked(object sender, EventArgs args)
        {
            Redirect();
            Models.UserModel u = await ((LoginViewModel)this.BindingContext).Login();
            if (u != null)
            {
                Redirect();
            }else
            {
                await DisplayAlert("Login incorrecto", "El usuario no existe", "Cancelar");
            }
        }
        public async void Redirect()
        {
            var root = Navigation.NavigationStack[0];
            Navigation.InsertPageBefore(new CustomMasterDetailPage(), root);
            await Navigation.PopAsync();
        }
    }
}
