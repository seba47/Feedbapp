using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Feedbapp.Views;

namespace Feedbapp.Shared
{
    public class CustomContentPage: ContentPage
    {
        public CustomContentPage()
        {
            ToolbarItem tbi = new ToolbarItem();
            tbi.Icon = "notifications.png";
            tbi.Text = "Notificaciones";
            tbi.Clicked += GoToNotificationsPage;
            this.ToolbarItems.Add(tbi);   
                
        }

        async void GoToNotificationsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Notifications());
        }
    }
}
