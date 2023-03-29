
using CleanArchit.Presantation.MVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchit.Presantation.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TeacherIdentity>().Property(x => x.Name).HasMaxLength(128);
            builder.Entity<TeacherIdentity>().Property(x => x.DateOfBirth);
            builder.Entity<TeacherIdentity>().Property(x => x.SecondName).HasMaxLength(128);
            builder.Entity<TeacherIdentity>().Property(x => x.Sirname).HasMaxLength(128);
        }
        public DbSet<TeacherIdentity> Teachers { get; set; }
    }
}