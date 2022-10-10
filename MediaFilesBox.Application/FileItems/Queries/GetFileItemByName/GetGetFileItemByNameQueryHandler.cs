using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaFilesBox.Application.FileItems.Queries.GetFileItems
{
    #region using

    using AutoMapper;
    using MediatR;
    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    #endregion

    public class GetGetFileItemByNameQueryHandler : IRequestHandler<GetGetFileItemByNameQuery, FileItemDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetGetFileItemByNameQueryHandler(
            IApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<FileItemDto> Handle(GetGetFileItemByNameQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.FileItems.FirstOrDefaultAsync(item => item.Name.Equals(request.Name));

            return _mapper.Map<FileItem, FileItemDto>(entity!);
        }
    }
}
