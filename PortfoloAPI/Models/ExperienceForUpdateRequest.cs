using System.ComponentModel.DataAnnotations;

namespace PortfoloAPI.Models
{
    public class ExperienceForUpdateRequest
    {
        [Required]
        public string Title { get; set; }
        [Required] 
        public string Description { get; set; }
        [Required]
        [Url]
        public string ImagePath { get; set; }
    }
}
