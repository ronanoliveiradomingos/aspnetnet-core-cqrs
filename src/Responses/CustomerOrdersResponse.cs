using System;
using System.Collections.Generic;

namespace Solution.Responses
{
    public class CustomerOrdersResponse
    {
        public Guid CustomerId { get; set; }
        
        public List<OrderResponse> Orders { get; set; }
    }
}