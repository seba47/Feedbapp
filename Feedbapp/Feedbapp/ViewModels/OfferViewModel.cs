using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Feedbapp.ViewModels
{
    public class OfferViewModel
    {
        private List<string> usersList;
        private string comments;
        private UserModel selectedUser;
        private string selectedItem;

        public string Comments
        {
            get
            {
                return comments;
            }
            set
            {
                comments = value;
            }
        }

        public List<string> UsersList
        {
            get
            {
                return usersList;
            }
            set
            {
                usersList = value;
            }
        }

        internal async Task<bool> OfferFeedback()
        {
            bool x = true;

            return x;

        }

        public UserModel SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
            }
        }

        public string SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
            }
        }
        

        public OfferViewModel()
        {
            this.usersList = new List<string>();
            //this.usersList = new List<UserModel>();
            for (int i = 0; i < 10; i++)
            {
                UserModel um = new UserModel() { FirstName = "Seba", LastName = i.ToString(), Password = "", Username = "" };
                this.usersList.Add(um.ToString());
            }
        }       
    }
}
