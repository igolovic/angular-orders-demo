using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OrdersDemo.Application.Interfaces;
using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly string _connectionString;

        public OrderService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public PagedOrdersResultDto GetOrders(string filter, int offset, int pageSize, string sortColumn, ListSortDirection sortDirection)
        {
            var result = new PagedOrdersResultDto();
            var orders = new List<Order>();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("GetOrdersPaged", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Filter", (object)filter ?? DBNull.Value);
                command.Parameters.AddWithValue("@Offset", offset);
                command.Parameters.AddWithValue("@PageSize", pageSize);
                command.Parameters.AddWithValue("@SortColumn", sortColumn ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@SortDirection", sortDirection == ListSortDirection.Ascending ? "ASC" : "DESC");

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    // 1. Resultset: Orders
                    while (reader.Read())
                    {
                        orders.Add(new Order
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            ClientId = reader.GetInt32(reader.GetOrdinal("ClientId")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            ModifiedAt = reader.IsDBNull(reader.GetOrdinal("ModifiedAt")) ? null : reader.GetDateTime(reader.GetOrdinal("ModifiedAt"))
                        });
                    }

                    // 2. Resultset: OrderItems
                    var items = new List<OrderItem>();
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            items.Add(new OrderItem
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                                ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"))
                            });
                        }
                    }

                    // Map items to orders
                    var orderLookup = orders.ToDictionary(o => o.Id);
                    foreach (var item in items)
                    {
                        if (orderLookup.TryGetValue(item.OrderId, out var order))
                        {
                            order.Items.Add(item);
                        }
                    }

                    // 3. Resultset: TotalCount
                    if (reader.NextResult() && reader.Read())
                    {
                        result.TotalCount = reader.GetInt32(0);
                    }
                }
            }

            result.Orders = orders;
            return result;
        }
    }
}