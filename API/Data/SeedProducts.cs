using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class SeedProducts
    {
        public static async Task SeedProduct(DataContext context)
    {
        if (await context.Products.AnyAsync()) return;

        var productData = await File.ReadAllTextAsync("Data/ProductJsonData.json");

        var products = JsonSerializer.Deserialize<List<Product>>(productData);

        foreach (var product in products)
        {
            context.Products.Add(product);
        }

        await context.SaveChangesAsync();
    }
    }
}