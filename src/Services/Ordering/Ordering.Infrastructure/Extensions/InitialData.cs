using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers 
        => new List<Customer>
    {
            Customer.Create(CustomerId.Of(new Guid("0fbe8908-c508-47f5-b5d3-83f8b8abc723")),"vhae","vhae@gmail.com" ),
            Customer.Create(CustomerId.Of(new Guid("70f54bbd-9bf0-4b05-a0f6-874186e99c80")),"vhae2","vhae2@gmail.com" )

    };

    public static IEnumerable<Product> Products
        => new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("4463621a-0808-4341-9ea9-f2401b7a951d")), "Iphone 13", 500),
            Product.Create(ProductId.Of(new Guid("fe33475a-4fa6-4cf7-83b9-366d6246dbb6")), "Iphone 14", 600),
            Product.Create(ProductId.Of(new Guid("b464a5b9-1403-4317-a8ea-5d39683d989b")), "Iphone 15", 700),
            Product.Create(ProductId.Of(new Guid("d0b5d5b4-a5b7-46cc-921d-25246e18b298")), "Iphone 16", 800),
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("vhae","ae","vhae@gmail.com","Angola","Portugal","Lisbon","2735");
            var address2 = Address.Of("vhae2","ae2","vhae2@gmail.com","Angola","Portugal","Lisbon","2736");

            var payment1 = Payment.Of("vhae", "4567345634567", "12/24", "345", 1);
            var payment2 = Payment.Of("vhae2", "4567345634568", "12/25", "348", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("0fbe8908-c508-47f5-b5d3-83f8b8abc723")), 
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1
            );
            order1.Add(ProductId.Of(new Guid("4463621a-0808-4341-9ea9-f2401b7a951d")),1,500);
            order1.Add(ProductId.Of(new Guid("fe33475a-4fa6-4cf7-83b9-366d6246dbb6")),3,600);
            
            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("70f54bbd-9bf0-4b05-a0f6-874186e99c80")), 
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2
            );
            order1.Add(ProductId.Of(new Guid("4463621a-0808-4341-9ea9-f2401b7a951d")),2,500);
            order1.Add(ProductId.Of(new Guid("fe33475a-4fa6-4cf7-83b9-366d6246dbb6")),1,600);

            return new List<Order> { order1, order2 };
        }
    }
}