namespace PUMP.core.BL.Interfaces;

public interface IMemberships
{
    Task<bool> Create(models.Memberships memberships);
    Task<object?> Read(int? id);
    Task<bool> Update(models.Memberships memberships);
    Task<bool> Delete(models.Memberships memberships);
}