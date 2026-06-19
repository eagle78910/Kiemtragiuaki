using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kiemtragiuaki.Data;
using Kiemtragiuaki.Models;

namespace Kiemtragiuaki.Pages.Rooms
{
    public class ManageImagesModel : PageModel
    {
        private readonly BoardingHouseContext _context;

        public ManageImagesModel(BoardingHouseContext context)
        {
            _context = context;
        }

        public Room_BIT240120? Room { get; set; }
        public string? ErrorMessage { get; set; }

        [BindProperty]
        public RoomImage_BIT240120 NewImage { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Rooms_BIT240120
                .Include(r => r.Images)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (Room == null)
            {
                return NotFound();
            }

            NewImage.RoomId = id.Value;
            return Page();
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            if (!ModelState.IsValid)
            {
                return await OnGetAsync(NewImage.RoomId);
            }

            // Validate room exists
            var room = await _context.Rooms_BIT240120
                .Include(r => r.Images)
                .FirstOrDefaultAsync(r => r.Id == NewImage.RoomId);

            if (room == null)
            {
                return NotFound();
            }

            // Check maximum 1 thumbnail
            if (NewImage.IsThumbnail && room.Images.Any(i => i.IsThumbnail))
            {
                ErrorMessage = "Only one thumbnail image is allowed per room.";
                Room = room;
                return Page();
            }

            room.Images.Add(NewImage);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { id = NewImage.RoomId });
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? imageId, int? roomId)
        {
            if (imageId == null || roomId == null)
            {
                return NotFound();
            }

            var image = await _context.RoomImages_BIT240120.FindAsync(imageId);
            if (image == null)
            {
                return NotFound();
            }

            _context.RoomImages_BIT240120.Remove(image);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { id = roomId });
        }

        public async Task<IActionResult> OnPostSetThumbnailAsync(int? imageId, int? roomId)
        {
            if (imageId == null || roomId == null)
            {
                return NotFound();
            }

            var image = await _context.RoomImages_BIT240120.FindAsync(imageId);
            if (image == null)
            {
                return NotFound();
            }

            // Get all images for this room
            var allImages = await _context.RoomImages_BIT240120
                .Where(i => i.RoomId == roomId)
                .ToListAsync();

            // Remove old thumbnail status
            foreach (var img in allImages.Where(i => i.IsThumbnail))
            {
                img.IsThumbnail = false;
            }

            // Set new thumbnail
            image.IsThumbnail = true;

            await _context.SaveChangesAsync();

            return RedirectToPage(new { id = roomId });
        }
    }
}
