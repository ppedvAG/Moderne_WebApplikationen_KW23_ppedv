using CQRS_MediatR_MovieAPI.Data.Entities;
using MediatR;

namespace CQRS_MediatR_MovieAPI.Commands
{
    public record AddMovieCommand(Movie Movie) : IRequest<Movie>;
   
}
