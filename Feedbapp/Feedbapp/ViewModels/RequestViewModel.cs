using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Feedbapp.ViewModels
{
    public class RequestViewModel: BaseReqOffViewModel
    {      
        public RequestViewModel():base()
        {            
            this.namesList = new List<string>();
            this.usersList = new List<UserModel>();
            //this.usersList = new List<UserModel>();
            for (int i = 0; i < 10; i++)
            {
                UserModel um = new UserModel() { FirstName = "Seba", LastName = i.ToString(), Password = "", Username = "" };
                this.usersList.Add(um);
                this.namesList.Add(um.ToString());
            }
        }

        internal override async Task<bool> Send()
        {
            int test = this.SelectedIndex;
            string comm = this.Comments;
            UserModel selected = this.UsersList[this.SelectedIndex];
            bool x = true;

            return x;

        }
    }
}
