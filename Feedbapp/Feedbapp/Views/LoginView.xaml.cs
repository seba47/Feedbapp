using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.ViewModels;
using Xamarin.Forms;
using Feedbapp.Entities;
using Feedbapp.Styles;

namespace Feedbapp.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            this.BackgroundColor = BackgroundColor = MainStyles.GetBackgroundColor();
            this.BindingContext = new LoginViewModel();
            if (((LoginViewModel)this.BindingContext).IsLogged())
            {
                Redirect();
            }
        }
        public async void OnLoginClicked(object sender, EventArgs args)
        {
            bool logged = await ((LoginViewModel)this.BindingContext).Login();
            if (logged)
                Redirect();
            else
                await DisplayAlert("Login incorrecto", "El usuario no existe", "Cancelar");
        }
        public async void Redirect()
        {
            var root = Navigation.NavigationStack[0];
            Navigation.InsertPageBefore(new CustomMasterDetailPage(), root);
            await Navigation.PopAsync();
        }
    }
}
