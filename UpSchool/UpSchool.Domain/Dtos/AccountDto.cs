using UpSchool.Domain.Entities;

namespace UpSchool.Domain.Dtos;

public class AccountDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Url { get; set; }
    public bool IsFavourite { get; set; }
    public bool ShowPassword { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    

    public AccountDto()
    {
        ShowPassword = false;
    }

    public static AccountDto MapFromAccount(Account account)
    {
        return new AccountDto()
        {
            Id = account.Id,
            UserName = account.UserName,
            Password = account.Password,
            Title = account.Title,
            ShowPassword = false,
            CreatedOn = DateTimeOffset.Now,
            Url = account.Url,
            IsFavourite = account.IsFavourite
        }; 
    }
}