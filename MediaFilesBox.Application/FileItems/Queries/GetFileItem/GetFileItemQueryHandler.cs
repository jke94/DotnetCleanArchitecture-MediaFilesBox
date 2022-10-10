namespace MediaFilesBox.Application.FileItems.Queries.GetFileItem
{
    #region using

    using AutoMapper;
    using MediatR;
    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Domain.Entities;

    #endregion

    public class GetFileItemQueryHandler : IRequestHandler<GetFileItemQuery, FileItemDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetFileItemQueryHandler(
            IApplicationDbContext applicationDbContext, 
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<FileItemDto> Handle(GetFileItemQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.FileItems.FindAsync(request.Id);

            return _mapper.Map<FileItem, FileItemDto>(entity!);
        }
    }
}
