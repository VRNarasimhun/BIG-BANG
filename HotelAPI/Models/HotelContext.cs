using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelAPI.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
