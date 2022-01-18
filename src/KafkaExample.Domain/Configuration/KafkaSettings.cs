namespace KafkaExample.Domain.Configuration
{
    public sealed class KafkaSettings : Settings
    {
        public string Host { get; set; }
        public string TopicName { get; set; }
    }
}
