using Application.Features.Cities.Command.Add;
using Application.Features.Cities.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    public class CitiesController : ApiControllerBase
    {
        [HttpPost]
        
        public async Task<IActionResult> AddAsync(CityAddCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(CityGetAllQuery query)
        {
            //dışarıdan aldığı objeyi kullanır![HttpPost]
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await Mediator.Send(new CityGetAllQuery(id,null)));
        }
    }
}