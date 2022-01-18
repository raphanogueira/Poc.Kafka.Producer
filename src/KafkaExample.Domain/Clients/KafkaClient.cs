using Confluent.Kafka;
using KafkaExample.Domain.Configuration;
using KafkaExample.Domain.Contracts.Brokers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KafkaExample.Domain.Clients
{
    public sealed class KafkaClient : IKafkaClient
    {
        private readonly IProducer<string, string> _producer;
        private readonly KafkaSettings _kafkaSettings;

        public KafkaClient(KafkaSettings kafkaSettings)
        {
            _kafkaSettings = kafkaSettings;

            var config = new List<KeyValuePair<string, string>>();
            config.Add(KeyValuePair.Create("bootstrap.servers", _kafkaSettings.Host));

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public Task<Message<string, string>> ConsumerAsync(string key, string val)
        {
            throw new NotImplementedException();
        }

        public async Task<DeliveryResult<string, string>> ProduceAsync(string topicName, Message<string,string> message)
        {
            return await _producer.ProduceAsync($"{_kafkaSettings.TopicName}.{topicName}", message);
        }
    }
}
