namespace MediaFilesBox.Application.FileItems.Queries.GetFileItemWithPagination
{
    #region using

    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Application.Common.Models;
    using MediaFilesBox.Application.Common.Mappings;
    using AutoMapper.QueryableExtensions;
    using MediaFilesBox.Application.FileItems.Queries;

    #endregion

    public class GetFileItemsWithPaginationQueryHandler : 
        IRequestHandler<GetFileItemsWithPaginationQuery, PaginatedList<FileItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFileItemsWithPaginationQueryHandler(
            IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<FileItemDto>> Handle(GetFileItemsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.FileItems.AsNoTracking()
                .OrderBy(x => x.Id)
                .ProjectTo<FileItemDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
