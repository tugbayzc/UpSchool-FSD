namespace UpSchool.Domain.Dtos;

public class PasswordAddRequest
{
    public string Password { get; set; }

    public PasswordAddRequest(string password)
    {
        Password = password;
    }

    public PasswordAddRequest()
    {
        
    }
}