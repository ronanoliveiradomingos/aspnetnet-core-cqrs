using System;
using MediatR;
using Solution.Responses;

namespace Solution.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerResponse>
    {
        public Guid CustomerId { get; }
        
        public GetCustomerByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}