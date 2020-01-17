using System;
using MediatR;
using Solution.Responses;

namespace Solution.Queries
{
    public class GetOrderByIdQuery : IRequest<OrderResponse>
    {
        public Guid OrderId { get; }
        
        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}