namespace MediaFilesBox.Application.Common.Interfaces
{
    #region using

    using MediaFilesBox.Domain.Common;

    #endregion

    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
