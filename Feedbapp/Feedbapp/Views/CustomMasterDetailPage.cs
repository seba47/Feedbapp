using Feedbapp.Entities;
using Feedbapp.Models;
using Feedbapp.Shared;
using Feedbapp.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Feedbapp.Views
{
    public class CustomMasterDetailPage : MasterDetailPage
    {
        public CustomMasterDetailPage()
        {
            // MasterPage is a custom class which manage the Master and Detail section for MasterDetailPage
            Master = new MasterPage(this);
        }
    }
}