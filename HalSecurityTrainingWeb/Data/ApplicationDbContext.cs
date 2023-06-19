using HalSecurityTrainingWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HalSecurityTrainingWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
