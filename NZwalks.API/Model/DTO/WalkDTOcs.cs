using NZwalks.API.Model.Domain;

namespace NZwalks.API.Model.DTO
{
    public class WalkDTOcs
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalksImageUrl { get; set; }


        // Navigaton properties 

       public RegionsDTO Region { get; set; }

        public DifficultyDTO Difficulty { get; set; }
    }
}
