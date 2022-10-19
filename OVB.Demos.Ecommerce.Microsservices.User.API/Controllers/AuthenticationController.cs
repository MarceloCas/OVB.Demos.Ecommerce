using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.User.API.Controllers;

/// <summary>
/// Controlador de Autenticação do Usuário
/// </summary>
[ApiController]
[Route("api/v1/User/[controller]")]
public class AuthenticationController : ControllerBase
{
    /// <summary>
    /// Criar um novo usuári na plataforma
    /// </summary>
    /// <returns>Retorno é um resultado de uma ação em HTTP.</returns>
    [HttpPost]
    [Route("Create")]
    public ActionResult CreateAnNewUser()
    {
        return StatusCode(500);// Not implemented
    }
}