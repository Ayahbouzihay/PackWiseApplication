using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackWiseAPI.Entities
{
    public class PackingRecommendation
    {
        [Key]
        public int RecommendationID { get; set; }

        [Required]
        public int TravelerID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TripCategoryID { get; set; }

        [Required]
        public int CriteriaID { get; set; }

        [Required]
        public string Recommendations { get; set; }

    }
}
