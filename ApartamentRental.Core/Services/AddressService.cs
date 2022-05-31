using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Repository;


namespace ApartamentRental.Core.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _adressRepository;


    public AddressService(IAddressRepository adressRepository)
    {
        _adressRepository = adressRepository;
    }


    public async Task<int> GetAddressIdOrCreateAsync(string country, string city, string zipCode, string street, string buildingNumber,
        string apartmentNUmber)
    {
        var id = await _adressRepository.GetAddressIdByItsAttributesAsync(country, city, zipCode, street,
            buildingNumber, apartmentNUmber);

        if (id != 0)
        {
            return id;
        }

        var address = await _adressRepository.CreateAndGetAsync(new Address
        {
            Country = country,
            City = city,
            ZipCode = zipCode,
            Street = street,
            BuildingNumber = buildingNumber,
            AparmentNumber = apartmentNUmber

        }); 
        return address.Id;
    }
    
}