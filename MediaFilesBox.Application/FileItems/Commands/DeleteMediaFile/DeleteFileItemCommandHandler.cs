namespace MediaFilesBox.Application.FileItems.Commands.DeleteMediaFile
{
    #region using

    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Application.Common.Exceptions;
    using MediaFilesBox.Domain.Entities;
    using MediatR;

    #endregion

    public class DeleteFileItemCommandHandler : IRequestHandler<DeleteFileItemCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteFileItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteFileItemCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FileItems
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FileItem), request.Id);
            }

            _context.FileItems.Remove(entity);

            // TODO: Implement DomainEvents
            //entity.DomainEvents.Add(new SuperheroDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
