using Confluent.Kafka;
using KafkaExample.Domain.Configuration;
using KafkaExample.Domain.Entities;
using KafkaExample.Domain.Producers;
using KafkaExample.Domain.Shareds;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace KafkaExample.Api.Controllers
{

    [ApiController]
    [Route("kafka-example")]
    [Produces(MediaTypeNames.Application.Json)]
    public class WeatherForecastController : ControllerBase
    {
        private readonly KafkaExampleProducer _kafkaExampleProducer;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, KafkaSettings kafkaSettings)
        {
            _logger = logger;
            _kafkaExampleProducer = new KafkaExampleProducer(kafkaSettings);
        }

        [HttpPost("producer")]
        public async Task<DeliveryResult<string, string>> PostAsync(Account account)
        {
            var message = new Message(account);

            var teste = await _kafkaExampleProducer.HandleAsync(message);

            return teste;
        }
    }
}
