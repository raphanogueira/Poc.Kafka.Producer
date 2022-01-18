using Confluent.Kafka;
using KafkaExample.Domain.Contracts.Brokers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KafkaExample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IKafkaClient _kafkaClient;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IKafkaClient kafkaClient)
        {
            _logger = logger;
            _kafkaClient = kafkaClient;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var teste = await _kafkaClient.ProduceAsync("xubraiber", new Message<string, string>());

            return null;
        }
    }
}
