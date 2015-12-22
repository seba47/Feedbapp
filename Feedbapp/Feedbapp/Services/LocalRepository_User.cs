using Feedbapp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbapp.Services
{
    public class LocalRepository_User : LocalRepository<User>
    {
        public LocalRepository_User():base()
        {

        }

        public async Task<User> getUser(string username, string password)
        {
            //List<User> userList = database.Query<User>("SELECT * FROM [User] WHERE [Username] = '" + username + "' AND [Password] " + password + "'");
            var u = database.Table<User>().FirstOrDefault<User>(x => x.Username == username && x.Password == password);
            List<User> userList = new List<User>();
            userList.Add(u);
            return await Task.Run(() => userList.First<User>());
        }

    }
}
