using CargoFast.Entity;

namespace CargoFast.Api.Dtos.ShippingDto;

public class CreateShippingDto
{
    public string Shipping { get; set; }   
   
    public string SenderId { get; set; }
    
    public string ReceiverId { get; set; }

    public int PackageCount { get; set; }
    public int PackageWeight { get; set; }
    public ShippingEnum ShippingEnum { get; set; }
}