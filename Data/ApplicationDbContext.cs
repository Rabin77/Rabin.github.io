using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ghardailo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Ghardailo.Models.Admin_Login> Admin_Login { get; set; }
       public DbSet<Ghardailo.Models.manager> managers { get; set; }
        public DbSet<Ghardailo.Models.Product_Details> Product_Details { get; set; }
        
        public DbSet<Ghardailo.Models.Category> Cateogry { get; set; }
      
    }
}
