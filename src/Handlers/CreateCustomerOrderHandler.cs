using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Solution.Commands;
using Solution.Mapping;
using Solution.Repositories;
using Solution.Responses;

namespace Solution.Handlers
{
    public class CreateCustomerOrderHandler : IRequestHandler<CreateCustomerOrderCommand, OrderResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerOrderHandler> _logger;

        public CreateCustomerOrderHandler(ILogger<CreateCustomerOrderHandler> logger, IOrdersRepository ordersRepository, IMapper mapper)
        {
            _logger = logger;
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(CreateCustomerOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _ordersRepository.CreateOrderAsync(request.CustomerId, request.ProductId);
            _logger.LogInformation($"Created order for customer: {order.CustomerId} for product: {order.ProductId}");
            return _mapper.MapOrderDtoToOrderResponse(order);
        }
    }
}