using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackWiseAPI.Entities
{
    public class TripCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
    public class Activity
    {
        [ForeignKey("TripCategory")]
        public string CategoryName { get; set; }


        [ForeignKey("TripCategory")]
        public int CategoryID { get; set; }

        [Required]
        public string ActivityName { get; set; }

    }
}