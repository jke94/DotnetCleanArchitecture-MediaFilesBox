namespace MediaFilesBox.Application.FileItems.Commands.UpdateMediaFile
{
    #region using

    using MediatR;

    #endregion
    public class UpdateFileItemCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
    }
}
