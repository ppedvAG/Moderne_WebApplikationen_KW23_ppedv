using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieAPIService.Data;
using MovieAPIService.Services;
//ASP.NET Core 2.1 -> IWebHostBuilder -> builder.WebHost
//ASP.NET Core 3.1 / 5.0 -> IHostBuilder -> builder.Host

//ASP.NET Core 6.0 -> WebApplicationBuilder
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSingleton<IMovieService, MyMovieService>();
builder.Services.AddDbContext<MovieDbContext>(options =>
{
    options.UseInMemoryDatabase("MovieDb");
    options.UseLazyLoadingProxies();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//services.AddControllers();


WebApplication app = builder.Build();


//geht nur in Kombination mit Interface und Klasse
IMovieService movieService = app.Services.GetService<IMovieService>();

//ACHTUNG -> Geht nicht bei einfachen Objekten!!!!!
//MovieDbContext movieDbContext = app.Services.GetService<MovieDbContext>();


//
using (IServiceScope scope = app.Services.CreateScope())
{
    MovieDbContext movieDbContext = scope.ServiceProvider.GetService<MovieDbContext>();
    DataSeeder.Seed(movieDbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
