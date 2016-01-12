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
        private UserModel um;

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
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
            um = new UserModel();
        }

        public async Task<bool> IsLogged()
        {
            return await um.IsLogged();            
        }

        public async Task<bool> Login()
        {
            if (!string.IsNullOrWhiteSpace(this.username) && !string.IsNullOrWhiteSpace(this.password))
            {
                bool u= await um.Login(username,password);
                return u;
            }
            return false;
        }
    }
}
