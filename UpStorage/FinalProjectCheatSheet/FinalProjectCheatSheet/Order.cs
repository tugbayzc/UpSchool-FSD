namespace FinalProjectCheatSheet;

public class Order
{
    public Guid Id { get; set; }
    public int RequestedAmount { get; set; }
    public int TotalFoundAmount { get; set; }
    public ProductCrawlType ProductCrawlType { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<OrderEvent> OrderEvents { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
}