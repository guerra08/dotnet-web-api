using Microsoft.EntityFrameworkCore;
using DotnetWebApi.Models;

namespace DotnetWebApi.Contexts
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> opt) : base(opt)
        { }

        public DbSet<Student> Students { get; set; }
    }
}
