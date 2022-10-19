using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.User.API.Controllers;

/// <summary>
/// Controlador de Autentica��o do Usu�rio
/// </summary>
[ApiController]
[Route("api/v1/User/[controller]")]
public class AuthenticationController : ControllerBase
{
    /// <summary>
    /// Criar um novo usu�ri na plataforma
    /// </summary>
    /// <returns>Retorno � um resultado de uma a��o em HTTP.</returns>
    [HttpPost]
    [Route("Create")]
    public ActionResult CreateAnNewUser()
    {
        return StatusCode(500);// Not implemented
    }
}