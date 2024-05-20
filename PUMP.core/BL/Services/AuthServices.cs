using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PUMP.core.BL.Interfaces;
using PUMP.helpers;
using PUMP.models;

namespace PUMP.core.BL.Services;

public class AuthServices : IAuth
{
    public Task<string?> Login(string username, string password)
    {
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (from item in connection.Users
                    where item.Username == username &&
                          item.Password == password
                    select item
                ).FirstOrDefault();
            if (query != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Settings.Key;
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, query.Username)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature),
                    Issuer = Settings.Issuer,
                    Audience = Settings.Issuer
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Task.FromResult<string?>(tokenHandler.WriteToken(token));
            }

            return Task.FromResult<string>(null);
        }
    }

    public Task<bool> Register(string username, string password)
    {
        bool result = false;
        using (var connection = new data.SQLServer.InitDb())
        {
            var query = (
                from item in connection.Users
                where item.Username == username
                select item
            ).FirstOrDefault();

            if (query == null)
            {
                Users usr = new Users();
                usr.Username = username;
                usr.Password = password;
                connection.Users.Add(usr);
                result = connection.SaveChanges() > 0;
            }
        } 
        return Task.FromResult(result);
    }
}