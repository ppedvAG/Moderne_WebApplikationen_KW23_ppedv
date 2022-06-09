using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieAPIService.Services
{
    public interface IMovieService
    {
        IList<Movie> GetAll();
        void Insert(Movie movie);
    }
}
