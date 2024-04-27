using PUMP.core.BL.Interfaces;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class AuthenticationServices : IAuthentication
{
    public async Task<bool> Login(Employees employees)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (from item in connection.Employees
                    where item.Id == employees.Id &&
                          item.Password == employees.Password
                    select item
                ).FirstOrDefault();
            if (query != null)
            {
                result = true;
            }
        }
        return await Task.FromResult(result);
    }
}