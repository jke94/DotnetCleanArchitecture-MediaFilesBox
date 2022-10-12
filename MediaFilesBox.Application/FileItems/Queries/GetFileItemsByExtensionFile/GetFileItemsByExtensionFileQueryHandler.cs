namespace MediaFilesBox.Application.FileItems.Queries.GetFileItemsByExtensionFile
{
    #region using

    using AutoMapper;
    using MediatR;
    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    #endregion

    public class GetFileItemsByExtensionFileQueryHandler : IRequestHandler<GetFileItemsByExtensionFileQuery, List<FileItemDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetFileItemsByExtensionFileQueryHandler(
            IApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<List<FileItemDto>> Handle(GetFileItemsByExtensionFileQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Extension))
            {
                return _mapper.Map<List<FileItem>, List<FileItemDto>>(new List<FileItem>());
            }
            var queryResult = await _applicationDbContext.FileItems.Where(item => item.Name.Contains(request.Extension)).ToListAsync();


            return _mapper.Map<List<FileItem>, List<FileItemDto>>(queryResult!);
        }
    }
}
