using MovieService.Entities;
using MovieService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService
{
    public class MyMovieService : IMovieService
    {
        private IList<Movie> movieList;
        public MyMovieService()
        {
            movieList = new List<Movie>();

            movieList.Add(new Movie() { Id = 1, Title = "Jurassic World", Description = "Dinosauer", Price = 9.99m, Genre = GenreType.Action});
            movieList.Add(new Movie() { Id = 2, Title = "Star Wars", Description = "Imperium ist böse", Price = 19.99m, Genre = GenreType.ScienceFiction });
            movieList.Add(new Movie() { Id = 3, Title = "Top Gun Maverick", Description = "Ist besser als Teil 1", Price = 15.99m, Genre = GenreType.Action });
        }
        public IList<Movie> GetAll()
        {
            return movieList;
        }

        public void Insert(Movie movie)
        {
            movieList.Add(movie);
        }
    }
}
