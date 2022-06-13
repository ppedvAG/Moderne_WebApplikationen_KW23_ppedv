using CQRS_MediatR_MovieAPI.Data.Entities;
using MediatR;

namespace CQRS_MediatR_MovieAPI.Notifications
{
    public record MovieAddedNotification(Movie Movie) : INotification;
}
