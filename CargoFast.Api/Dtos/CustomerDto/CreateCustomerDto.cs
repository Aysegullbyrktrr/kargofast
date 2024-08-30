using CargoFast.Entity;

namespace CargoFast.Api.Dtos.CustomerDto;

public class CreateCustomerDto
{
    public string Name { get; set; } 
    public string LastName { get; set; }
    public int Communication { get; set; }
    public string Address { get; set; }
    public AddressEnum AddressEnum { get; set; }
}