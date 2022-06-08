


using Microsoft.Extensions.DependencyInjection;
using MovieService.Interfaces;
using MovieService;
using MovieService.Entities;

//ASP.NET Core ServiceCollection sammelt alle Dienste (Initialisierungen)
IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddScoped<IMovieService, MyMovieService>();

//Build - Befehl in ASP.NET Core -> ab hier werden keine weitere Dienste hinzugefügt 
IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


//Beide Methoden: GetRequiredService + GetService lesen aus IOC Container

//Wenn IMovieService nicht gefunden wird -> wird eine Exception entstehen 
//Wo kommt dieser Befehl -> Konstruktor-Injection / [FromServices] / @inject (Razor)
IMovieService movieService1 = serviceProvider.GetRequiredService<IMovieService>();

//HttpContext.Services.GetService 
IMovieService? movieService2 = serviceProvider.GetService<IMovieService>();

IList<Movie> movies = movieService1.GetAll();

foreach (Movie movie in movies)
{
    Console.WriteLine($"{movie.Title}");
}

