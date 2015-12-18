using Feedbapp.Entities;
using Feedbapp.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class MasterPage : ContentPage
    {
        public MasterDetailPage root { get; set; }
        public ListView ListView { get { return listView; } }

        public MasterPage(MasterDetailPage main)
        {
            if (main != null)
            {
                this.root = main;
            }

            InitializeComponent();
            BackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));

            //lblHeader.Text = "Feedbapp Menu";
            //lblHeader.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            //lblHeader.HorizontalOptions = LayoutOptions.Center;
            //lblHeader.BackgroundColor = Color.FromHex(MainStyles.GetBackgroundColor(false));

            MasterDetailItem[] items =
            {
                new MasterDetailItem("Home", ""),
                //new MasterDetailItem("My Profile", ""),
                new MasterDetailItem("Notificaciones", ""),
                //new MasterDetailItem("Settings", ""),
                new MasterDetailItem("About", "")
            };

            //ToolbarItem tbi = new ToolbarItem();
            //tbi.Icon = "notifications.png";
            //tbi.Text = "Notificaciones";
            //tbi.Clicked += GoToNotificationsPage;
            //this.ToolbarItems.Add(tbi);

            listView.ItemsSource = items;


            // Define a selected handler for the ListView.

            listView.ItemSelected += (sender, args) =>
            {
                MasterDetailItem selected = (MasterDetailItem)args.SelectedItem;
                if (selected.Name == "Home")
                {
                    HomeView rov2 = new HomeView();
                    // Set the BindingContext of the detail page.
                    root.Detail = rov2;
                }
                else if (selected.Name == "Notificaciones")
                {
                    Notifications not = new Notifications();
                    root.Detail = not;
                }
                else
                {
                    // Set the BindingContext of the detail page.
                    root.Detail.BindingContext = args.SelectedItem;
                }

                // Show the detail page.
                root.IsPresented = false;
            };

            // Initialize the ListView selection.
            listView.SelectedItem = items[0];
        }

        async void GoToNotificationsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Notifications());
        }
    }
}
