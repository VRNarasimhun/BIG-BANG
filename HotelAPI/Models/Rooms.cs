using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Rooms
    {
        [Key]
        public int R_id { get; set; }
        public int H_id { get; set; }
        [ForeignKey("H_id")]
        public Hotel? Hotel { get; set; }
        public double Price { get; set; }
        
        public int Capacity { get; set; }
        
        public string Type { get; set; }
    }
}
