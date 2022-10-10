namespace MediaFilesBox.Application.FileItems.Queries.GetFileItemWithPagination
{
    #region using

    using MediaFilesBox.Application.Common.Models;
    using MediaFilesBox.Application.FileItems.Queries;
    using MediatR;

    #endregion

    public class GetFileItemsWithPaginationQuery : IRequest<PaginatedList<FileItemDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
