using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Token;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Token;

public sealed class TokenService : ITokenService
{
    public string JwtBearerKeyToken { get; }

    public TokenService()
    {
        JwtBearerKeyToken = @"";
    }

    public string CreateToken(UserBase userbase)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(JwtBearerKeyToken);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Identifier", userbase.Identifier.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public string RefreshToken(UserBase userBase)
    {
        throw new NotImplementedException();
    }
}
