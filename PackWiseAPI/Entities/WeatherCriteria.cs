using System.ComponentModel.DataAnnotations;

namespace PackWiseAPI.Entities
{
    public class WeatherCriteria
    {
        [Key]
        public int CriteriaID { get; set; }

        // Add other properties as needed
    }
}