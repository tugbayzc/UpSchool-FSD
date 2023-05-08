using Application.Features.Cities.Queries.GetAll;
using Application.Features.Countries.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(CountriesGetAllQuery query)
        {
            
            return Ok(await Mediator.Send(query));
        }
    }
}
