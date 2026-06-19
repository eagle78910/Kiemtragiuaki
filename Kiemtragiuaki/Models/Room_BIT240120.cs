using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kiemtragiuaki.Models
{
    public class Room_BIT240120
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Room name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Area is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Area must be greater than 0")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Area { get; set; }

        [Display(Name = "Available")]
        public bool IsAvailable { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Room type is required")]
        [Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        // Navigation properties
        [ForeignKey("RoomTypeId")]
        public RoomType_BIT240120? RoomType { get; set; }

        public ICollection<RoomImage_BIT240120> Images { get; set; } = new List<RoomImage_BIT240120>();

        // Calculated property for display
        [NotMapped]
        public decimal PricePerSquareMeter => Area > 0 ? Price / Area : 0;
    }
}
