using AutoMapper;
using OrderManagement.Application.Common.Exceptions;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;
using OrderManagement.SharedKernel.Pagination;

namespace OrderManagement.Application.Services
{
    public class CustomerService(ICustomerRepository repository, IMapper mapper) : ICustomerService
    {
        public async Task<Customer> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = mapper.Map<Customer>(dto);

            return await  repository.AddAsync(customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await repository.GetByIdAsync(customerId);

            if (customer == null) throw new NotFoundException("Not found");

            await repository.DeleteAsync(customer);
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int customerId)
        {
            var customer = await repository.GetByIdAsync(customerId);

            if (customer == null) throw new NotFoundException("Not found");

            return mapper.Map<CustomerDto>(customer);
        }

        public async Task<PagedResult<CustomerDto>> GetCustomersAsync(int pageIndex, int pageSize)
        {
            var result = await repository.GetAllAsync(pageIndex, pageSize);
            var customerDtos = mapper.Map<List<CustomerDto>>(result.Items);

            return new PagedResult<CustomerDto>
            {
                Items = customerDtos,
                TotalItems = result.TotalItems,
                PageIndex = result.PageIndex,
                PageSize = result.PageSize
            };
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto dto, int customerId)
        {
            var customer = await repository.GetByIdAsync(customerId);

            if (customer == null) throw new NotFoundException("Not found");

            customer.FullName = dto.FullName;
            customer.Email = dto.Email;
            customer.PhoneNumber = dto.PhoneNumber;

            await repository.UpdateAsync(customer);
        }
    }
}
