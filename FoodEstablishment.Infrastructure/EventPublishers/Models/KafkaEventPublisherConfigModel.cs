using Confluent.Kafka;
using System.Collections.Generic;

namespace FoodEstablishment.Infrastructure.EventPublishers.Models
{
    public class KafkaEventPublisherConfigModel
    {
        public ProducerConfig Config { get; set; }
        public Dictionary<string, string> TopicMapping { get; set;}
    }
}
