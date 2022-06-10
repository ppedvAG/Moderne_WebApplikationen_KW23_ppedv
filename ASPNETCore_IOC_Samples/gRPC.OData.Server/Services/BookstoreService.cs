using Bookstores;
using Google.Protobuf.WellKnownTypes;
using gRPC.OData.Server.Models;
using Grpc.Core;

namespace gRPC.OData.Server.Services
{
    public class BookstoreService : Bookstroe.BookstroeBase
    {
        private readonly ILogger _logger;
        private readonly IShelfBookRepository _shelfBookRepository;

        public BookstoreService(ILoggerFactory loggerFactory, IShelfBookRepository shelfBookRepository)
        {
            _logger = loggerFactory.CreateLogger<BookstoreService>();
            _shelfBookRepository = shelfBookRepository;
        }


        //Regal Services
        public override Task<ListShelvesResponse> ListShelves(Empty request, ServerCallContext context)
        {
            IEnumerable<Shelf> shelves = _shelfBookRepository.GetShelves();
            ListShelvesResponse response = new ListShelvesResponse();

            foreach (var shelf in shelves)
            {
                response.Shelves.Add(shelf);
            }

            return Task.FromResult(response);
        }

        public override Task<Shelf> CreateShelf(CreateShelfRequest request, ServerCallContext context)
        {
            Shelf shelf = _shelfBookRepository.CreateShelf(request.Shelf);
            return Task.FromResult(shelf);
        }

        public override Task<Shelf> GetShel(GetShelfRequest request, ServerCallContext context)
        {
            Shelf shelf = _shelfBookRepository.GetShelf(request.Shelf);

            return Task.FromResult(shelf);
        }

        //Bücher Services

        public override Task<ListBooksResponse> ListBooks(ListBookRequest request, ServerCallContext context)
        {
            //request.Shelf -> ShelfId
            IEnumerable<Book> books = _shelfBookRepository.GetBooks(request.Shelf);

            ListBooksResponse response = new ListBooksResponse();
            foreach (Book book in books)
            {
                response.Books.Add(book);
            };

            return Task.FromResult(response);
        }

        public override Task<Book> CreateBook(CreateBookRequest request, ServerCallContext context)
        {
            Book book = _shelfBookRepository.CreateBook(request.Shelf, request.Book);

            return Task.FromResult(book);
        }

        public override Task<Book> GetBook(GetBookRequest request, ServerCallContext context)
        {
            Book book = _shelfBookRepository.GetBook(request.Shelf, request.Book);

            return Task.FromResult(book);
        }
    }
}
