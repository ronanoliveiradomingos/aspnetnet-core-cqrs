using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Solution.Mapping;
using Solution.Queries;
using Solution.Repositories;
using Solution.Responses;

namespace Solution.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomersRepository _customersRepository;
    
        public GetCustomerByIdHandler(IMapper mapper, ICustomersRepository customersRepository)
        {
            _mapper = mapper;
            _customersRepository = customersRepository;
        }
        
        public async Task<CustomerResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customerDto = await _customersRepository.GetCustomerAsync(request.CustomerId);
            return customerDto == null ? null : _mapper.MapCustomerDtoToCustomerResponse(customerDto);
        }
    }
}