using System;

namespace KafkaExample.Domain.Shareds
{
    public sealed class Message : Confluent.Kafka.Message<string, string>
    {
        public Message(object payload)
        {
            Payload = payload;
            Date = DateTime.Now;
        }

        public object Payload { get; set; }
        public DateTime Date { get; set; }
    }
}
