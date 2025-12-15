using System.ComponentModel;
using OrdersDemo.Application.Interfaces;

namespace OrdersDemo.Application.UseCases
{
    public class GetPagedOrdersUseCase
    {
        private readonly IOrderService orderService;

        public GetPagedOrdersUseCase(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public PagedOrdersResultDto Execute(
            string filter,
            int offset,
            int pageSize,
            string sortColumn,
            ListSortDirection sortDirection)
        {
            return orderService.GetOrders(filter, offset, pageSize, sortColumn, sortDirection);
        }
    }
}