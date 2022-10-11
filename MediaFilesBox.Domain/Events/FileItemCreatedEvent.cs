namespace MediaFilesBox.Domain.Events
{
    #region using

    using MediaFilesBox.Domain.Common;
    using MediaFilesBox.Domain.Entities;

    #endregion

    public class FileItemCreatedEvent : DomainEvent
    {
        public FileItemCreatedEvent(FileItem item)
        {
            Item = item;
        }

        public FileItem Item { get; }
    }
}
