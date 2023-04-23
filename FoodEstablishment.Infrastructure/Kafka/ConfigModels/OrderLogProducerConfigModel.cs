using Confluent.Kafka;

namespace FoodEstablishment.Infrastructure.Kafka.ConfigModels
{
    public class OrderLogProducerConfigModel
    {
        public ProducerConfig Config { get; set; }
        public string Topic { get; set; }

        public OrderLogProducerConfigModel(ProducerConfig config)
        {
            Config = config;
        }
    }
}
