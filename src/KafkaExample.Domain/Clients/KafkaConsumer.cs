using Confluent.Kafka;
using KafkaExample.Domain.Configuration;
using KafkaExample.Domain.Entities;
using KafkaExample.Domain.Extensions;
using System.Threading;

namespace KafkaExample.Domain.Clients
{
    public abstract class KafkaConsumer
    {
        private readonly IConsumer<Ignore, string> _consumer;
        private readonly KafkaSettings _kafkaSettings;
        protected abstract string TopicName { get; }

        public KafkaConsumer(KafkaSettings kafkaSettings)
        {
            _kafkaSettings = kafkaSettings;

            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaSettings.Host,
                GroupId = TopicName,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoOffsetStore = false
            };

            _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        }

        public void Consumer()
        {
            _consumer.Subscribe($"{TopicName}");

            while (true)
            {
                var consumeResult = _consumer.Consume(CancellationToken.None);

                if (consumeResult is null)
                    break;

                var account = consumeResult.Message.Value.Parse<Account>();

                _consumer.StoreOffset(consumeResult);
            }

            _consumer.Close();
        }
    }
}
