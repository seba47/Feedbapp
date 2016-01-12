using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;


namespace Feedbapp.ViewModels
{
    public abstract class BaseReqOffViewModel
    {
        protected List<string> namesList;
        protected List<User> usersList;
        protected User selectedSender;
        protected User selectedRecipient;
        protected string comments;
        protected int selectedIndexSender;
        protected int selectedIndexRecipient;
        protected string buttonText;
        protected string pageTitle;
        protected RequestOfferModel model;
        protected UserModel um;

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

        public string PageTitle
        {
            get
            {
                return pageTitle;
            }
            set
            {
                pageTitle = value;
            }
        }

        public string ButtonText
        {
            get
            {
                return buttonText;
            }
            set
            {
                buttonText = value;
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

        public List<User> UsersList
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
            return false;
        }

        public User SelectedSender
        {
            get
            {
                return selectedSender;
            }
            set
            {
                selectedSender = value;
            }
        }
        public User SelectedRecipient
        {
            get
            {
                return selectedRecipient;
            }
            set
            {
                selectedRecipient = value;
            }
        }

        public int SelectedIndexSender
        {
            get
            {
                return selectedIndexSender;
            }
            set
            {
                selectedIndexSender = value;
            }
        }

        public int SelectedIndexRecipient
        {
            get
            {
                return selectedIndexRecipient;
            }
            set
            {
                selectedIndexRecipient = value;
            }
        }

        public BaseReqOffViewModel()
        {
            this.um = new UserModel();
            this.model = new RequestOfferModel();
            this.UsersList = um.GetUsers();
            this.NamesList = new List<string>();
            foreach (User u in this.UsersList)
            {
                this.NamesList.Add(u.ToString());
            }       
        }
    }
}
