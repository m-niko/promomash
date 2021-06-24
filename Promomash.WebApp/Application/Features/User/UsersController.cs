using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Promomash.WebApp.Application.Features.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("", Name = "Create")]
        public async Task<IActionResult> Create([FromBody] Create.Command command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}