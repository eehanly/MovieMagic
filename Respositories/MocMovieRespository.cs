using MovieMagic.Models;

namespace MovieMagic.Repositories
{
    public class MockMovieRepository : IMovieRepository
    {
          private List<Movie> mockMovies;
          public MockMovieRepository()
          {
            mockMovies = new List<Movie>
            {
            new Movie { MovieId =1, Name = "Up", Rating = 4},
            new Movie { MovieId =2, Name = "Jurasic Park", Rating = 5},
            new Movie { MovieId =3, Name = "Back to the Future", Rating = 3},

            };
          } 
           
            
        public Movie CreateMovie(Movie newMovie)
        {
           var maxId = mockMovies.Select(m => m.MovieId).DefaultIfEmpty().Max();
           newMovie.MovieId = maxId + 1;
           mockMovies.Add(newMovie);
           return newMovie;
        }

        public void DeleteMovie(int movieId)
        {
            var movie = mockMovies.FirstOrDefault(m => m.MovieId == movieId);
            if (movie != null){
                 mockMovies.Remove(movie);
            }
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return mockMovies;
        }

        public Movie GetMovieById(int movieId)
        {
           return mockMovies.FirstOrDefault(m => m.MovieId == movieId);
        }

        public Movie UpdateMovie(Movie newMovie)
        {
           var movie =  mockMovies.FirstOrDefault(m => m.MovieId == newMovie.MovieId);
           if (movie != null){
            movie.Name = newMovie.Name;
            movie.Rating = newMovie.Rating;
            }
            return movie;
        }
    }
}