namespace MediaFilesBox.WebApi.Controllers
{
    #region using

    using Microsoft.AspNetCore.Mvc;
    using MediaFilesBox.Application.Common.Models;
    using MediaFilesBox.Application.FileItems.Queries;
    using MediaFilesBox.Application.FileItems.Queries.GetFileItem;
    using MediaFilesBox.Application.FileItems.Queries.GetFileItemWithPagination;
    using MediaFilesBox.Application.FileItems.Queries.GetFileItems;
    using MediaFilesBox.Application.FileItems.Commands.CreateMediaFile;
    using MediaFilesBox.Application.FileItems.Commands.DeleteMediaFile;

    #endregion

    public class FileItemController : ApiControllerBase
    {
        #region Fields

        private readonly ILogger<FileItemController> _logger;

        #endregion

        #region Constructor

        public FileItemController(ILogger<FileItemController> logger)
        {
            _logger = logger;
        }

        #endregion

        #region HTTP GET: Methods

        [HttpGet]
        public async Task<ActionResult<PaginatedList<FileItemDto>>> GetFileItemWithPagination(
                [FromQuery] GetFileItemsWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FileItemDto>> GetFileItem(int id)
        {
            return await Mediator.Send(new GetFileItemQuery { Id = id });
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<FileItemDto>> GetFileItemByName(string name)
        {
            return await Mediator.Send(new GetGetFileItemByNameQuery { Name = name });
        }

        #endregion

        #region HTTP POST: Methods

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateFileItemCommand command)
        {
            return await Mediator.Send(command);
        }

        #endregion

        #region HTTP DELETE: Methods

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteFileItemCommand { Id = id });

            return NoContent();
        }

        #endregion
    }
}
