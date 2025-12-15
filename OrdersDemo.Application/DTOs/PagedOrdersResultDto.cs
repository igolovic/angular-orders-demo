using OrdersDemo.Domain.Entities;

public class PagedOrdersResultDto
{
    public IEnumerable<Order> Orders { get; set; }
    public int TotalCount { get; set; }
}
