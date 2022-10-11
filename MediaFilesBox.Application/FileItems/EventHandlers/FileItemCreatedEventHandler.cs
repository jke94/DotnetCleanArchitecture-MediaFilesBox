namespace MediaFilesBox.Application.FileItems.EventHandlers
{
    #region using

    using MediaFilesBox.Application.Common.Models;
    using MediaFilesBox.Domain.Events;
    using MediatR;
    using Microsoft.Extensions.Logging;

    #endregion

    public class FileItemCreatedEventHandler : INotificationHandler<DomainEventNotification<FileItemCreatedEvent>>
    {
        private readonly ILogger<FileItemCreatedEventHandler> _logger;

        public FileItemCreatedEventHandler(ILogger<FileItemCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<FileItemCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
