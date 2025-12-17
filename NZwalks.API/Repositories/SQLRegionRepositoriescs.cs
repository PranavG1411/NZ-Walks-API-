using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Model.Domain;

namespace NZwalks.API.Repositories
{
    public class SQLRegionRepositoriescs : IRegionRepositories
    {

        private readonly NZwalksDBContextcs dBContext;


        public SQLRegionRepositoriescs(NZwalksDBContextcs dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dBContext.Regions.AddAsync(region);
            await dBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id )
        {
            var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            dBContext.Regions.Remove(existingRegion);
            await dBContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dBContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIDAsync(Guid id)
        {
            return await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id , Region region)
        {
            var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageurl = region.RegionImageurl;
            await dBContext.SaveChangesAsync();
            return existingRegion;

        }
    }
}
