using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kiemtragiuaki.Data;
using Kiemtragiuaki.Models;

namespace Kiemtragiuaki.Pages.Rooms
{
    public class EditModel : PageModel
    {
        private readonly BoardingHouseContext _context;

        public EditModel(BoardingHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room_BIT240120 Room { get; set; } = new();

        public List<RoomType_BIT240120> RoomTypes { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Rooms_BIT240120.FirstOrDefaultAsync(r => r.Id == id);

            if (Room == null)
            {
                return NotFound();
            }

            RoomTypes = await _context.RoomTypes_BIT240120.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RoomTypes = await _context.RoomTypes_BIT240120.ToListAsync();

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
                return Page();
            }

            // Validate unique room name within room type (excluding current room)
            var exists = await _context.Rooms_BIT240120
                .AnyAsync(r => r.Name == Room.Name && r.RoomTypeId == Room.RoomTypeId && r.Id != Room.Id);

            if (exists)
            {
                ModelState.AddModelError("Room.Name",
                    "A room with this name already exists in this room type.");
                return Page();
            }

            // Validate room type exists
            var roomTypeExists = await _context.RoomTypes_BIT240120
                .AnyAsync(rt => rt.Id == Room.RoomTypeId);

            if (!roomTypeExists)
            {
                ModelState.AddModelError("Room.RoomTypeId", "Selected room type does not exist.");
                return Page();
            }

            _context.Attach(Room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(Room.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating room: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Exception: {ex}");
                return Page();
            }

            return RedirectToPage("Details", new { id = Room.Id });
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms_BIT240120.Any(e => e.Id == id);
        }
    }
}
