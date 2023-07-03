using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.DBClasses;

namespace Ecommerce.DataProvider
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) { }

        public DbSet<RegisterUser> registerUsers { get; set; }

        public DbSet<RegisterUserAddress> registerUsersAddress { get; set; }
    }
}
