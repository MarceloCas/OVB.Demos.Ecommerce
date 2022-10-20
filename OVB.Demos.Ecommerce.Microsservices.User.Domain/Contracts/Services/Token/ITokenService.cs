using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Token;

public interface ITokenService
{
    public string JwtBearerKeyToken { get; }
    public string CreateToken(UserBase userbase);
    public string RefreshToken(UserBase userBase);
}
