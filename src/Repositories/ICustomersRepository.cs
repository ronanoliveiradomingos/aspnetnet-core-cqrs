using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Solution.Dtos;

namespace Solution.Repositories
{
    public interface ICustomersRepository
    {
        Task<CustomerDto> GetCustomerAsync(Guid customerId);
        
        Task<List<CustomerDto>> GetCustomersAsync();
    }
}