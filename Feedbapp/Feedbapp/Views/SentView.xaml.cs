using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Feedbapp.Views
{
    public partial class SentView : ContentPage
    {
        public SentView(string successfullyText)
        {
            InitializeComponent();
            BackgroundColor = Styles.MainStyles.GetBackgroundColor();
            LblMain.Text = successfullyText;
        }
    }
}
