using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Messenger;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Messenger;

public class MessengerService : IMessengerService
{
    public void ReceiveMessage(string queue)
    {
        throw new NotImplementedException();
    }

    public void SendMessage(string queue, string message)
    {
        throw new NotImplementedException();
    }
}
