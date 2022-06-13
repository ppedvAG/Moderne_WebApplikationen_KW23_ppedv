using CQRS_MediatR_MovieAPI.Commands;
using CQRS_MediatR_MovieAPI.Data.Entities;
using CQRS_MediatR_MovieAPI.Notifications;
using CQRS_MediatR_MovieAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CQRS_MediatR_MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        //Zugrif auf IOC und holen uns den Mediator dazu
        public MovieController(IMediator mediator)
            => _mediator = mediator;


        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            //Mediator.Send ruft einen Handler.
            //Welcher Handler, wird jetzt aufgerufen? 

            //  GetMoviesHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>> -> Methode Handle wird aufgerufen 
            IEnumerable<Movie> movies = await _mediator.Send(new GetMoviesQuery());



            //Was passiert wenn man den Handler vergessen hat -> Error Message:
            // System.InvalidOperationException: No service for type 'MediatR.IRequestHandler`2[CQRS_MediatR_MovieAPI.Queries.GetMoviesQuery2,System.Collections.Generic.IEnumerable`1[CQRS_MediatR_MovieAPI.Data.Entities.Movie]]' has been registered.
            // Referenz: public record GetMoviesQuery2() : IRequest<IEnumerable<Movie>>;
            //IEnumerable<Movie> movies = await _mediator.Send(new GetMoviesQuery2()); 

            return Ok(movies);
        }

        
        [HttpGet("{id:int}", Name = "GetMovieById")]
        public async Task<ActionResult> GetMovieById(int id)
        {
            Movie movie = await _mediator.Send(new GetMovieByIdQuery(id));

            return Ok(movie);
        }



        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] Movie movie)
        {
            Movie movieWithId = await _mediator.Send(new AddMovieCommand(movie));

            //Wollen wir einen weiteren Workflow mit dranhängen
            await _mediator.Publish(new MovieAddedNotification(movieWithId));
            

            return CreatedAtRoute("GetMovieById", new { id = movieWithId.Id }, movieWithId);
        }

    }
}
