using Grpc.Net.Client;
using Bookstores;
using Google.Protobuf.WellKnownTypes;

namespace gRPC.OData.Client
{
    internal class GrpcBookstoreClient : IBookStoreClient
    {
        private readonly string _baseUri;

        public GrpcBookstoreClient(string baseUri)
        {
            _baseUri = baseUri;
        }

        public async Task ListShelves()
        {
            Console.WriteLine("\ngRPC: List shelves:");
            using var channel = GrpcChannel.ForAddress(_baseUri);
            var client = new Bookstroe.BookstroeClient(channel);

            var listShelvesResponse = await client.ListShelvesAsync(new Empty());

            foreach (var shelf in listShelvesResponse.Shelves)
            {
                Console.WriteLine($"\t-{shelf.Id}): {shelf.Theme}");
            }
            Console.WriteLine();
        }

        public async Task<Shelf> CreateShelf(Shelf shelf)
        {
            Console.WriteLine("gRPC: Create shelf:");

            using var channel = GrpcChannel.ForAddress(_baseUri);
            var client = new Bookstroe.BookstroeClient(channel);

            shelf = await client.CreateShelfAsync(new CreateShelfRequest { Shelf = shelf });
            Console.WriteLine($"\t-{shelf.Id}): {shelf.Theme}\n");

            return shelf;
        }

        public async Task GetShelf(long shelfId)
        {
            Console.WriteLine($"gRPC: Get shelf at '{shelfId}':");

            using var channel = GrpcChannel.ForAddress(_baseUri);
            var client = new Bookstroe.BookstroeClient(channel);

            Shelf shelf = await client.GetShelAsync(new GetShelfRequest { Shelf = shelfId });
            Console.WriteLine($"\t-{shelf.Id}): {shelf.Theme}");
        }

       

        public async Task ListBooks(long shelfId)
        {
            Console.WriteLine($"\ngRPC: List books at shelf '{shelfId}':");
            using var channel = GrpcChannel.ForAddress(_baseUri);
            var client = new Bookstroe.BookstroeClient(channel);

            var listBooksResponse = await client.ListBooksAsync(new ListBookRequest { Shelf = shelfId });

            foreach (var book in listBooksResponse.Books)
            {
                Console.WriteLine($"\t-{book.Id}): <<{book.Title}>> by {book.Author}");
            }
        }

        public async Task<Book> CreateBook(long shelfId, Book book)
        {
            Console.WriteLine($"gRPC: Create book for shelf '{shelfId}':");

            using var channel = GrpcChannel.ForAddress(_baseUri);
            var client = new Bookstroe.BookstroeClient(channel);

            book = await client.CreateBookAsync(new CreateBookRequest { Shelf = shelfId, Book = book });
            Console.WriteLine($"\t-{book.Id}): <<{book.Title}>> by {book.Author}\n");

            return book;
        }

        public async Task GetBook(long shelfId, long bookId)
        {
            Console.WriteLine($"gRPC: Get book '{bookId}' from shelf '{shelfId}':");

            using var channel = GrpcChannel.ForAddress(_baseUri);
            var client = new Bookstroe.BookstroeClient(channel);

            Book book = await client.GetBookAsync(new GetBookRequest { Shelf = shelfId, Book = bookId });
            Console.WriteLine($"\t-{book.Id}): <<{book.Title}>> by {book.Author}\n");
        }

       
    }
}
