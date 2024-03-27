using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackWiseAPI.Entities
{
    public class PackingRecommendation
    {
        [Key]
        public int RecommendationID { get; set; }

        [ForeignKey("Traveler")]
        public int TravelerID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("TripCategory")]
        public int TripCategoryID { get; set; }

        [ForeignKey("WeatherCriteria")]
        public int CriteriaID { get; set; }

        [Required]
        public string Recommendations { get; set; }

        // Navigation properties
        public Traveler Traveler { get; set; }
        public TripCategory TripCategory { get; set; }
        public WeatherCriteria WeatherCriteria { get; set; }

        public string Date1 { get; set; }
    }
}
    
