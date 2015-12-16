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
            this.buttonText = "Solicitar Feedback";
            this.usersList = new List<User>();
            
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
