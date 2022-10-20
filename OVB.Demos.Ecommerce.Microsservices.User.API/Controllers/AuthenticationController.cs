using Microsoft.AspNetCore.Mvc;

namespace OVB.Demos.Ecommerce.Microsservices.User.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthenticationController : ControllerBase
{
    /// <summary>
    /// Criar uma nova conta de autentica��o do usu�rio
    /// </summary>
    /// <returns>Retorno � um status HTTP</returns>
    [HttpPost]
    [Route("CreateAuth")]
    public ActionResult Create()
    {
        return StatusCode(500);
    }

    /// <summary>
    /// Logar usu�rio em uma autentica��o
    /// </summary>
    /// <returns>Retorno � um status HTTP</returns>
    [HttpGet]
    [Route("LoginAuth")]
    public ActionResult Login()
    {
        return StatusCode(500);
    }
}
