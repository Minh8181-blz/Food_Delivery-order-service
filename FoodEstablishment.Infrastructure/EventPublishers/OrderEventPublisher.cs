using AutoMapper;
using Base.Utils;
using Confluent.Kafka;
using FoodEstablishment.Application.EventPublishers;
using FoodEstablishment.Domain.Entities;
using FoodEstablishment.Infrastructure.EventPublishers.Models;
using FoodEstablishment.Infrastructure.Models.Orders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FoodEstablishment.Infrastructure.EventPublishers
{
    public class OrderEventPublisher : IOrderEventPublisher
    {
        private readonly IProducer<string, string> _producer;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderEventPublisher> _logger;

        private readonly string _topic;

        public OrderEventPublisher(
            KafkaEventPublisherConfigModel configModel,
            IMapper mapper,
            ILogger<OrderEventPublisher> logger)
        {
            _producer = new ProducerBuilder<string, string>(configModel.Config).Build();
            _topic = configModel.TopicMapping["Order"];
            _mapper = mapper;
            _logger = logger;
        }

        public async Task PublishAsync(Order order)
        {
            try
            {
                var orderModel = _mapper.Map<OrderWithExtraInfo>(order);
                await _producer.ProduceAsync(_topic, new Message<string, string>
                {
                    Key = orderModel.Id.ToString(),
                    Value = JsonConvert.SerializeObject(orderModel, NewtonJsonSerializerSettings.CAMEL),
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
            }
        }
    }
}
