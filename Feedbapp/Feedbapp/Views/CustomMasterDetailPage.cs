using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Feedbapp.Models;
using Feedbapp.Entities;
using Feedbapp.Styles;
using Feedbapp.Shared;

namespace Feedbapp.Views
{
    public class CustomMasterDetailPage : MasterDetailPage 
    {
        public CustomMasterDetailPage()
        {                   
            
            this.BackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));
            
            Label header = new Label
            {                
                Text = "Feedbapp",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor= Color.FromHex(MainStyles.GetBackgroundColor(false))

            };
            
            MasterDetailItem[] items =
            {
                new MasterDetailItem("Home", ""),
                //new MasterDetailItem("My Profile", ""),
                new MasterDetailItem("Notificaciones", ""),
                //new MasterDetailItem("Settings", ""),
                new MasterDetailItem("About", "")               
            };

            // Create ListView for the master page.
            ListView listView = new ListView
            {
                ItemsSource = items
            };

            // Create the master page with the ListView.
            this.Master = new CustomContentPage
            {
                Title = header.Text,
                Icon= "hamburguer.png",
                BackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false)),
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
                 if (selected.Name == "Home")
                {
                    HomeView rov2 = new HomeView();
                    // Set the BindingContext of the detail page.
                    this.Detail = rov2;
                }else if(selected.Name == "Notificaciones")
                {
                    Notifications not = new Notifications();
                    this.Detail = not;
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
        }
        
    }    
}
