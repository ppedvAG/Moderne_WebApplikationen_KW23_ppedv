using CQRS_MediatR_MovieAPI.Data.Entities;
using CQRS_MediatR_MovieAPI.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CQRS_MediatR_MovieAPI.Behaviors
{
    //https://github.com/jbogard/MediatR/issues/688

    // https://github.com/jbogard/MediatR/wiki/Migration-Guide-9.x-to-10.0
    // 9.0 -> wäre folgender Code: public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>




    /*
     * 
     * Aufbau von MediatR-Behaviors (Verhaltensweisen) 

        Wenn wir Anwendungen erstellen, haben wir oft viele bereichsübergreifende Bedenken. Dazu gehören    ->      Autorisierung, Validierung und Protokollierung.

        Anstatt diese Logik in unseren Handlern zu wiederholen, können wir Behaviors verwenden. 
    
        Behaviors sind denen von ASP.NET Core-Middleware sehr ähnlich, da sie eine Anforderung akzeptieren, eine Aktion ausführen und dann (optional) die Anforderung weiterleiten. 

        Sehen wir uns die Implementierung eines MediatR-Verhaltens an, das für uns protokolliert. 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
		private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        private readonly IMediator _mediator;


		public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        



        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");

            var response = await next();

            _logger.LogInformation($"Handled {typeof(TResponse).Name}");


            await _mediator.Publish(new MovieAddedNotification(new Movie() { Id = 1, Title = "Test", Description = "wäre witzig", Genre = Data.Entities.GenreType.ScienceFiction, Price = 12m}));
            return response;
        }
    }


    public class CompressBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {


        public CompressBehavior() { }
           



        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
          
            //komprimiere

            //Ist wie eine Middleware 
            var response = await next();

            

            return response;
        }
    }
}
