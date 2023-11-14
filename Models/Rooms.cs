using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class Rooms
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        public double Price { get; set; }
        
        public string? Image { get; set; }
        [Required]
        public int RoomNo { get; set; }
        [Required]
        public int IdHotels { get; set; }



    }
}
