using Feedbapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        
        public async Task<UserModel> Login()
        {
            if(!string.IsNullOrWhiteSpace(this.username) && !string.IsNullOrWhiteSpace(this.password)) {
                Services.RestService rest = new Services.RestService();
                //Services.RestService restService = new Services.RestService();
                UserModel um = await rest.GetUser(username, password);
                return um;
            }
            return null;     
        }
    }
}
