using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;


namespace Feedbapp.ViewModels
{
    public class OfferViewModel : BaseReqOffViewModel
    {
        public OfferViewModel():base()
        {
            this.buttonText="Ofrecer Feedback";
            this.PageTitle = "Ofrecer Feedback";           
        }

        internal override async Task<bool> Send()
        {
            int test = this.selectedIndexSender;
            string comm = this.Comments;
            User selected = this.UsersList[this.selectedIndexSender];
            bool x = true;

            return x;

        }
    }
}
