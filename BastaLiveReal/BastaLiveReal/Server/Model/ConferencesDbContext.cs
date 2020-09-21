using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BastaLiveReal.Server.Model
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
