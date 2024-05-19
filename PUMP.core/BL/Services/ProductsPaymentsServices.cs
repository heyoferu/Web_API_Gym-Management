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

    public Task<List<ProductsPayments>> Read()
    {
        List<ProductsPayments> list = new List<ProductsPayments>();
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.ProductsPayments
                select item
            ).ToList();

            foreach (var item in query)
            {
                list.Add(new ProductsPayments()
                {
                    Id = item.Id,
                    Employee = item.Employee,
                    DatePayment = item.DatePayment,
                    Product = item.Product,
                    Quantity = item.Quantity
                });
            }
            
            return Task.FromResult(list);
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