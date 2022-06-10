namespace MovieAPIService.DTO.Mapper
{
    public static class MovieCommentsToMovieCommentsDTO
    {
        public static MovieCommentDTO ToDTO (this MovieCustomerComments comment)
        {
            MovieCommentDTO movieCommentDTO = new MovieCommentDTO();
            movieCommentDTO.Id = comment.Id;
            movieCommentDTO.Comment = comment.Comment;
            movieCommentDTO.MovieId = comment.MovieId;

            return movieCommentDTO;
        }

        public static IList<MovieCommentDTO> ToDTOs(this IEnumerable<MovieCustomerComments> comments)
        {
            IList<MovieCommentDTO> commentCommentDTOList = new List<MovieCommentDTO>();

            foreach (MovieCustomerComments currentComment in comments)
                commentCommentDTOList.Add(ToDTO(currentComment));

            return commentCommentDTOList;
        }

        //public static IList<MovieCommentDTO> ToDTOs(this ICollection<MovieCustomerComments> comments)
        //{
        //    IList<MovieCommentDTO> commentCommentDTOList = new List<MovieCommentDTO>();

        //    foreach (MovieCustomerComments currentComment in comments)
        //        commentCommentDTOList.Add(ToDTO(currentComment));

        //    return commentCommentDTOList;
        //}

    }
}
