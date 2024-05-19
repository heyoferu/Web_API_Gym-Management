namespace PUMP.core.BL.Interfaces;

public interface IMembers
{
    // Create new members
    Task<bool> Create(models.Members members);
    
    // Read all members
    Task<object?> Read(int? id);
    
    // Update members
    Task<bool> Update(models.Members members);
    
    // Delete members
    Task<bool> Delete(models.Members members);
    
}