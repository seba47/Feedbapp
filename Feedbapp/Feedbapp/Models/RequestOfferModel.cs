using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Services;
using Feedbapp.Entities;
namespace Feedbapp.Models
{
    public class RequestOfferModel
    {
        private IRepository<User> repository;

        public RequestOfferModel()
        {            
            this.repository = new RemoteRepository_User();
        }

        public List<User> GetUsersList()
        {
            List<User> usersList = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                User um = new User() { firstName = "Seba", lastName = i.ToString(), password = "", username = "" };
                usersList.Add(um);
            }
            return usersList;
        }
    }
}
