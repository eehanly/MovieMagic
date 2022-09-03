using System.Collections.Generic;
using MovieMagic.Models;

namespace MovieMagic.Repositories
{
    public interface IMovieRespository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int movieId);
        Movie CreateMovie(Movie newMovie);
        Movie UpdateMovie(Movie newMovie);
        void DeleteMovie(int movieId);
    }
}