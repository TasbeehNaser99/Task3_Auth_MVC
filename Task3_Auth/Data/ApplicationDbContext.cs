using Microsoft.EntityFrameworkCore;
using Task3_Auth.Models;

namespace Task3_Auth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

    }
}
