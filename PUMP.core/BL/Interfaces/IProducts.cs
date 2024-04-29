namespace PUMP.core.BL.Interfaces;

public interface IProducts
{
    Task<bool> Create(models.Products products);
    Task<List<models.Products>> Read();
    Task<bool> Update(models.Products products);
    Task<bool> Delete(models.Products products);
}