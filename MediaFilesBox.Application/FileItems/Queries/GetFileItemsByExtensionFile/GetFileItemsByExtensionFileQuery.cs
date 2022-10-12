namespace MediaFilesBox.Application.FileItems.Queries.GetFileItemsByExtensionFile
{
    #region using

    using MediaFilesBox.Application.Common.Models;
    using MediaFilesBox.Application.FileItems.Queries;
    using MediatR;

    #endregion

    public class GetFileItemsByExtensionFileQuery : IRequest<List<FileItemDto>>
    {
        public string? Extension { get; set; }
    }
}
