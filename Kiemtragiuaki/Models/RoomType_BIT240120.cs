using System.ComponentModel.DataAnnotations;

namespace Kiemtragiuaki.Models
{
    public class RoomType_BIT240120
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Room type name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string? Description { get; set; }

        // Navigation property
        public ICollection<Room_BIT240120> Rooms { get; set; } = new List<Room_BIT240120>();
    }
}
