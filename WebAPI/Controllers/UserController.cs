using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WebAPI.Models;
using WebAPI.Providers;
using WebAPI.Results;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        // GET: User
        public UserController()
        {

        }


        public string[] Get()
        {
            return new string[]
            {
             "Hello",
             "World"
            };
        }

        public User Get(string id)
        {
            return new User
            {
                FirstName = "Pepito",
                LastName = "Rodriguez",
                Password = "seba",
                Username = "Usernamee",
                Id = int.Parse(id)
            };
        }

        public User GetByUsername(string username)
        {
            return new User
            {
                FirstName = "Pepito",
                LastName = "GetByUsername",
                Password = "seba",
                Username = username,
                Id = 1
            };
        }

    }
}