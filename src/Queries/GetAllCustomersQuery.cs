using System.Collections.Generic;
using MediatR;
using Solution.Responses;

namespace Solution.Queries
{
    public class GetAllCustomersQuery : IRequest<List<CustomerResponse>>
    {
        
    }
}