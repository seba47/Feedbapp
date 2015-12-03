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

        public UserModel Get(string username)
        {
            return new UserModel
            {
             FirstName="Pepito",
             LastName="Rodriguez",
             Password="seba",
             Username=username 
            };
        }
    }
}