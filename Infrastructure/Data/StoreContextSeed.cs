using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){
            var tempToken = "";
            try
            {                
                //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var path = "../Infrastructure";
                if (!context.Countries.Any()){
                    var typesData = File.ReadAllText(path + @"/Data/SeedData/InsertCountry.json");
                    var types = JsonSerializer.Deserialize<List<Country>>(typesData);
                    foreach (var item in types)
                    {
                        context.Countries.Add(item);
                    }
                    await context.SaveChangesAsync();
                }                
                if (!context.Stores.Any()){
                    var storeData = File.ReadAllText(path + @"/Data/SeedData/InsertStore.json");
                    var stores = JsonSerializer.Deserialize<List<Store>>(storeData);
                    foreach (var item in stores)
                    {
                        context.Stores.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                
                if (!context.ProductTypes.Any()){
                    var typesData = File.ReadAllText(path + @"/Data/SeedData/InsertProductType.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }                
                if (!context.Products.Any()){
                    var productData = File.ReadAllText(path + @"/Data/SeedData/InsertProduct.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Donators.Any()){
                    var data = File.ReadAllText(path + @"/Data/SeedData/InsertDonator.json");
                    var items = JsonSerializer.Deserialize<List<Donator>>(data);
                    foreach (var item in items)
                    {
                        context.Donators.Add(item);
                    }
                    await context.SaveChangesAsync();
                }        
                if (!context.Recipients.Any()){
                    var data = File.ReadAllText(path + @"/Data/SeedData/InsertRecipient.json");
                    var items = JsonSerializer.Deserialize<List<Recipient>>(data);
                    foreach (var item in items)
                    {
                        context.Recipients.Add(item);
                    }
                    await context.SaveChangesAsync();
                }       
                if (!context.Tokens.Any()){
                    var data = File.ReadAllText(path + @"/Data/SeedData/InsertToken.json");
                    var items = JsonSerializer.Deserialize<List<Token>>(data);
                    foreach (var item in items)
                    {
                        context.Tokens.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.DeliveryMethods.Any()){
                    var jsonData = File.ReadAllText(path + @"/Data/SeedData/InsertDeliveryMethod.json");
                    var data = JsonSerializer.Deserialize<List<DeliveryMethod>>(jsonData);
                    foreach (var item in data)
                    {
                        context.DeliveryMethods.Add(item);
                    }
                    await context.SaveChangesAsync();
                }                       

            }
            catch(Exception ex){
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(tempToken + "----" + ex.Message);
            }                    
        }
    }
}

