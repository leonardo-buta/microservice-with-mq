using System;

namespace Microservice.MQ.Service.Domain.Models
{
    public class Message
    {
        public string Identifier { get; set; }
        public string MessageContent { get; set; }
        public long Timestamp { get; set; }
        public Guid CorrelationId { get; set; }        
    }
}
