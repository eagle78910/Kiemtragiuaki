using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kiemtragiuaki.Data;
using Kiemtragiuaki.Models;

namespace Kiemtragiuaki.Pages.RoomTypes
{
    public class IndexModel : PageModel
    {
        private readonly BoardingHouseContext _context;

        public IndexModel(BoardingHouseContext context)
        {
            _context = context;
        }

        public IList<RoomType_BIT240120> RoomTypes { get; set; } = default!;
        public Dictionary<int, int> RoomCounts { get; set; } = new();
        public string? DeleteErrorMessage { get; set; }

        public async Task OnGetAsync()
        {
            RoomTypes = await _context.RoomTypes_BIT240120
                .Include(rt => rt.Rooms)
                .ToListAsync();

            // Count rooms for each room type
            foreach (var roomType in RoomTypes)
            {
                RoomCounts[roomType.Id] = roomType.Rooms.Count;
            }
        }

        public async Task OnPostDeleteAsync(int? id)
        {
            if (id == null)
            {
                return;
            }

            var roomType = await _context.RoomTypes_BIT240120
                .Include(rt => rt.Rooms)
                .FirstOrDefaultAsync(rt => rt.Id == id);

            if (roomType == null)
            {
                return;
            }

            // Check if room type has rooms
            if (roomType.Rooms.Count > 0)
            {
                DeleteErrorMessage = $"Cannot delete '{roomType.Name}' because it has {roomType.Rooms.Count} room(s). Delete all rooms in this type first.";
                // Reload the page with error message
                await OnGetAsync();
                return;
            }

            _context.RoomTypes_BIT240120.Remove(roomType);
            await _context.SaveChangesAsync();
        }
    }
}
