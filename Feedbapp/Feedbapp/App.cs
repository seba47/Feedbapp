using Feedbapp.Styles;
using Xamarin.Forms;

namespace Feedbapp
{
    public class App : Application
    {
        public App()
        {
            LoadStyles();
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
            //NavigationPage np = new NavigationPage(new Views.SentView("Se le ha enviado una solicitud a Pepito para agendar una instancia."));
            NavigationPage np = new NavigationPage(new Views.CustomMasterDetailPage());
            np.BackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            np.BarBackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            MainPage = np;
        }

        private void LoadStyles()
        {
            Application.Current.Resources = new ResourceDictionary();

            // BUTTONS
            var buttonStyle = new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = Button.TextColorProperty, Value = Color.White},
                    //new Setter { Property = Button.FontAttributesProperty, Value = FontAttributes.Bold},
                    new Setter { Property = Button.BorderRadiusProperty, Value = 0},
                    new Setter { Property = Button.BackgroundColorProperty, Value= Styles.MainStyles.GetButtonColor()},
                    new Setter { Property = Button.FontFamilyProperty, Value = "Comic Sans.ttf"}
                }
            };
            // no Key specified, becomes an implicit style for ALL boxviews
            Application.Current.Resources.Add(buttonStyle);

            //PICKERS
            var pickerStyle = new Style(typeof(Picker))
            {
                Setters = {
                    //new Setter { Property = Picker.BackgroundColorProperty, Value = Color.Gray}
                }
            };
            // no Key specified, becomes an implicit style for ALL boxviews
            Application.Current.Resources.Add(pickerStyle);
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