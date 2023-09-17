using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RepositoryRegion:IRegionRepository
    {
        private readonly NZWalksDBContext nZWalksDBContext;

        public RepositoryRegion(NZWalksDBContext nZWalksDBContext)
        {
            this.nZWalksDBContext = nZWalksDBContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDBContext.Regions.ToListAsync();
        }
    }
}
