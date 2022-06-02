using ApartamentRental.Infrastructure.Entities;

namespace ApartamentRental.Core.DTO;

public class LandLordCreationRequestDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string TelNumber { get; set; }
    // public string Street{ get; set; }
    // public string? ApartmentNumber{ get; set; } 
    // public string? BuildingNumber{ get; set; } 
    // public string City{ get; set; } 
    // public string ZipCode{ get; set; } 
    // public string Country{ get; set; } 
    //
    public Address Address;
    
    
    public LandLordCreationRequestDto(string name, string surname, string email, string telNumber, Address address)
    {
        Name = name;
        Surname = surname;
        Email = email;
        TelNumber = telNumber;
        Address = address;
    }
}