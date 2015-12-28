using System;
using System.Collections.Generic;
using System.Linq;

namespace Feedbapp.Entities
{

    public class User: TEntity
    {
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1}", this.firstName, this.lastName); 
        }
    }
}