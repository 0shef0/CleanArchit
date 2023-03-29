using CleanArchit.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchit.Infrastructure.Data.Context
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
        /*public DbSet<Teacher> Teachers { get; set; }*/
    }
}