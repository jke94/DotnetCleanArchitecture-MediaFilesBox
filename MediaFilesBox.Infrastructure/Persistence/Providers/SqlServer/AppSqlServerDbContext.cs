namespace MediaFilesBox.Infrastructure.Persistence.SqlServer
{
    #region using

    using Microsoft.EntityFrameworkCore;
    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Domain.Entities;
    using System.Reflection;
    using MediaFilesBox.Domain.Common;
    using System;

    #endregion

    public class AppSqlServerDbContext : DbContext, IApplicationDbContext
    {
        #region Fields

        private readonly IDateTime _dateTime;
        private readonly IDomainEventService _domainEventService;

        #endregion

        #region Properties

        public DbSet<FileItem> FileItems => Set<FileItem>();

        #endregion

        #region Constructor

        public AppSqlServerDbContext(
            DbContextOptions<AppSqlServerDbContext> options,
            IDateTime dateTime,
            IDomainEventService domainEventService) : base(options)
        {
            _dateTime = dateTime;
            _domainEventService = domainEventService;
        }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "UserId";
                        entry.Entity.Created = _dateTime.Now;
                        entry.Entity.RowVersion = Guid.NewGuid();
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = "UserId";
                        entry.Entity.LastModified = _dateTime.Now;
                        entry.Entity.RowVersion = Guid.NewGuid();
                        break;
                }
            }

            var events = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished)
                .ToArray();

            var result = 0;

            try
            {
                result = await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Update the values of the entity that failed to save from the store (https://docs.microsoft.com/es-es/ef/ef6/saving/concurrency)
                ex.Entries.Single().Reload();
            }

            await DispatchEvents(events);

            return result;
        }

        private async Task DispatchEvents(DomainEvent[] events)
        {
            foreach (var @event in events)
            {
                @event.IsPublished = true;
                await _domainEventService.Publish(@event);
            }
        }

        #endregion
    }
}
