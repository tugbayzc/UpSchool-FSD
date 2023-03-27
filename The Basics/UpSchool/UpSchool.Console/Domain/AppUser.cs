namespace UpSchool.Console.Domain;

public class AppUser
{
    public string Id { get; set; }
    public string CreatedByUserId { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}