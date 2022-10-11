namespace MediaFilesBox.Application.FileItems.Commands.CreateMediaFile
{
    #region using

    using MediatR;

    #endregion

    public class CreateFileItemCommand : IRequest<int>
    {
        public string? Name { get; set; }
        public string? Path { get; set; }
    }
}
