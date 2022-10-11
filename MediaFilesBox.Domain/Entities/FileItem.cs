
namespace MediaFilesBox.Domain.Entities
{
    #region

    using MediaFilesBox.Domain.Common;

    #endregion

    public class FileItem : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
