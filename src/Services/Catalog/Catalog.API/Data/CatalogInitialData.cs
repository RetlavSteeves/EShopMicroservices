using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if(await session.Query<Product>().AnyAsync())
            return;

        session.Store<Product>(GetPreConfiguredProducts());    
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreConfiguredProducts() => new List<Product>
    {
        new Product()
        {
            Id = new Guid("09bd95a2-c8a2-4f33-a4da-acb8a376ccda"),
            Name = "IPhone 14",
            Description = "This phone is the company's biggest product",
            ImageFile = "product-1.png",
            Price = 950.00m,
            Category = new List<string> {"Smart Phone"} 
        },
        new Product()
        {
            Id = new Guid("67af4d7b-7bd9-4728-a790-c00234254f6a"),
            Name = "IPhone X",
            Description = "This phone is the company's biggest product",
            ImageFile = "product-2.png",
            Price = 960.00m,
            Category = new List<string> {"Smart Phone"} 
        },
        new Product()
        {
            Id = new Guid("b296e966-615a-443c-842c-dd06896dae90"),
            Name = "IPhone 13 mini",
            Description = "This phone is the company's biggest product",
            ImageFile = "product-3.png",
            Price = 850.00m,
            Category = new List<string> {"Smart Phone"} 
        },
        new Product()
        {
            Id = new Guid("a010aab3-cf04-46a7-9b10-74c3efeb9d72"),
            Name = "Samsung S21",
            Description = "This phone is the company's biggest product",
            ImageFile = "product-4.png",
            Price = 750.00m,
            Category = new List<string> {"Smart Phone"} 
        }
    };

}
