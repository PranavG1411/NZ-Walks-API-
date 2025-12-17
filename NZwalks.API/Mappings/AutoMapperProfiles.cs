using AutoMapper;
using NZwalks.API.Model.Domain;
using NZwalks.API.Model.DTO;

namespace NZwalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Region, RegionsDTO>().ReverseMap();

            CreateMap<AddRegionRequestDto, Region>().ReverseMap();

            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();

            CreateMap<Walk,WalkDTOcs>().ReverseMap();

            CreateMap<WalkDTOcs, Walk>().ReverseMap();

            CreateMap<Difficulty , DifficultyDTO>().ReverseMap();

            CreateMap<UpdateWalksDTO , Walk> ().ReverseMap();

        }
    }
}
