using CQRS_MediatR_MovieAPI.Data.Entities;
using MediatR;

namespace CQRS_MediatR_MovieAPI.Queries
{
    //Was ist ein Record, wenn es kompiliert wurde? -> public class GetMovieQuery : IEqualable 
    public record GetMoviesQuery () : IRequest<IEnumerable<Movie>>;

    //Beispiel-> Zu GetMoviesQuery2 gibt es keinen Handler (siehe Controller) -> GetMovies
    //System.InvalidOperationException: No service for type 'MediatR.IRequestHandler`2[CQRS_MediatR_MovieAPI.Queries.GetMoviesQuery2,System.Collections.Generic.IEnumerable`1[CQRS_MediatR_MovieAPI.Data.Entities.Movie]]' has been registered.
    public record GetMoviesQuery2() : IRequest<IEnumerable<Movie>>;





}
