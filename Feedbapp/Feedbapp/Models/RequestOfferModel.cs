using Feedbapp.Entities;
using Feedbapp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Models
{
    public class RequestOfferModel
    {
        private IRepository<Requested> repository_requested;
        private IRepository<Offered> repository_offered;

        public RequestOfferModel()
        {
            this.repository_requested = new RemoteRepository_Requested();
            this.repository_offered = new RemoteRepository_Offered();
        }

        public async Task<int> SendRequest(Requested r)
        {
            int ret = 0;
            ret = await repository_requested.Add(r);
            return ret;
        }

        public async Task<int> SendOffer(Offered o)
        {
            int ret = 0;
            ret = await repository_offered.Add(o);
            return ret;
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