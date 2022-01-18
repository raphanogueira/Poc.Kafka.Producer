using Confluent.Kafka;
using System.Threading.Tasks;

namespace KafkaExample.Domain.Contracts.Brokers
{
    public interface IKafkaClient
    {
        Task<DeliveryResult<string, string>> ProduceAsync(string topicName, Message<string, string> message);
        Task<Message<string, string>> ConsumerAsync(string key, string val);
    }
}
