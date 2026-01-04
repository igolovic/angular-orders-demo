using Microsoft.EntityFrameworkCore;
using OrdersDemo.Domain.Entities;
using OrdersDemo.Domain.Interfaces;
using OrdersDemo.Infrastructure.Persistence;

namespace OrdersDemo.Infrastructure
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersDbContext context;

        public OrderRepository(OrdersDbContext context)
        {
            this.context = context;
        }

        public void DeleteOrder(Order order)
        {
            context.Remove(order);
        }

        public Order SaveOrder(Order order)
        {
            if (order.Id == 0)
            {
                order.CreatedAt = DateTime.UtcNow;
                context.Orders.Add(order);
                context.SaveChanges();
                return order;
            }

            // Load tracked order with items
            var tracked = context.Orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.Id == order.Id);

            if (tracked == null)
                throw new InvalidOperationException($"Order with Id {order.Id} not found.");

            // Update scalar properties
            tracked.ClientId = order.ClientId;
            tracked.ModifiedAt = DateTime.UtcNow;

            // Remove items that are not present in incoming order
            var incomingIds = order.Items.Where(i => i.Id != 0).Select(i => i.Id).ToHashSet();
            foreach (var existingItem in tracked.Items.ToList())
            {
                if (!incomingIds.Contains(existingItem.Id))
                {
                    // mark for deletion
                    context.OrderItems.Remove(existingItem);
                }
            }

            // Add new items or update existing ones
            foreach (var incoming in order.Items)
            {
                if (incoming.Id == 0)
                {
                    // new item
                    var newItem = new OrderItem
                    {
                        ProductId = incoming.ProductId,
                        Quantity = incoming.Quantity
                    };
                    tracked.Items.Add(newItem);
                }
                else
                {
                    var existing = tracked.Items.FirstOrDefault(i => i.Id == incoming.Id);
                    if (existing != null)
                    {
                        existing.ProductId = incoming.ProductId;
                        existing.Quantity = incoming.Quantity;
                    }
                    else
                    {
                        // Defensive: incoming refers to an item not present in tracked collection.
                        // Attach it explicitly as modified if needed.
                        var attached = new OrderItem
                        {
                            Id = incoming.Id,
                            OrderId = tracked.Id,
                            ProductId = incoming.ProductId,
                            Quantity = incoming.Quantity
                        };
                        context.OrderItems.Attach(attached);
                        context.Entry(attached).State = EntityState.Modified;
                    }
                }
            }

            context.SaveChanges();
            return tracked;
        }
    }
}
