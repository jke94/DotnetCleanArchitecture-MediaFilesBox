namespace MediaFilesBox.Application.FileItems.Queries.GetFileItem
{
    #region
    
    using MediaFilesBox.Application.Common.Mappings;
    using MediaFilesBox.Domain.Entities;

    #endregion

    public class FileItemDto : IMapFrom<FileItem>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
    }
}
