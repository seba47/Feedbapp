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
            this.namesList = new List<string>();
            this.usersList = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                User um = new User() { firstName = "Seba", lastName = i.ToString(), password = "", username = "" };
                this.usersList.Add(um);
                this.namesList.Add(um.ToString());
            }
        }

        internal override async Task<bool> Send()
        {
            int test = this.SelectedIndex;
            string comm = this.Comments;
            User selected = this.UsersList[this.SelectedIndex];
            bool x = true;

            return x;

        }
    }
}
