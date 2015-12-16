using Feedbapp.Styles;
using Xamarin.Forms;

namespace Feedbapp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application

            NavigationPage np = new NavigationPage(new Views.LoginView());
            np.BackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            np.BarBackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            MainPage = np;

            //MainPage = new Views.Notifications();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
