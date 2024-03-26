using System.ComponentModel.DataAnnotations;

namespace PackWiseAPI.Entities
{
    public class Traveler
    {
        [Key]
        public int TravelerID { get; set; }

        // Add other properties as needed
    }
}