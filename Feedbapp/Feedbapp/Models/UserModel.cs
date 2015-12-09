using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Services;
using Feedbapp.Entities;
namespace Feedbapp.Models
{
    public class UserModel
    {
        private IRepository<User> repository;

        public UserModel()
        {            
            this.repository = new UserRepository();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await ((UserRepository)this.repository).GetUserByUsername(username);
        }
    }
}
