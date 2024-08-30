using CargoFast.Api.Dtos.ShippingDto;
using CargoFast.Bussines.Abstract;
using CargoFast.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CargoFast.Api.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController: ControllerBase
    {
     private readonly IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetShipping()
        {
            var values = await _shippingService.TGetListAsync();
            return Ok(values); 
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShippingById(string id)
        {
            var values = await _shippingService.TGetByIdAsync(id);
            return Ok(values); 
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateShipping(CreateShippingDto shippingDto)
        {
      
            try
            {
                var shipping = new ShippingCode()
                {
                    Id = Guid.NewGuid().ToString(),
                    SenderId = shippingDto.SenderId,
                    ReceiverId = shippingDto.ReceiverId,
                    PackageCount = shippingDto.PackageCount,
                    PackageWeight = shippingDto.PackageWeight,
                    ShippingEnum = shippingDto.ShippingEnum
                    
                };
                await _shippingService.TCreateAsync(shipping);
                return Ok(shipping);
            }
            catch (Exception ex)
            {
                // Hata durumunda, InternalServerError (500) döndürüyoruz
                return StatusCode(500, "An error occurred while creating the shipping: " + ex.Message);
            }
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping(string id)
        {
            try {
                await _shippingService.TDeleteAsync(id);
                return Ok("Shipping deleted successfully.");
                         
            }catch (Exception ex) {
                // Hata durumunda, InternalServerError (500) döndürüyoruz
                return StatusCode(500, "An error occurred while deleting the shipping: " + ex.Message);
            }
        }
    
    }