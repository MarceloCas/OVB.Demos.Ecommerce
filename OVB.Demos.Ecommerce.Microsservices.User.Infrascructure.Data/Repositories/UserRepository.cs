using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Repositories;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.User.Infrascructure.Data.Repositories;

/// <summary>
/// Repositório para mudança no banco de dados de usuário
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    private async Task SaveChanges()
    {
        await _dataContext.SaveChangesAsync();
    }

    public async Task AddAsync(UserEntity entity)
    {
        await _dataContext.Users.AddAsync(entity);
        await SaveChanges();
    }

    public async Task AddRangeAsync(List<UserEntity> entity)
    {
        await _dataContext.Users.AddRangeAsync(entity);
        await SaveChanges();
    }

    public async Task DeleteAsync(UserEntity entity)
    {
        _dataContext.Users.Remove(entity);
        await SaveChanges();
    }

    public async Task<List<UserEntity>> GetAllAsync()
    {
        return await _dataContext.Users.ToListAsync();
    }

    public async Task<UserEntity?> GetAsync(Guid identifier)
    {
        return await _dataContext.Users.Where(p => p.Identifier == identifier).FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(UserEntity entity)
    {
        _dataContext.Users.Update(entity);
        await SaveChanges();
    }

    public Task<bool> VerifyUserExistsAsync(Username username)
    {
        return _dataContext.Users.Where(p => p.Username == username.ToString()).AnyAsync();
    }

    public Task<bool> VerifyUserExistsAsync(NameComplete nameComplete)
    {
        return _dataContext.Users.Where(p => p.NameComplete == nameComplete.ToString()).AnyAsync();
    }

    public Task<bool> VerifyUserExistsAsync(Email email)
    {
        return _dataContext.Users.Where(p => p.Email == email.ToString()).AnyAsync();
    }
}
