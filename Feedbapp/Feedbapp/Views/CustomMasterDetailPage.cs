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
            // MasterPage is a custom class which manage the Master and Detail section for MasterDetailPage
            Master = new MasterPage(this);           
        }
    }    
}
