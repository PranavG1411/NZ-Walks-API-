
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Model.Domain;

namespace NZwalks.API.Repositories
{
    public class SQLWalkRepositoriescs : IWalkREpositorycs
    {

        public readonly NZwalksDBContextcs dBContextcs;

        public SQLWalkRepositoriescs(NZwalksDBContextcs dBContextcs)
        {
            this.dBContextcs = dBContextcs;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dBContextcs.Walks.AddAsync(walk);
            await dBContextcs.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null , string? filterQuery= null, string? sortBy = null, bool? isAscending = true, int Page = 1,  int PageSize = 1000 )
        {
            var walks = dBContextcs.Walks.Include("Difficulty").Include("Region").AsQueryable();
            //return await dBContextcs.Walks.Include("Difficulty").Include("Region").ToListAsync();

            // Filtering

            if (string.IsNullOrEmpty(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // Sorting 
            if(string.IsNullOrEmpty(sortBy) == false )
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = (bool)isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }else if (sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase ))
                {
                    walks = (bool)isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderBy(x => x.LengthInKm);
                }

            }

            // pagination 

            var skipResult = (Page - 1) * PageSize;
            
            return await walks.Skip(skipResult).Take(PageSize).ToListAsync();

            //return await walks.ToListAsync();
        }

        public async Task<Walk> GetWalkByIDAsync(Guid id)
        {
            return await dBContextcs.Walks
                .Include(w => w.Difficulty)
                .Include(w => w.Region)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Walk?> PutAsync(Guid id, Walk walk)
        {
            var existingModel = await dBContextcs.Walks.FirstOrDefaultAsync(w => w.Id == id);

            if (existingModel == null)
            {
                return null;


            }

            existingModel.Name = walk.Name;
            existingModel.Description = walk.Description;
            existingModel.LengthInKm = walk.LengthInKm;
            existingModel.WalksImageUrl = walk.WalksImageUrl;
            existingModel.DifficultyID = walk.DifficultyID;
            existingModel.RegionID = walk.RegionID;

            await dBContextcs.SaveChangesAsync();


            return existingModel;

        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await dBContextcs.Walks.FirstOrDefaultAsync(w => w.Id == id);

            if(existingWalk == null)
            {
                return null; 
            }

            dBContextcs.Walks.Remove(existingWalk);
            await dBContextcs.SaveChangesAsync();
            return existingWalk;
        }


    }
}
