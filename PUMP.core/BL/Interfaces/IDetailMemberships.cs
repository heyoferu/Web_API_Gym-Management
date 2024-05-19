namespace PUMP.core.BL.Interfaces;

public interface IDetailMemberships
{
    Task<bool> Create(models.DetailMemberships detailMemberships);
    Task<object?> Read(int? id);
    Task<bool> Update(models.DetailMemberships detailMemberships);
    Task<bool> Delete(models.DetailMemberships detailMemberships);
    
}