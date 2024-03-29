using Application.Common.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class MathController : ApiControllerBase
{
    private readonly MathHelper _mathHelper;

    public MathController()
    {
        _mathHelper = new MathHelper();              
    }

    // GET
    [HttpGet]
    public IActionResult IsEven(int number)
    {
        var result = _mathHelper.IsEven(number);

        if (result)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }
}