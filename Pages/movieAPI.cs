using RestSharp;
using System.Collections.Generic;
using System.Linq;

public class MovieApiService
{
    private readonly string apiKey = "82bebf7cf2f1013619b844d8a7584908";

    // Method to get movies by genre
    public List<Movie> GetMoviesByGenre(int genre)
    {
        var client = new RestClient("https://api.themoviedb.org/3/discover/movie");
        var request = new RestRequest();
        request.AddParameter("api_key", apiKey);
        request.AddParameter("with_genres", genre);

        var response = client.Execute<SearchResult>(request);

        var filteredMovies = response.Data.Results;

        // If there are fewer than 20 movies with the selected genre, make additional requests
        while (filteredMovies.Count < 20 && response.Data.Page < response.Data.TotalPages)
        {
            request.AddParameter("page", response.Data.Page + 1);
            response = client.Execute<SearchResult>(request);

            filteredMovies.AddRange(response.Data.Results);
        }

        // Take the first 20 movies or all available movies if there are less than 20
        filteredMovies = filteredMovies.Take(20).ToList();

        // Update the poster path for each movie
        foreach (var movie in filteredMovies)
        {
            movie.backdrop_path = "https://image.tmdb.org/t/p/w500" + movie.backdrop_path;
        }

        return filteredMovies;
    }

    // Method to search movies by name
}

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string backdrop_path { get; set; }
    public List<int> genre_ids { get; set; }
}

public class SearchResult
{
    public List<Movie> Results { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
}
