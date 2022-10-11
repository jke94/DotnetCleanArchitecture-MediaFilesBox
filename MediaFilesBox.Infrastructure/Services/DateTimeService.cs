namespace MediaFilesBox.Infrastructure.Services
{
    #region using

    using MediaFilesBox.Application.Common.Interfaces;

    #endregion

    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
