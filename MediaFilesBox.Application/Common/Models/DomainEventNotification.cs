namespace MediaFilesBox.Application.Common.Models
{
    #region using

    using MediatR;
    using Domain.Common;

    #endregion

    public class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : DomainEvent
    {
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }

        public TDomainEvent DomainEvent { get; }
    }
}
