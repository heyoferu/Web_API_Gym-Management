using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class ProductsServices : IProducts
{
    public Task<bool> Create(Products products)
    {
        var result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Products
                where item.Id == products.Id
                select item
            ).FirstOrDefault();

            if (query == null)
            {
                Products prod = new Products();
                prod.Id = products.Id;
                prod.Name = products.Name;
                prod.Description = products.Description;
                prod.Price = products.Price;
                prod.Category = products.Category;
                prod.Stock = products.Stock;
                connection.Products.Add(prod);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<List<Products>> Read()
    {
        List<Products> productsList = new List<Products>();
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Products
                select item
            ).ToList();

            foreach (var item in query)
            {
                productsList.Add(new Products()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Category = item.Category,
                    Stock = item.Stock
                });
            }

            return Task.FromResult(productsList);

        }
    }

    public Task<bool> Update(Products products)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Products
                where item.Id == products.Id
                select item
            ).FirstOrDefault();
            if (query != null)
            {
                query.Id = products.Id;
                query.Name = products.Name;
                query.Description = products.Description;
                query.Price = products.Price;
                query.Category = products.Category;
                query.Stock = products.Stock;

                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<bool> Delete(Products products)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Products
                where item.Id == products.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                connection.Products.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }
}