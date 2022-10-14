namespace MediaFilesBox.Application.FileItems.Commands.CreateFileItem
{
    #region using

    using FluentValidation;
    using MediaFilesBox.Application.FileItems.Commands.CreateMediaFile;

    #endregion

    public class CreateFileItemCommandValidator : AbstractValidator<CreateFileItemCommand>
    {
        public CreateFileItemCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(100)
                .NotEmpty();
        }
    }
}
