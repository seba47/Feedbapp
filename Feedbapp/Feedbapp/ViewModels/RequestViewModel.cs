using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;

namespace Feedbapp.ViewModels
{
    public class RequestViewModel: BaseReqOffViewModel
    {      
        public RequestViewModel():base()
        {            
            this.namesList = new List<string>();
            this.usersList = new List<User>();
            //this.usersList = new List<UserModel>();
            for (int i = 0; i < 10; i++)
            {
                User um = new User() { FirstName = "Seba", LastName = i.ToString(), Password = "", Username = "" };
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
