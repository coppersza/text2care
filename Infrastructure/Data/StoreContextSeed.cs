using System.Reflection;
//using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
                    var typesData = File.ReadAllText(path + @"/Data/SeedData/InsertCountryFull.json");
                    var types = JsonConvert.DeserializeObject<List<Country>>(typesData);
                    foreach (var item in types)
                    {
                        context.Countries.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Stores.Any()){
                    var storeData = File.ReadAllText(path + @"/Data/SeedData/InsertStoreFull.json");
                    var stores = JsonConvert.DeserializeObject<List<Store>>(storeData);
                    foreach (var item in stores)
                    {
                        context.Stores.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any()){
                    var typesData = File.ReadAllText(path + @"/Data/SeedData/InsertProductType.json");
                    var types = JsonConvert.DeserializeObject<List<ProductType>>(typesData);
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Products.Any()){
                    var productData = File.ReadAllText(path + @"/Data/SeedData/InsertProduct.json");
                    var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.DeliveryMethods.Any()){
                    var jsonData = File.ReadAllText(path + @"/Data/SeedData/InsertDeliveryMethod.json");
                    var data = JsonConvert.DeserializeObject<List<DeliveryMethod>>(jsonData);
                    foreach (var item in data)
                    {
                        context.DeliveryMethods.Add(item);
                    }
                    await context.SaveChangesAsync();
                }



                if (!context.Donators.Any()){
                    var data = File.ReadAllText(path + @"/Data/SeedData/InsertDonatorFull.json");
                    var items = JsonConvert.DeserializeObject<List<Donator>>(data);
                    foreach (var item in items)
                    {
                        context.Donators.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Recipients.Any()){
                    var data = File.ReadAllText(path + @"/Data/SeedData/InsertRecipientFull.json");
                    var items = JsonConvert.DeserializeObject<List<Recipient>>(data);
                    foreach (var item in items)
                    {
                        context.Recipients.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.Employees.Any()){
                    var data = File.ReadAllText(path + @"/Data/SeedData/InsertEmployeeFull.json");
                    var items = JsonConvert.DeserializeObject<List<Employee>>(data);
                    foreach (var item in items)
                    {
                        context.Employees.Add(item);
                    }
                    await context.SaveChangesAsync();
                }         
                if (!context.StoreRecipients.Any()){
                    var jsonData = File.ReadAllText(path + @"/Data/SeedData/InsertStoreRecipientFull.json");
                    var data = JsonConvert.DeserializeObject<List<StoreRecipient>>(jsonData);
                    foreach (var item in data)
                    {
                        context.StoreRecipients.Add(item);
                    }
                    await context.SaveChangesAsync();
                }                       
                if (!context.Tokens.Any()){
                    var data = File.ReadAllText(path + @"/Data/SeedData/InsertTokenFull.json");
                    var items = JsonConvert.DeserializeObject<List<Token>>(data, new IsoDateTimeConverter { DateTimeFormat = "yyyy-mm-dd hh:mm:ss" });
                    foreach (var item in items)
                    {
                        context.Tokens.Add(item);
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

