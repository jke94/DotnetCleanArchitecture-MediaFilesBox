namespace MediaFilesBox.Infrastructure.Persistence
{
    #region using

    using Microsoft.EntityFrameworkCore;
    using MediaFilesBox.Application.Common.Interfaces;
    using MediaFilesBox.Domain.Entities;
    using System.Reflection;

    #endregion

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<FileItem> FileItems => Set<FileItem>();


        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
