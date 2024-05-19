namespace PUMP.core.BL.Interfaces;

public interface IMemberships
{
    Task<bool> Create(models.Memberships memberships);
    Task<List<models.Memberships>> Read();
    Task<bool> Update(models.Memberships memberships);
    Task<bool> Delete(models.Memberships memberships);
}