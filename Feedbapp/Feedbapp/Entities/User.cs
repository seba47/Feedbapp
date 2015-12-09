using System;
using System.Collections.Generic;
using System.Linq;

namespace Feedbapp.Entities
{

    public class User: TEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName); 
        }
    }
}