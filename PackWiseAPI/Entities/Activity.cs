using System.ComponentModel.DataAnnotations;
 using System.ComponentModel.DataAnnotations.Schema;

    namespace PackWiseAPI.Entities
    {
        public class Activity
        {
            [Key]
            public int ActivityID { get; set; }

            [ForeignKey("TripCategory")]
            public int CategoryID { get; set; }

            [Required]
            public string ActivityName { get; set; }

            // Navigation property
            public TripCategory TripCategory { get; set; }
        }
    }
