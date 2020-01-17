using System;
using MediatR;
using Solution.Responses;

namespace Solution.Queries
{
    public class GetCustomerOrdersQuery : IRequest<CustomerOrdersResponse>
    {
        public Guid CustomerId { get; }
        
        public GetCustomerOrdersQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}