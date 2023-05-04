// See https://aka.ms/new-console-template for more information

using FinalProjectCheatSheet;

var order= new Order()
{
    Id=Guid.NewGuid(),
    RequestedAmount = 50,
    ProductCrawlType = ProductCrawlType.All,
};

var orderEvent = new OrderEvent()
{
    Id = Guid.NewGuid(),
    OrderId = order.Id,
    CreatedOn = DateTimeOffset.Now,
    Status = OrderStatus.BotStarted
};

order.OrderEvents = new List<OrderEvent>();

order.OrderEvents.Add(orderEvent);

//await dbContext.Orders.AddAsync(order,cancellationToken);
//await dbContext.OrderEvents.AddAsync(order,cancellationToken);

