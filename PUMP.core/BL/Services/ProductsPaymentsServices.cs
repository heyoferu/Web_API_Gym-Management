using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class ProductsPaymentsServices : IProductsPayments
{
    public Task<bool> Create(ProductsPayments productsPayments)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.ProductsPayments
                where item.Id == productsPayments.Id
                select item
            ).FirstOrDefault();

            if (query == null)
            {
                ProductsPayments pp = new ProductsPayments();
                pp.Id = productsPayments.Id;
                pp.Employee = productsPayments.Employee;
                pp.DatePayment = productsPayments.DatePayment;
                pp.Product = productsPayments.Product;
                pp.Quantity = productsPayments.Quantity;
                connection.ProductsPayments.Add(pp);
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
                var query = (from item in connection.Accesses
                    where item.Id == id.Value
                    select new
                    {
                        item.Id,
                        item.Membership,
                        item.DateSa
                    }).FirstOrDefault();
                return Task.FromResult<object?>(query);
            }

            if (id == null)
            {
                var query = (
                    from item in connection.Accesses
                    select new
                    {
                        item.Id,
                        item.Membership,
                        item.DateSa
                    }).ToList();
                
                return Task.FromResult<object?>(query);
            }
            else
            {
                return Task.FromResult<object?>(null);
            }
        }
    }

    public Task<bool> Update(ProductsPayments productsPayments)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.ProductsPayments
                where item.Id == productsPayments.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                query.Id = productsPayments.Id;
                query.Employee = productsPayments.Employee;
                query.DatePayment = productsPayments.DatePayment;
                query.Product = productsPayments.Product;
                query.Quantity = productsPayments.Quantity;
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }

    public Task<bool> Delete(ProductsPayments productsPayments)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.ProductsPayments
                where item.Id == productsPayments.Id
                select item
            ).FirstOrDefault();

            if (query != null)
            {
                connection.ProductsPayments.Remove(query);
                result = connection.SaveChanges() > 0;
            }
        }

        return Task.FromResult(result);
    }
}