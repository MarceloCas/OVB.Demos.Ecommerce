using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Repositories;

public interface IUserRepository : IBaseRepository<UserEntity>
{
    public Task<bool> VerifyUserExistsAsyncWithUsername(string username);
    public Task<bool> VerifyUserExistsAsyncWithNameComplete(string nameComplete);
    public Task<bool> VerifyUserExistsAsyncWithEmail(string email);
}
