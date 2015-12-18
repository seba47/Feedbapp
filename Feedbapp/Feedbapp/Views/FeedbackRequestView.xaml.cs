using Feedbapp.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class FeedbackRequestView : ContentPage
    {
        public FeedbackRequestView()
        {
            InitializeComponent();
            this.BackgroundColor = BackgroundColor = MainStyles.GetBackgroundColor();
        }
    }
}
