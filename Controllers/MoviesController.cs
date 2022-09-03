using System.Collections.Generic;
using System.Linq;
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

    public MoviesController(ILogger<MoviesController> logger, IMovieRespository repo)
    {
        _logger = logger;
        _movieRepository = repo;
    }

// Add movie to list        POST /movies


// Rate Movies              PUT /movies/{id}
// Remove Movie             DELETE /movies {id}

// See a list of all movies GET /movies
    [HttpGet]
    public IEnumerable<Movie> GetMovies(){
        return _movieRepository;
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
