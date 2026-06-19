using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kiemtragiuaki.Models
{
    public class RoomImage_BIT240120
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        [StringLength(500, ErrorMessage = "URL cannot be longer than 500 characters")]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Display(Name = "Thumbnail")]
        public bool IsThumbnail { get; set; }

        [Required(ErrorMessage = "Room is required")]
        public int RoomId { get; set; }

        // Navigation property
        [ForeignKey("RoomId")]
        public Room_BIT240120? Room { get; set; }
    }
}
