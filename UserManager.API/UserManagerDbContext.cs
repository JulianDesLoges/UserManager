using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Shared.Models;

namespace UserManager.API
{
    public class UserManagerDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<UserGroup> UserGroup { get; set; }


        public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options)
            : base(options) { }
    }
}
