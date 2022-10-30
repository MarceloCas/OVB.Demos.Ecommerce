using FluentValidation.Results;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Repositories;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Validators;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationHandler : HandlerBase<CreateAuthenticationResponse, CreateAuthenticationRequest>
{
    private readonly IUserRepository _userRepository;

    public CreateAuthenticationHandler(IUserRepository userRepository) : base()
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handler para criar autenticação do usuário no microsserviço.
    /// </summary>
    /// <param name="request">Pedido de Requisição</param>
    /// <returns>Retorno da Requisição</returns>
    public async override Task<CreateAuthenticationResponse> Handle(CreateAuthenticationRequest request)
    {
        var validationResults = request.Validator.Validate(request.User);

        if (validationResults.IsValid == true)
        {
            // Verificar se email não é utilizado
            bool emailExists = await _userRepository.VerifyUserExistsAsyncWithEmail(request.User.Email);
            if (emailExists == true)
            {
                validationResults.Errors.Add(new ValidationFailure("Email", "Email needs to be unusable"));
                return new CreateAuthenticationResponse(Guid.NewGuid(), 404, validationResults.Errors);
            }

            bool usernameExists = await _userRepository.VerifyUserExistsAsyncWithUsername(request.User.Username);
            if (usernameExists == true)
            {
                validationResults.Errors.Add(new ValidationFailure("Username", "Username needs to be unusable"));
                return new CreateAuthenticationResponse(Guid.NewGuid(), 404, validationResults.Errors);
            }
        }
        else
        {
            CreateAuthenticationResponse createAuthenticationResponse = new CreateAuthenticationResponse(Guid.NewGuid(), 404, validationResults.Errors);
            return createAuthenticationResponse;
        }

        throw new NotImplementedException();
    }
}
