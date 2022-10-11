namespace MediaFilesBox.Application.FileItems.Commands.DeleteMediaFile
{
    #region using

    using MediatR;

    #endregion

    public class DeleteFileItemCommand : IRequest
    {
        public int Id { get; set; }
    }
}
