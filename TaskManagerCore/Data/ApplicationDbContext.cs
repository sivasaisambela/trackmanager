using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaskManagerCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TaskManagerCore.Identity;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskManagerCore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=False;Initial Catalog=TaskManagerCoreDb; Trusted_Connection=True; MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var keysProperties = builder.Model.GetEntityTypes().Select(x => x.FindPrimaryKey()).SelectMany(x => x.Properties);
            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
        }

    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Integrated Security=False;Initial Catalog=TaskManagerCoreDb; Trusted_Connection=True; MultipleActiveResultSets=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
