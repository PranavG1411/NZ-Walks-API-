using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Model.Domain;

namespace NZwalks.API.Repositories
{
    public interface IWalkREpositorycs
    {
        Task<Walk> CreateAsync(Walk walk);

        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool? isAscending = true , int Page = 1,  int PageSize = 1000 );

        Task<Walk> GetWalkByIDAsync(Guid id);

        Task<Walk?> PutAsync(Guid id , Walk walks);

        Task<Walk?> DeleteAsync(Guid id);
    }
}
