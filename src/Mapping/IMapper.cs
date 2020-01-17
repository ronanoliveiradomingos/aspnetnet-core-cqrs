using System.Collections.Generic;
using Solution.Dtos;
using Solution.Responses;

namespace Solution.Mapping
{
    public interface IMapper
    {
        List<CustomerResponse> MapCustomerDtosToCustomerResponses(List<CustomerDto> dtos);
        
        CustomerResponse MapCustomerDtoToCustomerResponse(CustomerDto customerDto);

        List<OrderResponse> MapOrderDtosToOrderResponses(List<OrderDto> customerOrders);
        
        OrderResponse MapOrderDtoToOrderResponse(OrderDto order);
    }
}