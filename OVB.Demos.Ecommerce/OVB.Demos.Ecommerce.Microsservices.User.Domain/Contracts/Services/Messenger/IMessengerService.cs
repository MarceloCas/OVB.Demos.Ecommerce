namespace OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Messenger;

public interface IMessengerService
{
    public void SendMessage(string queue, string message);
    public void ReceiveMessage(string queue);
}

