using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    public Task<bool> VerifyUserExistsAsync(Username username);
    public Task<bool> VerifyUserExistsAsync(NameComplete nameComplete);
    public Task<bool> VerifyUserExistsAsync(Email email);
}
