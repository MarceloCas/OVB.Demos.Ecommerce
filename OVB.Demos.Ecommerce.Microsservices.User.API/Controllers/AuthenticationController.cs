using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Repositories;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Cryptography;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Handler;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Logging;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.DTOs.User;
using OVB.Demos.Ecommerce.Microsservices.User.Domain.Models.Validators;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Caching;
using OVB.Demos.Ecommerce.Microsservices.User.Services.Handler.CreateAuthentication;
using System.ComponentModel.DataAnnotations;

namespace OVB.Demos.Ecommerce.Microsservices.User.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    /// <summary>
    /// Criar uma nova conta de autenticação do usuário
    /// </summary>
    /// <returns>Retorno é um status HTTP</returns>
    [HttpPost]
    [Route("CreateAuth")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public async Task<CreateAuthenticationResponse> Create(
        [FromServices] IUserRepository userRepository, [FromServices] IMemoryCache memoryCache, 
        [FromServices] ILoggingService loggingService, [FromServices] ICryptographyService cryptographyService
        [FromHeader][Required] string username, 
        [FromHeader][Required] string email, 
        [FromHeader][Required] string password,
        [FromHeader][Required] string nameComplete)
    {
        var requestIdentifier = Guid.NewGuid();
        var handler = new CreateAuthenticationHandler(userRepository, new CachingServiceRequests(requestIdentifier, "CreateAuthentication"), memoryCache, cryptographyService, loggingService);
        var response = await handler.Handle(new CreateAuthenticationRequest(requestIdentifier, DateTime.Now, new CreateUserValidator(), new UserStandard(Guid.NewGuid(), username, nameComplete, 0, password, email)));
        return response;
    }

    /// <summary>
    /// Logar usuário em uma autenticação
    /// </summary>
    /// <returns>Retorno é um status HTTP</returns>
    [HttpGet]
    [Route("LoginAuth")]
    [Produces("application/json")]
    public ActionResult Login()
    {
        return StatusCode(500);
    }
}
