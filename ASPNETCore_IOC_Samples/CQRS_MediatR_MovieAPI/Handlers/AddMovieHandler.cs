using CQRS_MediatR_MovieAPI.Commands;
using CQRS_MediatR_MovieAPI.Data;
using CQRS_MediatR_MovieAPI.Data.Entities;
using MediatR;

namespace CQRS_MediatR_MovieAPI.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, Movie>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddMovieHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;


        public async Task<Movie> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddMovie(request.Movie);

            return request.Movie;
        }
    }
}
