using NZwalks.API.Model.Domain;

namespace NZwalks.API.Repositories
{
    public interface IRegionRepositories
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIDAsync(Guid id);

        Task<Region> CreateAsync(Region region); 

        Task<Region?> UpdateAsync(Guid id , Region region);

        Task<Region?> DeleteAsync(Guid id);
    }
}
