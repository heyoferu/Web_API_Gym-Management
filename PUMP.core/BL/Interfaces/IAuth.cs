namespace PUMP.core.BL.Interfaces;

public interface IAuth
{
    Task<string?> Login(string username, string password);
    Task<bool> Register(string username, string password);
}