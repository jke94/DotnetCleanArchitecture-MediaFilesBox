namespace MediaFilesBox.Application.FileItems.Commands.CreateMediaFile
{
    #region using

    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Domain.Entities;
    using MediaFilesBox.Domain.Events;
    using MediatR;

    #endregion

    public class CreateFileItemCommandHandler : IRequestHandler<CreateFileItemCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateFileItemCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateFileItemCommand request, CancellationToken cancellationToken)
        {
            FileItem entity = new()
            {
                Name = request.Name,
                Path = request.Path,
            };

            entity.DomainEvents.Add(new FileItemCreatedEvent(entity));

            _applicationDbContext.FileItems.Add(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
