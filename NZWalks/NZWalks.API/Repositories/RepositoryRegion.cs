﻿using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RepositoryRegion : IRegionRepository
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

        public async Task<Region> GetAsync(Guid Id)
        {
            return await nZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalksDBContext.AddAsync(region);
            await nZWalksDBContext.SaveChangesAsync();
            return region;

        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region = await nZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            nZWalksDBContext.Regions.Remove(region);
            await nZWalksDBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await nZWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await nZWalksDBContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
