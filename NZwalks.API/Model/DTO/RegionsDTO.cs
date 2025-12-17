namespace NZwalks.API.Model.DTO
{
    public class RegionsDTO
    {
        // which return this Data to the Client

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string? RegionImageurl { get; set; }
    }
}
