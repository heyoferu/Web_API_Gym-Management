namespace PUMP.core.BL.Interfaces;

public interface ICategory
{
    Task<bool> Create(models.Category category);
    Task<List<models.Category>> Read();
    Task<bool> Update(models.Category category);
    Task<bool> Delete(models.Category category);
}