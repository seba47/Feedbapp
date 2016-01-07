using Feedbapp.Styles;
using Xamarin.Forms;

namespace Feedbapp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //NavigationPage np = new NavigationPage(new Views.LoginView());      
            //np.BackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            //np.BarBackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            //MainPage = np;     
            InitMVPApp();
        }

        /// <summary>
        /// Method used for the first release as MVP app (without: login, notifications and neither history)
        /// </summary>
        protected void InitMVPApp()
        {
            NavigationPage np = new NavigationPage(new Views.CustomMasterDetailPage());
            np.BackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            np.BarBackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            MainPage = np;
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
