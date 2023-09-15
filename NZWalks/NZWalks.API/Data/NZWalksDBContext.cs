using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext: DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options): base(options)
        {
            
        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Region> Walks { get; set; }
        public DbSet<Region> WalkDifficulty { get; set; }

    }
}
