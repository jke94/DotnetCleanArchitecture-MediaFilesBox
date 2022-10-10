namespace MediaFilesBox.Application.FileItems.Queries.GetFileItem
{
    #region using

    using MediatR;

    #endregion

    public class GetFileItemQuery : IRequest<FileItemDto>
    {
        public int Id { get; set; }
    }
}
