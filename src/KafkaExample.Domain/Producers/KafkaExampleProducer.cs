using Confluent.Kafka;
using KafkaExample.Domain.Clients;
using KafkaExample.Domain.Configuration;
using KafkaExample.Domain.Shareds;
using System;
using System.Threading.Tasks;

namespace KafkaExample.Domain.Producers
{
    public sealed class KafkaExampleProducer : KafkaProducer
    {
        protected override string ContextName => "example.topic";
 
        public KafkaExampleProducer(KafkaSettings kafkaSettings) : base(kafkaSettings)
        {
        }


        public async override Task<DeliveryResult<string, string>> HandleAsync(Message message)
        {
            return await ProduceAsync("xubraiber", message);
        }
    }
}
