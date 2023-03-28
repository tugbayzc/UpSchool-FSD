using Domain.Common;

namespace Domain.Entities;

public class Address:EntityBase<Guid>
{
    public string Name { get; set; }
    public string UserId { get; set; }
    //User ı herhangi bir şeye bağlamak doğru değil!

}