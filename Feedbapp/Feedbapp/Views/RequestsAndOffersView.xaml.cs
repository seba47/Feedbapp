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
    public partial class RequestsAndOffersView : ContentPage
    {
        public RequestsAndOffersView()
        {
            InitializeComponent();
            this.BackgroundColor = BackgroundColor = MainStyles.GetBackgroundColor();

            List<MasterDetailItem> list = new List<MasterDetailItem>();
            MasterDetailItem m = new MasterDetailItem("José Perez", "profile1.png");
            list.Add(m);

            MasterDetailItem m2 = new MasterDetailItem("Maria Rosas", "profile2.png");
            list.Add(m2);

            MasterDetailItem m3 = new MasterDetailItem("test 3", "profile1.png");
            list.Add(m3);

            MasterDetailItem m4 = new MasterDetailItem("José Perez", "profile1.png");
            list.Add(m4);

            MasterDetailItem m5 = new MasterDetailItem("Maria Rosas", "profile2.png");
            list.Add(m5);

            MasterDetailItem m6 = new MasterDetailItem("test 3", "profile1.png");
            list.Add(m6);

            LvwPending.ItemsSource = PageTypeGroup.All;


            //LvwApproved.ItemsSource = list;
        }

        public async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FeedbackRequestView());
        }

    }
}
