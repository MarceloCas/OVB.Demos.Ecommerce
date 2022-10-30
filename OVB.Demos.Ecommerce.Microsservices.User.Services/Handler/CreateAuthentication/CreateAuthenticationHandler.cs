using FluentValidation.Results;
using Microsoft.Extensions.Caching.Memory;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Repositories;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Caching;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Validators;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Caching;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationHandler : HandlerBase<CreateAuthenticationResponse, CreateAuthenticationRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IMemoryCache _memoryCache;
    private readonly ICacheInformation _cacheInformation;

    /// <summary>
    /// Construtor para o Handler de Criação de Autenticação do Usuário
    /// </summary>
    /// <param name="userRepository">Serviços de Repositório</param>
    /// <param name="cacheInformation">Implementação</param>
    /// <param name="memoryCache">Serviços de Cache de Memória</param>
    public CreateAuthenticationHandler(IUserRepository userRepository, ICacheInformation cacheInformation, IMemoryCache memoryCache) : base()
    {
        _userRepository = userRepository;
        _cacheInformation = cacheInformation;
        _memoryCache = memoryCache;
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
            var requestCache = await _memoryCache.GetOrCreateAsync($"{_cacheInformation.GetCachingServiceDeclarationDescription()}_{request.User.Username}_{request.User.Email}_{request.User.Identifier}", async entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(_cacheInformation.Time);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(_cacheInformation.Time);
                entry.SetPriority(CacheItemPriority.Normal);

                // Verificar se email não é utilizado
                bool emailExists = await _userRepository.VerifyUserExistsAsyncWithEmail(request.User.Email);
                if (emailExists == true)
                {
                    validationResults.Errors.Add(new ValidationFailure("Email", "Email needs to be unusable"));
                    return new CreateAuthenticationResponse(Guid.NewGuid(), 404, validationResults.Errors);
                }

                // Verificar se nome de usuário já não é utilizado
                bool usernameExists = await _userRepository.VerifyUserExistsAsyncWithUsername(request.User.Username);
                if (usernameExists == true)
                {
                    validationResults.Errors.Add(new ValidationFailure("Username", "Username needs to be unusable"));
                    return new CreateAuthenticationResponse(Guid.NewGuid(), 404, validationResults.Errors);
                }

                return new CreateAuthenticationResponse(Guid.NewGuid(), 200);
            });

            return requestCache;
        }
        else
        {
            CreateAuthenticationResponse createAuthenticationResponse = new CreateAuthenticationResponse(Guid.NewGuid(), 404, validationResults.Errors);
            return createAuthenticationResponse;
        }

        throw new NotImplementedException();
    }
}
