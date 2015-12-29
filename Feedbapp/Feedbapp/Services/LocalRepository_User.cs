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

        public User getUser()
        {
            var list = database.Table<User>().All(t => t.userId > 0);
            int countt = database.Table<User>().Count();
            var u = database.Table<User>().FirstOrDefault<User>();
            return u;
        }

        public User getUser(string username, string password)
        {
            var u = database.Table<User>().FirstOrDefault<User>(x => x.username == username && x.password == password);
            List<User> userList = new List<User>();
            userList.Add(u);
            return userList.First<User>();
        }

    }
}
