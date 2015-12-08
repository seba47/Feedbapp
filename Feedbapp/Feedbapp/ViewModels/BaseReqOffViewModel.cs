using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Feedbapp.ViewModels
{
    public abstract class BaseReqOffViewModel
    {
        protected List<string> namesList;
        protected List<UserModel> usersList;
        protected UserModel selectedUser;
        protected string comments;
        protected int selectedIndex;

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

        public List<string> NamesList
        {
            get
            {
                return namesList;
            }
            set
            {
                namesList = value;
            }
        }

        public List<UserModel> UsersList
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

        internal virtual async Task<bool> Send()
        {
            int test = this.SelectedIndex;
            string comm = this.Comments;
            UserModel selected = this.UsersList[this.SelectedIndex];
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

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
            }
        }

        public BaseReqOffViewModel()
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
    }
}
