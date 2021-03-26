namespace Microservice.MQ.Service.Domain.RabbitMQ
{
    public class RabbitMqConfiguration
    {
        public string Hostname { get; set; }

        public string QueueSendName { get; set; }

        public string QueueConsumeName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
