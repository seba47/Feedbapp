using Feedbapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Services
{
    public class RemoteRepository_User : RemoteRepository<User>
    {
        public RemoteRepository_User() : base("User")
        {
        }

        public async Task<User> GetUserByUsername(string username)
        {
            //return new User() { firstName = "seba", password = "pass", username = "seba47" };
            UriString parameters = new UriString();
            parameters.Add("username", username);
            return await Get(parameters, "GetByUsername");
        }
    }
}