using PackWiseAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace PackWiseAPI.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        { }
        public DbSet<TripCategory> TripCategory { get; set; }
    }
}
