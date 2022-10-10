namespace MediaFilesBox.WebApi.Controllers
{
    #region using

    using MediaFilesBox.Application.Common.Models;
    using MediaFilesBox.Application.FileItems.Queries.GetFileItem;
    using MediaFilesBox.Application.FileItems.Queries.GetFileItemWithPagination;
    using Microsoft.AspNetCore.Mvc;
    using MediaFilesBox.Application.FileItems.Queries;

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

        #endregion
    }
}
