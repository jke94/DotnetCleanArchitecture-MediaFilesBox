using MediaFilesBox.Application.FileItems.Queries.GetFileItem;
using Microsoft.AspNetCore.Mvc;

namespace MediaFilesBox.WebApi.Controllers
{
    public class FileItemController : ApiControllerBase
    {
        private readonly ILogger<FileItemController> _logger;

        public FileItemController(ILogger<FileItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FileItemDto>> GetSuperhero(int id)
        {
            return await Mediator.Send(new GetFileItemQuery { Id = id });
        }
    }
}
