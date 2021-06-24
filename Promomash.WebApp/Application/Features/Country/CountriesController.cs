using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Promomash.WebApp.Application.Features.Country
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAll.Query()));
        }

        [HttpGet("{id}/provinces")]
        public async Task<IActionResult> GetProvincesByCountryId(int id)
        {
            return Ok(await _mediator.Send(new GetProvincesByCountryId.Query { CountryId = id }));
        }
    }
}