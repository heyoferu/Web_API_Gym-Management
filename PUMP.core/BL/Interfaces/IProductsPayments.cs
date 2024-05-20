namespace PUMP.core.BL.Interfaces;

public interface IProductsPayments
{
    Task<bool> Create(models.ProductsPayments productsPayments);
    Task<object?> Read(int? id);
    Task<bool> Update(models.ProductsPayments productsPayments);
    Task<bool> Delete(int? id);
}