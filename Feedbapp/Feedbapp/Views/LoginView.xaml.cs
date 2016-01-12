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
            BackgroundColor = BackgroundColor = MainStyles.GetBackgroundColor();
            BindingContext = new LoginViewModel();

            //http://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
            //var isLogged = ((LoginViewModel)this.BindingContext).IsLogged().GetAwaiter().GetResult();            

            //if (isLogged)
            //{
            //    RedirectToHomePage(true);
            //}
        }
        public async void OnLoginClicked(object sender, EventArgs args)
        {

            bool logged = await ((LoginViewModel)this.BindingContext).Login();
            if (logged)
                RedirectToHomePage(false);
            else
                await DisplayAlert("Login incorrecto", "El usuario no existe", "Aceptar");
        }
        public async void RedirectToHomePage(bool onInit)
        {
            if (onInit)
            {
                await Navigation.PushAsync(new CustomMasterDetailPage());
            }
            else
            {
                var root = Navigation.NavigationStack[0];
                Navigation.InsertPageBefore(new CustomMasterDetailPage(), root);
                await Navigation.PopAsync();
            }
            
        }
    }
}
