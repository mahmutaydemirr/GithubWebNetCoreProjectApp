using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNetCoreProjectApp.Data
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> opts): base(opts)
        {

        }

        public DbSet<WebSitePassword> WebSitePasswords { get; set; }
        public DbSet<WebSitePasswordHistory> WebSitePasswordHistories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebSitePassword>().HasMany(e =>
            e.PasswordHistories).WithOne(e =>
            e.WebSitePassword).HasForeignKey(e =>
            e.WebSitePasswordId).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
