using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Model.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be minimum of 100 character")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Code has to be minimum of 3 character")]
        [MaxLength (3, ErrorMessage = "Code has to be a maximum of 3 character")]
        public string Code { get; set; }

        public string? RegionImageurl { get; set; }
    }
}
