namespace MediaFilesBox.Application.Common.Interfaces
{
    #region using

    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    #endregion

    public interface IApplicationDbContext
    {
        public DbSet<FileItem> FileItems { get; }
    }
}
