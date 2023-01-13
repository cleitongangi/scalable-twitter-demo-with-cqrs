using MediatR;
using Microsoft.AspNetCore.Mvc;
using TwitterDemo.API.Controllers.Base;
using TwitterDemo.Domain.Commands.Posts.NewPost;

namespace TwitterDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : AppControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost("New")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> NewPost([FromBody] NewPostCommand input)
        {
            input.SetUserId(base.GetAuthenticatedUserId());
            var result = await _mediator.Send(input);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            // TODO: Update url with get method
            return Created("", result);            
        }

    }
}
