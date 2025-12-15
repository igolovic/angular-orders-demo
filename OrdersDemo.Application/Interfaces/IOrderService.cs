using System.ComponentModel;

namespace OrdersDemo.Application.Interfaces
{
    public interface IOrderService
    {
        PagedOrdersResultDto GetOrders(string filter, int offset, int pageSize, string sortColumn, ListSortDirection sortDirection);
    }
}
