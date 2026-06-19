using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kiemtragiuaki.Data;
using Kiemtragiuaki.Models;

namespace Kiemtragiuaki.Pages.RoomTypes
{
    public class CreateModel : PageModel
    {
        private readonly BoardingHouseContext _context;

        public CreateModel(BoardingHouseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomType_BIT240120 RoomType { get; set; } = new();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RoomTypes_BIT240120.Add(RoomType);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
