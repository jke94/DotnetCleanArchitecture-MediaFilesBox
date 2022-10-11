namespace MediaFilesBox.Application.FileItems.Commands.UpdateMediaFile
{
    #region using

    using MediaFilesBox.Application.Common.Exceptions;
    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Domain.Entities;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    public class UpdateFileItemCommandHandler : IRequestHandler<UpdateFileItemCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateFileItemCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Unit> Handle(UpdateFileItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.FileItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FileItem), request.Id);
            }

            entity.Name = request.Name;
            entity.Path = request.Path;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
