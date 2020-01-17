  
using System.Collections.Generic;
using MediatR;
using Solution.Responses;

namespace Solution.Queries
{
    public class GetAllOrdersQuery : IRequest<List<OrderResponse>>
    {
        
    }
}