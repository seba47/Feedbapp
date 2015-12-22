using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;



namespace Feedbapp.ViewModels
{
    public class LoginViewModel
    {
        private string username;
        private string password;
        
        public string Username
        {
            get
            {
                return username ;
            }
            set
            {
                username= value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        
        public LoginViewModel()
        {

        }
        
        public async Task<User> Login()
        {
            if(!string.IsNullOrWhiteSpace(this.username) && !string.IsNullOrWhiteSpace(this.password)) {
                UserModel um = new UserModel();
                User u= await um.IsLogged(username,password);
                return u;
            }
            return null;     
        }
    }
}
