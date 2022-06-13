using CQRS_MediatR_MovieAPI.Data;
using CQRS_MediatR_MovieAPI.Data.Entities;
using CQRS_MediatR_MovieAPI.Queries;
using MediatR;

namespace CQRS_MediatR_MovieAPI.Handlers
{
    //Losekopplung zum Controller

    // Hándler Klassen können auf den IOC Container zugreifen -> Warum geht das? -> MediatR.Extensions.Microsoft.DependencyInjection - Package
    // Bedeutet: 
    // - Zugriff auf DBContext-Klassen (Ohne DataLayer-Pattern)
    // - Zugriff auf Repositories (mit DataLayer-Pattern)
    public class GetMoviesHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetMoviesHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
            => await _fakeDataStore.GetAllMovies();
    }
}
