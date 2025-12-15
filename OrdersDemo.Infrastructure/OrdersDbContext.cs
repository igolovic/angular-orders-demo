using Microsoft.EntityFrameworkCore;
using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Infrastructure.Persistence
{
    // wie soll ich erste migration aus VS ausfuehren damit ich eine neu-erstellte sql database bekomme, wie konfiguriert
    // kann die erste migration neue datenbank erstellen, oder muss ich das manuel machen?

    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Order
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany()
                .HasForeignKey(o => o.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Items)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId);

            // OrderItem
            modelBuilder.Entity<OrderItem>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Client
            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id);

            // Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            // Clients
            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, Name = "Max Mustermann" },
                new Client { Id = 2, Name = "Erika Musterfrau" }
            );

            ////////////
            // Seed data
            ////////////

            // Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Tisch" },
                new Product { Id = 2, Name = "Stuhl" }
            );

            // Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, ClientId = 1, CreatedAt = DateTime.UtcNow },
                new Order { Id = 2, ClientId = 2, CreatedAt = DateTime.UtcNow }
            );

            // OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Quantity = 2 },
                new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Quantity = 4 },
                new OrderItem { Id = 3, OrderId = 2, ProductId = 2, Quantity = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
