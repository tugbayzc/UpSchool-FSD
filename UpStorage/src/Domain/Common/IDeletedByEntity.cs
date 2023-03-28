namespace Domain.Common;

public interface IDeletedByEntity
{
    DateTimeOffset? DeletedOn { get; set; }
    public string? DeletedByUserId { get; set; }
    
    bool IsDeleted { get; set; }
    
}