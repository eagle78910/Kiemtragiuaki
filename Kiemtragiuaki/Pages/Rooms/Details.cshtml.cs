using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kiemtragiuaki.Data;
using Kiemtragiuaki.Models;

namespace Kiemtragiuaki.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly BoardingHouseContext _context;

        public DetailsModel(BoardingHouseContext context)
        {
            _context = context;
        }

        public Room_BIT240120? Room { get; set; }
        public string? ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                ErrorMessage = "Room ID is required.";
                return RedirectToPage("Index");
            }

            Room = await _context.Rooms_BIT240120
                .Include(r => r.RoomType)
                .Include(r => r.Images)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (Room == null)
            {
                ErrorMessage = $"Room with ID {id} not found.";
                return RedirectToPage("Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? roomId)
        {
            if (roomId == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms_BIT240120.FindAsync(roomId);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms_BIT240120.Remove(room);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
