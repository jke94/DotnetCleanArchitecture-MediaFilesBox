namespace MediaFilesBox.Application.FileItems.Commands.CreateMediaFile
{
    #region using

    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Domain.Entities;
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

            // TODO: Implement DomainEvents
            //entity.DomainEvents.Add(new SuperheroCreatedEvent(entity));

            _applicationDbContext.FileItems.Add(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
