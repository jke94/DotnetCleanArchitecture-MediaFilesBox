﻿namespace MediaFilesBox.Infrastructure.Persistence.Providers.SqlServer
{
    #region

    using System.Collections.Generic;
    using Domain.Entities;
    using MediaFilesBox.Infrastructure.Persistence.SqlServer;

    #endregion

    public class AppSqlServerDbContextSeed
    {
        private static readonly string [] _fileExtension = { "png", "jpg", "tif", "pdf", "bmp", "gif", "raw", "svg" };

        public static async Task SeedSampleDataAsync(AppSqlServerDbContext context)
        {
            Random random = new Random();

            IList<FileItem> fileItemList = new List<FileItem>();

            Enumerable.Range(1, 80).ToList().ForEach(i =>
            {
                var fileName = $"{Guid.NewGuid()}.{_fileExtension[random.Next(0, _fileExtension.Length)]}";

                fileItemList.Add(
                    new FileItem()
                    {
                        // Id = It´s autogenerated.
                        Name = fileName,
                        Path = $"./items/{fileName}"
                    });
            });

            context.FileItems.AddRange(fileItemList);

            await context.SaveChangesAsync();
        }
    }
}
