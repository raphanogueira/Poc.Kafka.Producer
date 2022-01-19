using Confluent.Kafka;
using KafkaExample.Domain.Configuration;
using KafkaExample.Domain.Extensions;
using KafkaExample.Domain.Shareds;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace KafkaExample.Domain.Clients
{
    public abstract class KafkaProducer
    {
        private readonly IProducer<string, string> _producer;
        private readonly KafkaSettings _kafkaSettings;
        protected abstract string ContextName { get; }

        public KafkaProducer(KafkaSettings kafkaSettings)
        {
            _kafkaSettings = kafkaSettings;

            var config = new ProducerConfig
            {
                BootstrapServers = _kafkaSettings.Host
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        protected async Task<DeliveryResult<string, string>> ProduceAsync(string topicName, Message message)
        {
            var msg = CreateMessage(message);

            return await _producer.ProduceAsync($"{ContextName}.{topicName}", msg);
        }

        private Message<string, string> CreateMessage(Message message)
        {
            message.Key = nameof(message.Payload);
            message.Value = message.Payload.ToJson();

            return message;
        }

        public abstract Task<DeliveryResult<string, string>> HandleAsync(Message message);
    }
}
