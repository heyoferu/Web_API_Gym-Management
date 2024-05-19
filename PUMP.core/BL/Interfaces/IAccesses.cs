namespace PUMP.core.BL.Interfaces;

public interface IAccesses
{
    Task<bool> Create(models.Accesses accesses);
    Task<object?> Read(int? id);
    Task<bool> Update(models.Accesses accesses);
    Task<bool> Delete(models.Accesses accesses);
}