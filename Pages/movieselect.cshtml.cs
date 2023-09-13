using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebApp.Pages
{
    public class movieselectModel : PageModel
    {
        public IActionResult OnPost(string SelectedGenre)
        {
            // Redirect to the Genre page with the selected genre as a query parameter
            return RedirectToPage("/genre", new { genre = SelectedGenre });
        }
    }
}
