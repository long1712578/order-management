using AutoMapper;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Application.Services
{
    public class CustomerService(ICustomerRepository repository, IMapper mapper) : ICustomerService
    {
        public async Task<Customer> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = mapper.Map<Customer>(dto);

            return await  repository.AddAsync(customer);
        }

        public async Task<List<CustomerDto>> GetAllAsync(int pageIndex, int pageSize)
        {
            var customers = await repository.GetAllAsync(pageIndex, pageSize);
            return mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
