namespace MediaFilesBox.Infrastructure.Persistence.Providers.InMemory
{
    #region

    using System.Collections.Generic;
    using Domain.Entities;
    using MediaFilesBox.Infrastructure.Persistence.SqlServer;

    #endregion

    public class AppInMemoryDbContextSeed
    {
        public static async Task SeedSampleDataAsync(AppInMemoryDbContext context)
        {
            IList<FileItem> fileItemList = new List<FileItem>();

            Enumerable.Range(1, 80).ToList().ForEach(i =>
            {
                var itemGuid = Guid.NewGuid();
                fileItemList.Add(new FileItem { Id = i, Name = itemGuid.ToString(), Path = $"./items/{itemGuid}.png" });
            });

            context.FileItems.AddRange(fileItemList);

            await context.SaveChangesAsync();
        }
    }
}
