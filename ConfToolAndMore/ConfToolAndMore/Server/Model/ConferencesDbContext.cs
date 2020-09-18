using Microsoft.EntityFrameworkCore;

namespace ConfToolAndMore.Server.Model
{
    public class ConferencesDbContext : DbContext
    {
        public ConferencesDbContext() { }

        public ConferencesDbContext(DbContextOptions<ConferencesDbContext> options)
        : base(options)
        {
        }

        public DbSet<Conference> Conferences { get; set; }
    }
}
