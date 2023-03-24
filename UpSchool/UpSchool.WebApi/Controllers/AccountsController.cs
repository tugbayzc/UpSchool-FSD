using Microsoft.AspNetCore.Mvc;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Utilities;

namespace UpSchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private static List<Account> _accounts = new() {
            new Account()
            {
                Id = Guid.NewGuid(),
                UserName = "mrpicle",
                Password = StringHelper.Base64Encode("123picle123"),
                IsFavourite = false,
                CreatedOn = DateTimeOffset.Now,
                Title = "UpSchool",
                Url = "www.upschool.com"
            },
        
            new Account()
            {
            Id = Guid.NewGuid(),
            UserName = "fullspeed@gmail.com",
            Password = StringHelper.Base64Encode("123fullspeed123"),
            IsFavourite = true,
            CreatedOn = DateTimeOffset.Now,
            Title = "Gmail",
            Url = "https://www.google.com/intl/tr/gmail./about/"
            },
            new Account()
            { 
            Id = Guid.NewGuid(),
            UserName = "movieguy",
            Password = StringHelper.Base64Encode("123movieguy123"),
            IsFavourite = true,
            CreatedOn = DateTimeOffset.Now,
            Title = "Sinemalar",
            Url = "www.sinemalar.com"
            }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            var accountDtos = _accounts.Select(account => AccountDto.MapFromAccount(account));
            
            return Ok(accountDtos);
        }

        [HttpPost]
        public IActionResult Add(AccountAddDto accountAddDto)
        {
            var account = new Account()
            {
                Id = Guid.NewGuid(),
                Title = accountAddDto.Title,
                UserName = accountAddDto.UserName,
                Password = accountAddDto.Password,
                IsFavourite = accountAddDto.IsFavourite,
                CreatedOn = DateTimeOffset.Now,
                Url = accountAddDto.Url
            };
            
            _accounts.Add(account);
            
            return Ok(AccountDto.MapFromAccount(account));
        }
    }
    
    
}