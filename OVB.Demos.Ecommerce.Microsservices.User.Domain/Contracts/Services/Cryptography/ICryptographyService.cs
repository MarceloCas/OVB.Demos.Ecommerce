namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Cryptography;

public interface ICryptographyService
{
    public string CreateEncryptedInformation(string information);
    public bool VerifyEncryptedInformation(string encryptedInformation, string information);
}
