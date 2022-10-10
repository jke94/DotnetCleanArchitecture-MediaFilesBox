namespace MediaFilesBox.Application.FileItems.Queries.GetFileItems
{
    #region using

    using MediatR;

    #endregion

    public class GetGetFileItemByNameQuery : IRequest<FileItemDto>
    {
        public string? Name { get; set; }
    }
}
