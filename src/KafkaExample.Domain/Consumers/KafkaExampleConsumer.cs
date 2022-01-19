using KafkaExample.Domain.Clients;
using KafkaExample.Domain.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaExample.Domain.Consumers
{
    public sealed class KafkaExampleConsumer : KafkaConsumer, IHostedService
    {
        protected override string TopicName => "example.topic.xubraiber";


        public KafkaExampleConsumer(KafkaSettings kafkaSettings) : base(kafkaSettings)
        {
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Consumer();

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
