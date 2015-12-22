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
            this.repository = new RemoteRepository_User();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await ((RemoteRepository_User)this.repository).GetUserByUsername(username);
        }

        public async Task<User> IsLogged(string username, string password)
        {

            LocalRepository_User localRepo = new LocalRepository_User();

            //User u = new User();
            //u.Id = "1";
            //u.FirstName = "Seba";
            //u.LastName = "Cabrera";
            //u.Username = "seba47";
            //u.Password = "seba";

            //await localRepo.Add(u);



            User localUser = await localRepo.getUser(username, password);
            return await CreateUser(localUser, localRepo, username, password);
        }

        public async Task<User> CreateUser(User localUser,LocalRepository_User localRepo, string username, string password)
        {
            if (localUser == null)
            {
                User u = new User();
                u.Id = "1";
                u.FirstName = "Seba";
                u.LastName = "Cabrera";
                u.Username = username;
                u.Password = password;

                await localRepo.Add(u);
                return null;
            }
            return localUser;
        }
    }
}
