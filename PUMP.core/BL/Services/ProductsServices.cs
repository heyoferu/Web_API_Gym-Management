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

    public Task<object?> Read(int? id)
    {
        using (var connection = new data.SQLServer.InitDb())
        {
            if (id.HasValue)
            {
                var query = (from item in connection.Products
                    where item.Id == id.Value
                    select new
                    {
                        item.Id,
                        item.Name,
                        item.Description,
                        item.Price,
                        item.Category,
                    }).FirstOrDefault();
                return Task.FromResult<object?>(query);
            }

            if (id == null)
            {
                var query = (
                    from item in connection.Products
                    select new
                    {
                        item.Id,
                        item.Name,
                        item.Description,
                        item.Price,
                        item.Category,
                        item.Stock
                    }).ToList();
                
                return Task.FromResult<object?>(query);
            }
            else
            {
                return Task.FromResult<object?>(null);
            }
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