using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthMVC1.Model {
    public class UsersDbContext : IdentityDbContext {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) {
        }
        // public DbSet<User> Users { get; set; }
    }
}
