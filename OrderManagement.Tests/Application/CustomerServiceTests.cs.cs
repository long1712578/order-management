using AutoMapper;
using Moq;
using OrderManagement.Application.Common.Exceptions;
using OrderManagement.Application.DTOs;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

public class CustomerServiceTests
{
    private readonly CustomerService _service;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<ICustomerRepository> _mockRepo;

    public CustomerServiceTests()
    {
        _mockMapper = new Mock<IMapper>();
        _mockRepo = new Mock<ICustomerRepository>();

        _service = new CustomerService(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task CreateCustomerAsync_ShouldReturnCustomer()
    {
        // Arrange
        var dto = new CreateCustomerDto { FullName = "Long", Email = "long@gmail.com", PhoneNumber = "0987564123" };
        var customer = new Customer { FullName = dto.FullName, Email = dto.Email, PhoneNumber = dto.PhoneNumber };

        _mockMapper.Setup(m => m.Map<Customer>(dto)).Returns(customer);
        _mockRepo.Setup(r => r.AddAsync(customer)).ReturnsAsync(customer);

        // Act
        var result = await _service.CreateCustomerAsync(dto);

        // Assert
        Assert.Equal(customer.FullName, result.FullName);
        Assert.Equal(customer.Email, result.Email);
        Assert.Equal(customer.PhoneNumber, result.PhoneNumber);
    }

    [Fact]
    public async Task CreateCustomerAsync_ShouldThrowException_WhenMappingReturnsNull()
    {
        // Arrange
        var dto = new CreateCustomerDto { FullName = "Test", Email = "testemail.com", PhoneNumber = "0987564123" };

        _mockMapper.Setup(m => m.Map<Customer>(dto)).Returns((Customer?)null);

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _service.CreateCustomerAsync(dto));
    }


    [Fact]
    public async Task DeleteCustomerAsync_ShouldThrowNotFoundException_IfCustomerDoesNotExist()
    {
        // Arrange
        int customerId = 999; // giả sử không tồn tại
        _mockRepo.Setup(r => r.GetByIdAsync(customerId))
                 .ReturnsAsync((Customer?)null);

        // Act + Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _service.DeleteCustomerAsync(customerId));
    }


}