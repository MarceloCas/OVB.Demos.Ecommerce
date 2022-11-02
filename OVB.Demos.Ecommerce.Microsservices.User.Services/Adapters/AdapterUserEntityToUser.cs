using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Adapters;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Adapters;

/// <summary>
/// Adaptar entitidade do banco de dados para o design orientado a objetos do projeto
/// </summary>
public class AdapterUserEntityToUser : IAdapter<UserBase, UserEntity>
{
    /// <summary>
    /// Método para adapter os elementos
    /// </summary>
    /// <param name="target">Entidade do banco de dados</param>
    /// <returns>Entidade da Orientação a Objetos</returns>
    public UserBase Adapt(UserEntity target)
    {
        return new UserStandard(target.Identifier, target.Username, target.NameComplete, target.Points, target.Password, target.Email);
    }
}
