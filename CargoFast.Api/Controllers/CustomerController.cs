using CargoFast.Api.Dtos.CustomerDto;
using CargoFast.Bussines.Abstract;
using CargoFast.Entity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Serializers;

namespace CargoFast.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CustomerController: ControllerBase
{
   private readonly ICustomerService _customerService;

   public CustomerController(ICustomerService customerService)
   {
      _customerService = customerService;
   }

   [HttpGet]
   public async Task<IActionResult> GetCustomer()
   {
      var values = await _customerService.TGetListAsync();
      return Ok(values);
   }
   [HttpGet("/getId")]
   public async Task<IActionResult> GetCustomersIds()
   {
      var values = await _customerService.TGetListAsync();
      var ids = values.Select(v => v.Id); 
      return Ok(ids); 
   }
   
   [HttpGet("{id}")]
   public async Task<IActionResult> GetCustomerById(string id)
   {
      var value = await _customerService.TGetByIdAsync(id); 
      return Ok(value);
   }
   
   [HttpPost]
   public async Task<IActionResult> CreateCustomer(CreateCustomerDto customerDto)
   {
      try
      {
         var customer = new Customer
         {
            Id= "60adf897b6f89b6d6c8b4568",
            Name = customerDto.Name,
            LastName = customerDto.LastName,
            Address = customerDto.Address,
            AddressEnum= customerDto.AddressEnum
                    
         };

         await _customerService.TCreateAsync(customer);
         return Ok(customerDto);
      }
      catch (Exception ex)
      {
         
         return StatusCode(500, "An error occurred while creating the customer: " + ex.Message);
      }
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> DeleteCustomer(string id)
   {
      try {
         await _customerService.TDeleteAsync(id);
         return Ok("Member deleted successfully.");
                         
      }catch (Exception ex) {
        
         return StatusCode(500, "An error occurred while deleting the customer: " + ex.Message);
      }
   }
   
}