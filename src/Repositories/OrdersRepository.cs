using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solution.Dtos;

namespace Solution.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly List<OrderDto> _orders = new List<OrderDto>
        {
            new OrderDto
            {
                Id = Guid.Parse("0bb7daa5-7f27-4b5f-95df-3d8b3b86d7ed"),
                DeliveryDate = DateTime.UtcNow,
                ProductId = Guid.Parse("9f8dd03e-1298-4070-adc0-c21bbd5e179f"),
                CustomerId = Guid.Parse("64fa643f-2d35-46e7-b3f8-31fa673d719b"),
                Delivered = false
            },
            new OrderDto
            {
                Id = Guid.Parse("422c4c71-cd23-4015-ae7b-3f577f10a279"),
                DeliveryDate = DateTime.UtcNow,
                ProductId = Guid.Parse("dd45ed60-52c8-47c4-a27f-1d1823f3eec1"),
                CustomerId = Guid.Parse("a46ac8f4-2ecd-43bf-a9e6-e557b9af1d6e"),
                Delivered = false
            }
        };

        public Task<List<OrderDto>> GetOrdersAsync()
        {
            return Task.FromResult(_orders);
        }

        public Task<OrderDto> CreateOrderAsync(Guid customerId, Guid productId)
        {
            var order = new OrderDto
            {
                Id = Guid.NewGuid(),
                Delivered = false,
                DeliveryDate = DateTime.UtcNow,
                CustomerId = customerId,
                ProductId = productId
            };
            _orders.Add(order);
            return Task.FromResult(order);
        }

        public Task<OrderDto> GetOrderAsync(Guid orderId)
        {
            return Task.FromResult(_orders.SingleOrDefault(x => x.Id == orderId));
        }
    }
}