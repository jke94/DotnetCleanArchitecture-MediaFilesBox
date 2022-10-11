namespace MediaFilesBox.Infrastructure.Persistence.Configurations
{
    #region using

    using Microsoft.EntityFrameworkCore;
    using MediaFilesBox.Domain.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    #endregion

    public class FileItemConfiguration : IEntityTypeConfiguration<FileItem>
    {
        public void Configure(EntityTypeBuilder<FileItem> builder)
        {
            builder.ToTable("FileItem");

            builder.Ignore(e => e.DomainEvents);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
