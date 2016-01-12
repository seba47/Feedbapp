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
        private IRepository<User> local_repository;
        private IRepository<User> remote_repository;

        public UserModel()
        {
            remote_repository = new RemoteRepository_User();
            local_repository = new LocalRepository_User();
        }

        #region "Remote methods"
        public async Task<User> GetUserByUsername(string username)
        {
            return await ((RemoteRepository_User)this.remote_repository).GetUserByUsername(username);
        }
        #endregion


        #region "Local methods"
        public User Local_CheckLogin()
        {
            return ((LocalRepository_User)this.local_repository).getUser();
        }

        public async Task<User> Local_CreateUser(User localUser, LocalRepository_User localRepo, string username, string password)
        {
            if (localUser == null)
            {
                User u = new User();
                u.Id = "1";
                u.firstName = "Seba";
                u.lastName = "Cabrera";
                u.username = username;
                u.password = password;
                await localRepo.Add(u);
                return null;
            }
            return localUser;
        }
        #endregion

        /// <summary>
        /// Method which get the local stored user (if exist) and after that It is checked in the database (by the webapi)
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsLogged()
        {
            var storedUser = Local_CheckLogin();
            if (storedUser != null && storedUser.userId != 0)
            {
                var user = await ((RemoteRepository_User)remote_repository).GetUserByUsername(storedUser.username);                   
                if (user != null && user.password.Equals(storedUser.password))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Login(string username, string password)
        {
            User u= await ((RemoteRepository_User)remote_repository).GetUserByUsername(username);

            //List<User> userList = await ((RemoteRepository_User)remote_repository).Get();

            if (u != null && u.password.Equals(password))
            {
                //Persist the user data in device
                await local_repository.Add(u);
                return true;
            }                
            else
                return false;

        }


        public List<User> GetUsers()
        {
            List<User> users =  Task.Run(()=>((RemoteRepository_User)remote_repository).Get()).Result;

            //List<User> users = new List<User>();

            ////this.usersList = new List<UserModel>();
            //for (int i = 0; i < 10; i++)
            //{
            //    User um = new User() { firstName = "Seba", lastName = i.ToString(), password = "", username = "" };
            //    users.Add(um);
            //}
            return users;
        }
    }
}
