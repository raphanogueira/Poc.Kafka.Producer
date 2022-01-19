using System;

namespace KafkaExample.Domain.Entities
{
    public sealed class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
