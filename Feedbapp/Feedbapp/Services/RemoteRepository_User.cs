using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;

namespace Feedbapp.Services
{
    public class RemoteRepository_User: RemoteRepository<User>
    {
        public RemoteRepository_User() : base("user"){
            
        }

        public async Task<User> GetUserByUsername(string username)
        {
            UriString parameters = new UriString();
            parameters.Add("username", username);
            return await this.Get(parameters, "GetByUsername");
        }
    }
}
