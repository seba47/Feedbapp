using Feedbapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class MainMenuView : ListView
    {
        public MainMenuView()
        {
            MasterDetailItem[] items =
            {
                new MasterDetailItem("Home", ""),
                //new MasterDetailItem("My Profile", ""),
                new MasterDetailItem("Notificaciones", ""),
                //new MasterDetailItem("Settings", ""),
                new MasterDetailItem("About", "")
            };
            this.ItemsSource = items;

            //this.ItemSelected += (sender, args) =>
            //{
            //    MasterDetailItem selected = (MasterDetailItem)args.SelectedItem;
            //    if (selected.Name == "Home")
            //    {
            //        HomeView rov2 = new HomeView();
            //        // Set the BindingContext of the detail page.
            //        this.Detail = rov2;
            //    }
            //    else if (selected.Name == "Notificaciones")
            //    {
            //        Notifications not = new Notifications();
            //        this.Detail = not;
            //    }
            //    else
            //    {
            //        // Set the BindingContext of the detail page.
            //        this.Detail.BindingContext = args.SelectedItem;
            //    }

            //    // Show the detail page.
            //    this.IsPresented = false;
            //};

            //// Initialize the ListView selection.
            //this.SelectedItem = items[0];
        }
    }
}
