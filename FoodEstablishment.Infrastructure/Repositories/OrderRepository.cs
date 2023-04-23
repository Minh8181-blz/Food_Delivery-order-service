using AutoMapper;
using Base.Utils;
using FoodEstablishment.Application.Repositories;
using FoodEstablishment.Domain.Entities;
using FoodEstablishment.Infrastructure.Daos.Interfaces;
using FoodEstablishment.Infrastructure.Database;
using FoodEstablishment.Infrastructure.Models.Orders;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FoodEstablishment.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<FoodEstablishmentDbContext, Order, long>, IOrderRepository
    {
        private readonly IOrderLogDao _orderLogDao;
        private readonly IMapper _mapper;

        public OrderRepository(
            FoodEstablishmentDbContext dbContext,
            IOrderLogDao orderLogDao,
            IMapper mapper) : base(dbContext)
        {
            _orderLogDao = orderLogDao;
            _mapper = mapper;
        }

        public override Order Add(Order entity)
        {
            base.Add(entity);
            AddOrderLog(entity);
            return entity;
        }

        public override async Task<Order> AddAsync(Order entity)
        {
            await base.AddAsync(entity);
            await AddOrderLogAsync(entity);
            return entity;
        }

        public override void Update(Order entity)
        {
            base.Update(entity);
            AddOrderLog(entity);
        }

        public async Task UpdateAsync(Order entity)
        {
            base.Update(entity);
            await AddOrderLogAsync(entity);
        }

        private void AddOrderLog(Order entity)
        {
            var orderLog = GenerateOrderLog(entity);
            _orderLogDao.Add(orderLog);
        }

        private async Task AddOrderLogAsync(Order entity)
        {
            var orderLog = GenerateOrderLog(entity);
            await _orderLogDao.AddAsync(orderLog);
        }

        private OrderLog GenerateOrderLog(Order order)
        {
            var orderWithExtraInfo = _mapper.Map<OrderWithExtraInfo>(order);
            var data = JsonConvert.SerializeObject(orderWithExtraInfo, NewtonJsonSerializerSettings.CAMEL);
            return new OrderLog
            {
                OrderId = order.Id,
                Data = data,
                CreatedAt = DateTime.UtcNow,
            };
        }
    }
}
