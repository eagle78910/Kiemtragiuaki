using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kiemtragiuaki.Data;
using Kiemtragiuaki.Models;

namespace Kiemtragiuaki.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly BoardingHouseContext _context;

        public CreateModel(BoardingHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room_BIT240120 Room { get; set; } = new();

        public List<RoomType_BIT240120> RoomTypes { get; set; } = new();

        public async Task OnGetAsync()
        {
            RoomTypes = await _context.RoomTypes_BIT240120.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            RoomTypes = await _context.RoomTypes_BIT240120.ToListAsync();

            // Log validation errors for debugging
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine($"Validation Error: {error.ErrorMessage}");
                }
                return Page();
            }

            // Validate room type is selected
            if (Room.RoomTypeId == 0)
            {
                ModelState.AddModelError("Room.RoomTypeId", "Please select a room type.");
                return Page();
            }

            // Validate unique room name within room type
            var exists = await _context.Rooms_BIT240120
                .AnyAsync(r => r.Name == Room.Name && r.RoomTypeId == Room.RoomTypeId);

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

            try
            {
                _context.Rooms_BIT240120.Add(Room);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating room: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Exception: {ex}");
                return Page();
            }
        }
    }
}
