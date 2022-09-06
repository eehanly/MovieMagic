using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMagic.Models;
using MovieMagic.Repositories;

namespace MovieMagic.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : ControllerBase
{
  
    private readonly ILogger<MoviesController> _logger;
    private readonly IMovieRepository _movieRepository;

    public MoviesController(ILogger<MoviesController> logger, IMovieRepository repo)
    {
        _logger = logger;
        _movieRepository = repo;
    }

// Add movie to list        POST /movies
    [HttpPost]
    public Movie CreateMovie(Movie movie)
    {
        if (movie == null || !ModelState.IsValid){
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return null;
        }
        var newMovie = _movieRepository.CreateMovie(movie);
        return newMovie;
    }

// Rate Movies              PUT /movies/{id}
 [HttpPut,  Route("{movieId:int}")]
    public Movie UpdateMovie(Movie movie)
    {
        if (movie == null || !ModelState.IsValid){
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return null;
        }
        var newMovie = _movieRepository.UpdateMovie(movie);
        return newMovie;
    }
// Remove Movie             DELETE /movies {id}
[HttpDelete,  Route("{movieId:int}")]
public void DeleteMovie(int movieId){
    _movieRepository.DeleteMovie(movieId);
    Response.StatusCode = (int) HttpStatusCode.NoContent;
}

// See a list of all movies GET /movies
    [HttpGet]
    public IEnumerable<Movie> GetMovies(){
        return _movieRepository.GetAllMovies();
    }

    // Get individual Movie     GET /movies/{id}
     [HttpGet, Route("{movieId:int}")]
    public Movie GetMovieById(int movieId)
    {
        var movie =_movieRepository.GetMovieById(movieId);
      
        if (movie == null){
            Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
            return null;
        }

        return movie;
    }


}
