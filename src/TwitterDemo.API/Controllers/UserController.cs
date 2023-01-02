using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TwitterDemo.Domain.Queries.User.GetUser;

namespace TwitterDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("{UserId:long}")]
        [ProducesResponseType(typeof(GetUserQueryResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetUser([FromRoute] GetUserQueryRequest input)
        {
            var result = await _mediator.Send(input);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
