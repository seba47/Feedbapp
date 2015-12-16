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
            this.repository = new UserRepository();
        }

        public List<User> GetUsersList()
        {
            List<User> usersList = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                User um = new User() { FirstName = "Seba", LastName = i.ToString(), Password = "", Username = "" };
                usersList.Add(um);
            }
            return usersList;
        }
    }
}
