namespace PUMP.core.BL.Interfaces;

public interface IMembers
{
    // Create new members
    Task<bool> Save(models.Members members);
    
    // Read all members
    Task<List<models.Members>> Get();
    
    // Update members
    Task<bool> Update(models.Members members);
    
    // Delete members
    Task<bool> Delete(models.Members members);
    
}