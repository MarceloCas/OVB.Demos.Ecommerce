using FluentValidation.Results;
using Microsoft.Extensions.Caching.Memory;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Repositories;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Caching;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Cryptography;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Logging;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Messenger;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Entities;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Validators;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Caching;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;

public class CreateAuthenticationHandler : HandlerBase<CreateAuthenticationResponse, CreateAuthenticationRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IMemoryCache _memoryCache;
    private readonly ICacheInformation _cacheInformation;
    private readonly ICryptographyService _cryptographyService;
    private readonly ILoggingService _loggingService;
    private readonly IMessengerService _messengerService;

    /// <summary>
    /// Construtor para o Handler de Criação de Autenticação do Usuário
    /// </summary>
    /// <param name="userRepository">Serviços de Repositório</param>
    /// <param name="cacheInformation">Implementação</param>
    /// <param name="memoryCache">Serviços de Cache de Memória</param>
    /// <param name="cryptographyService">Serviços de Criptografia</param>
    /// <param name="loggingService">Serviços de log da aplicação</param>
    public CreateAuthenticationHandler(
        IUserRepository userRepository, 
        ICacheInformation cacheInformation, 
        IMemoryCache memoryCache, 
        ICryptographyService cryptographyService, 
        ILoggingService loggingService,
        IMessengerService messengerService) 
        : base()
    {
        _userRepository = userRepository;
        _cacheInformation = cacheInformation;
        _memoryCache = memoryCache;
        _cryptographyService = cryptographyService;
        _loggingService = loggingService;
        _messengerService = messengerService;
    }

    /// <summary>
    /// Handler para criar autenticação do usuário no microsserviço.
    /// </summary>
    /// <param name="request">Pedido de Requisição</param>
    /// <returns>Retorno da Requisição</returns>
    public async override Task<CreateAuthenticationResponse> Handle(CreateAuthenticationRequest request)
    {
        try
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

                    // Criptografa senha do usuário
                    string passwordEncrypted = _cryptographyService.CreateEncryptedInformation(request.User.PasswordEncrypted);

                    // Insere o novo usuário no banco de dados
                    var userEntity = new UserEntity(request.User.Identifier, request.User.Username, request.User.NameComplete, request.User.Points, request.User.Email, passwordEncrypted, request.User.TypeUser.ToString());
                    await _userRepository.AddAsync(userEntity);

                    _messengerService.SendMessage("CREATE_AUTHENTICATION_HANDLER", $"CONTACRIADA&Username={userEntity.Username};Email={userEntity.Email};");

                    return new CreateAuthenticationResponse(Guid.NewGuid(), 200, validationResults.Errors);
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
        catch(Exception ex)
        {
            await _loggingService.AddNewLogErrorInformation(ex.Message);
            return new CreateAuthenticationResponse(Guid.NewGuid(), 500, new List<ValidationFailure>()
            {
                new ValidationFailure("HTTP ERROR 500", "Erro interno do sistema, não foi possível realizar a requisição.")
            });
        }
    }
}
