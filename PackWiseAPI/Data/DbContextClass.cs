using PackWiseAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace PackWiseAPI.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        { }
        //Ayah-mounina Bouzihay, Ayah-mounina Bouzihay
        public DbSet<TripCategory> TripCategory { get; set; }

        //Ayden Pratt, Ayah-mounina Bouzihay
        public DbSet<PackingRecommendation> PackingRecommendation { get; set; }
    }
}
