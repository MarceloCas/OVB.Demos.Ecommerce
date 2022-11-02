using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Cryptography;

/// <summary>
/// Serviço de Criptografia do Microsserviço
/// </summary>
public class CryptographyService : ICryptographyService
{
    private readonly HashAlgorithm hashAlgorithm;

    public CryptographyService()
    {
        hashAlgorithm = SHA256.Create();
    }

    /// <summary>
    /// Criptografar um texto
    /// </summary>
    /// <param name="information">Texto a ser encriptografado</param>
    /// <returns>Valor Encriptografado</returns>
    public string CreateEncryptedInformation(string information)
    {
        var encodedValue = Encoding.UTF8.GetBytes(information);
        var encryptedPassword = hashAlgorithm.ComputeHash(encodedValue);
        var sb = new StringBuilder();
        foreach (var caracter in encryptedPassword) sb.Append(caracter.ToString("X2"));
        return sb.ToString();
    }

    /// <summary>
    /// Verificar se um elemento criptografado está de acordo com um texto
    /// </summary>
    /// <param name="encryptedInformation">Texto Criptografado</param>
    /// <param name="information">Texto Não Criptografado</param>
    /// <returns>Booleano</returns>
    public bool VerifyEncryptedInformation(string encryptedInformation, string information)
    {
        return CreateEncryptedInformation(information) == encryptedInformation;
    }
}
