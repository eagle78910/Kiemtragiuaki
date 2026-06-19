using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Kiemtragiuaki.Data;
using Kiemtragiuaki.Models;

namespace Kiemtragiuaki.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly BoardingHouseContext _context;

        public IndexModel(BoardingHouseContext context)
        {
            _context = context;
        }

        public IList<Room_BIT240120> Rooms { get; set; } = default!;
        public IList<RoomType_BIT240120> RoomTypes { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? FilterRoomType { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool? FilterAvailable { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        public async Task OnGetAsync()
        {
            // Load room types for the filter dropdown
            RoomTypes = await _context.RoomTypes_BIT240120.ToListAsync();

            // Start with base query
            var query = _context.Rooms_BIT240120
                .Include(r => r.RoomType)
                .Include(r => r.Images)
                .AsQueryable();

            // Apply search filter
            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(r => r.Name.Contains(SearchString));
            }

            // Apply room type filter
            if (FilterRoomType.HasValue && FilterRoomType > 0)
            {
                query = query.Where(r => r.RoomTypeId == FilterRoomType);
            }

            // Apply availability filter
            if (FilterAvailable.HasValue)
            {
                query = query.Where(r => r.IsAvailable == FilterAvailable);
            }

            // Apply price filter
            if (MaxPrice.HasValue && MaxPrice > 0)
            {
                query = query.Where(r => r.Price <= MaxPrice);
            }

            // Apply sorting
            query = SortOrder switch
            {
                "price_desc" => query.OrderByDescending(r => r.Price),
                "area_desc" => query.OrderByDescending(r => r.Area),
                _ => query.OrderBy(r => r.Price) // default: price ascending
            };

            Rooms = await query.ToListAsync();
        }
    }
}
