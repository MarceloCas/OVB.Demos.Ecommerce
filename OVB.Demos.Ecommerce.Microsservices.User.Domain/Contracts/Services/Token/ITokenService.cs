using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Token;

public interface ITokenService
{
    public void CreateToken(UserBase userbase);
    public void RefreshToken(UserBase userBase);
}
