namespace PUMP.core.BL.Interfaces;

public interface ICategory
{
    Task<bool> Create(models.Category category);
    Task<object?> Read(int? id);
    Task<bool> Update(models.Category category);
    Task<bool> Delete(int? id);
}