namespace NZwalks.API.Model.Domain
{
    public class Walk
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalksImageUrl { get; set; }

        public Guid DifficultyID { get; set; }

        public Guid RegionID { get; set; }

        // Navigaton properties 

        public Difficulty Difficulty { get; set; }

        public Region Region { get; set; }

    }
}
