using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Solution.Mapping;
using Solution.Queries;
using Solution.Repositories;
using Solution.Responses;

namespace Solution.Handlers
{
    public class GetCustomerOrdersHandler : IRequestHandler<GetCustomerOrdersQuery, CustomerOrdersResponse>
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public GetCustomerOrdersHandler(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task<CustomerOrdersResponse> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _ordersRepository.GetOrdersAsync();
            var customerOrders = orders.Where(x => x.CustomerId == request.CustomerId).ToList();
            var customerOrdersResponse = new CustomerOrdersResponse
            {
                CustomerId = request.CustomerId,
                Orders = _mapper.MapOrderDtosToOrderResponses(customerOrders)
            };
            return customerOrdersResponse;
        }
    }
}