using ApartamentRental.Infrastructure.Entities;

namespace ApartamentRental.Infrastructure.Repository;

public interface IAddressRepository :IRepository<Address>
{
    Task<int> GetAddressIdByItsAttributesAsync(string country, string city, string zipCode, string street,
        string buildingNumber, string apartmentNumber);

    public Task<Address> CreateAndGetAsync(Address address);
}
