using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSApi.Models
{
    public class UserDetailsContext : DbContext
    {
        public UserDetailsContext(DbContextOptions<UserDetailsContext> dbContextOptions) : base(dbContextOptions)
        { 
            
        }
        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
