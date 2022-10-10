namespace MediaFilesBox.Infrastructure.Persistence
{
    #region

    using System.Collections.Generic;
    using Domain.Entities;

    #endregion

    public class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
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
