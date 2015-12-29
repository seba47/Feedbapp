using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class WebAPIDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Offered> Offered { get; set; }
        public DbSet<Requested> Requested { get; set; }
    }
}