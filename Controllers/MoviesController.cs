using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMagic.Models;

namespace MovieMagic.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
    private static readonly Movie[] mockMovies = new[]
    {
       new Movie { MovieId =1, Name = "Cars", Rating = 4},
       new Movie { MovieId =2, Name = "Jurasic Park", Rating = 5},
       new Movie { MovieId =3, Name = "Back to the Future", Rating = 3},

    };
    private readonly ILogger<MoviesController> _logger;


    public MoviesController(ILogger<MoviesController> logger)
    {
        _logger = logger;
    }

// Add movie to list        POST /movies


// Rate Movies              PUT /movies/{id}
// Remove Movie             DELETE /movies {id}

// See a list of all movies GET /movies
    [HttpGet]
    public IEnumerable<Movie> GetMovies(){
        return mockMovies;
    }

    // Get individual Movie     GET /movies/{id}
     [HttpGet, Route("{movieId:int}")]
    public Movie GetMovieById(int movieId)
    {
        var movie = mockMovies.FirstOrDefault(m => m.MovieId == movieId);
      
        // if (movie == null){
        //     return NotFound();
        // }

        return movie;
    }


}
