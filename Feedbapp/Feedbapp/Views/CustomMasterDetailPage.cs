using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Feedbapp.Models;
using Feedbapp.Entities;

namespace Feedbapp.Views
{
    public class CustomMasterDetailPage : MasterDetailPage 
    {
        public CustomMasterDetailPage()
        {
            this.Icon = "uruit_logo.png";
            Label header = new Label
            {
                Text = "UruIT Menu",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Assemble an array of NamedColor objects.
            
           MasterDetailItem[] items =
                {
                    new MasterDetailItem("Home", ""),
                    new MasterDetailItem("My Profile", ""),
                    new MasterDetailItem("Historical feedback", ""),
                    new MasterDetailItem("Settings", ""),
                    new MasterDetailItem("About", "")               
                };

            // Create ListView for the master page.
            ListView listView = new ListView
            {
                ItemsSource = items
            };

            // Create the master page with the ListView.
            this.Master = new ContentPage
            {
                Title = header.Text,
                Content = new StackLayout
                {                                         
                    Children =
                    {
                        header,
                        listView
                    }
                }
            };
                       

            // Define a selected handler for the ListView.
            listView.ItemSelected += (sender, args) =>
            {
                MasterDetailItem selected = (MasterDetailItem)args.SelectedItem ;
                if (selected.Name== "My Profile")
                {
                    // Set the BindingContext of the detail page.
                    this.Detail = new ProfileView();
                }
                else if (selected.Name == "Home")
                {
                    HomeView rov2 = new HomeView();
                    // Set the BindingContext of the detail page.
                    this.Detail = rov2;
                }
                else
                {
                    // Set the BindingContext of the detail page.
                    this.Detail.BindingContext = args.SelectedItem;
                }
                
                // Show the detail page.
                this.IsPresented = false;
            };

            // Initialize the ListView selection.
            listView.SelectedItem = items[0];
            

            //validateLogin();
        }

        async private void validateLogin()
        {
            bool logged = false;
            if (!logged)
            {
                await Navigation.PushModalAsync(new LoginView());
            }
        }
        
    }    
}
