using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace MyWebApp.Pages
{
    public class GenreModel : PageModel
    {
        // Create a property to hold the selected genre
        public int SelectedGenre { get; set; }

        // Create a property to hold the list of movies with the selected genre
        public List<Movie> MoviesWithGenre { get; set; }

        // OnGet method to retrieve the selected genre from the query parameters
        public IActionResult OnGet(int genreId)
        {
            // Store the selected genre in the property
            SelectedGenre = genreId;

            // Call the MovieApiService to get the movies with the selected genre
            var movieApiService = new MovieApiService();
            MoviesWithGenre = movieApiService.GetMoviesByGenre(genreId);
            return Page();
        }
    }
}
