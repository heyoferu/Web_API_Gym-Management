namespace PUMP.core.BL.Interfaces;

public interface IProductsPayments
{
    Task<bool> Create(models.ProductsPayments productsPayments);
    Task<List<models.ProductsPayments>> Read();
    Task<bool> Update(models.ProductsPayments productsPayments);
    Task<bool> Delete(models.ProductsPayments productsPayments);
}