namespace MediaFilesBox.WebApi.Controllers
{
    #region

    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    #endregion

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
