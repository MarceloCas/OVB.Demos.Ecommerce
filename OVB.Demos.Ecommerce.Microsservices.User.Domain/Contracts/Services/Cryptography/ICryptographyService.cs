namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Cryptography;

public interface ICryptographyService
{
    public string CreateEncryptedInformation(string information);
    public string VerifyEncryptedInformation(string encryptedInformation, string information);
}
