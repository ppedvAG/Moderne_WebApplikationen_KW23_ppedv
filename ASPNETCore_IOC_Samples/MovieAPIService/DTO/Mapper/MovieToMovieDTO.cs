namespace MovieAPIService.DTO.Mapper
{
    public static class MovieToMovieDTO
    {
        #region Ohne Relation
        public static MovieDTO MovieToDTO (this Movie movie)
        {
            MovieDTO dto = new();
            dto.Id = movie.Id;
            dto.Title = movie.Title;
            dto.Description = movie.Description;
            dto.Price = movie.Price;
            dto.Genre = movie.Genre;
            dto.IMDB_Rating = movie.IMDB_Rating;

            return dto;
        }


        public static IList<MovieDTO> MoviesToDTOs(IEnumerable<Movie> movies)
        {
            IList<MovieDTO> movieDTOs = new List<MovieDTO>();

            foreach (Movie currentMovie in movies)
                movieDTOs.Add(currentMovie.MovieToDTO());

            return movieDTOs;
        }
        #endregion

        #region Mit REalation
        public static MovieDTO MovieToDTOWithRelation(this Movie movie)
        {
            MovieDTO dto = MovieToDTO(movie);

            dto.CommentsList = movie.MovieComments.ToDTOs();

            return dto;
        }

        public static IList<MovieDTO> MoviesToDTOsWithRelation(this IEnumerable<Movie> movies)
        {
            IList<MovieDTO> movieDTOs = new List<MovieDTO>();


            foreach (Movie currentMovie in movies)
            {
                movieDTOs.Add(MovieToDTOWithRelation(currentMovie));
            }


            return movieDTOs;
        }

        #endregion


    }
}
