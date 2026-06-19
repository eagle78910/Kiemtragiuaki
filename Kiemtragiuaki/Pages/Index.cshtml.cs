using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kiemtragiuaki.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Response.Redirect("/Rooms");
        }
    }
}
