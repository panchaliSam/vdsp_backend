using Microsoft.AspNetCore.Mvc;
using Server.Application.DTOs;
using Server.Application.Interfaces;

namespace Server.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await customerService.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var customer = await customerService.GetCustomerByIdAsync(id);
        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
    {
        await customerService.CreateCustomerAsync(customerDto);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customerDto.Email }, new { message = "Created successfully" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
    {
        await customerService.UpdateCustomerAsync(id, customerDto);
        return Ok(new { message = "Updated successfully" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        await customerService.DeleteCustomerAsync(id);
        return Ok(new { message = "Deleted successfully" });
    }
}