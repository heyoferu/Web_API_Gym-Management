namespace PUMP.core.BL.Interfaces;

public interface IProducts
{
    Task<bool> Create(models.Products products);
    Task<object?> Read(int? id);
    Task<bool> Update(models.Products products);
    Task<bool> Delete(int? id);
}