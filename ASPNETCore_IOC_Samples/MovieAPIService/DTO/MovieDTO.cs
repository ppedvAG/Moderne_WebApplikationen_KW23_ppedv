namespace MovieAPIService.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double IMDB_Rating { get; set; }
        public GenreType Genre { get; set; }

        public IList<MovieCommentDTO> CommentsList { get; set; } = new List<MovieCommentDTO>();
    }
}
