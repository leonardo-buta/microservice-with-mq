using Microservice.MQ.Service.Domain.Models;

namespace Microservice.MQ.Service.Domain.Interfaces
{
    public interface IMessagePublishService
    {
        Message SendMessage(string identifier, string messageContent);
    }
}
