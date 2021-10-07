using Microsoft.EntityFrameworkCore;
using Week11Task.Models;

namespace Week11Task.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Unit> Units { get; set; }
    }
}
