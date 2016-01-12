using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebAPI.Models
{

    public class User 
    {
        [Key]
        public int userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}