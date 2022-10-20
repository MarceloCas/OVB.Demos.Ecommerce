using Microsoft.AspNetCore.Mvc;

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
    public ActionResult Create()
    {
        return StatusCode(500);
    }

    /// <summary>
    /// Logar usuário em uma autenticação
    /// </summary>
    /// <returns>Retorno é um status HTTP</returns>
    [HttpGet]
    [Route("LoginAuth")]
    public ActionResult Login()
    {
        return StatusCode(500);
    }
}
