using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;
using UpSchool.Persistance.EntityFramework.Contexts;

namespace UpSchool.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UpStorageDbContext _dbConext;
        public AccountsController(IMapper mapper, UpStorageDbContext dbConext)
        {
            _mapper = mapper;
            _dbConext = dbConext;
        }
        
        [HttpGet]
        public IActionResult GetAll(bool isAscending, string? searchKeyword)
        {
            IQueryable<Account> accountsQuery = _dbConext.Accounts.AsQueryable();
            if (!string.IsNullOrEmpty(searchKeyword))
                accountsQuery=accountsQuery.Where(x => 
                    x.Title.Contains(searchKeyword) || x.UserName.Contains(searchKeyword));

            accountsQuery = isAscending
                ? accountsQuery.OrderBy(x => x.Title)
                : accountsQuery.OrderByDescending(x => x.Title);

            var accounts = accountsQuery.ToList();
           
            var accountDtos = accounts.Select(account => AccountDto.MapFromAccount(account));

            return Ok(accountDtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            //var account = _accounts.FirstOrDefault(x => x.Id == id);
            var account = _dbConext.Accounts.FirstOrDefault(x => x.Id == id); 
            
            if (account is null)
            {
                return NotFound("The selected account was not found.");
            }

            return Ok(AccountDto.MapFromAccount(account));
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
            
            _dbConext.Accounts.Add(account);
            _dbConext.SaveChanges();
            
            return Ok(AccountDto.MapFromAccount(account));
        }
        
        [HttpPut]
        public IActionResult Edit(AccountEditDto accountEditDto)
        {
            //var accountIndex = _accounts.FindIndex(x => x.Id == accountEditDto.Id);
            var account = _dbConext.Accounts.FirstOrDefault(x => x.Id == accountEditDto.Id);
            if (account is null) return NotFound("The selected account was not found.");
            
            var updatedAccount = _mapper.Map<AccountEditDto,Account>(accountEditDto,account);

            _dbConext.Accounts.Update(updatedAccount);
            _dbConext.SaveChanges();
            
            return Ok(_mapper.Map<AccountDto>(updatedAccount));
        }
        
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var account = _dbConext.Accounts.FirstOrDefault(x => x.Id == id);
            if (account is null) return NotFound("The selected account was not found");
            _dbConext.Accounts.Remove(account);
            _dbConext.SaveChanges();
            return NoContent();
        }
    }
}