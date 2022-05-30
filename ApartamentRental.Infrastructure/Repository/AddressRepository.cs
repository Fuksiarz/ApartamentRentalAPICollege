using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApartamentRental.Infrastructure.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly MainContext _mainContext;
    public AddressRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    public async Task<IEnumerable<Address>> GetAll()
    {
        var addresses = await _mainContext.Address.ToListAsync();
        foreach (var address in addresses)
        {
            await _mainContext.Entry(address).Reference(x => x.AparmentNumber).LoadAsync();
        }

        return addresses;
    }

    public async Task<Address> GetById(int id)
    {
        var address = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == id);
        if (address == null) throw new EntityNotFoundException();
        {
            await _mainContext.Entry(address).Reference(x => x.AparmentNumber).LoadAsync();
            return address;
        }

    }

    public async Task Add(Address entity)
    {
        entity.DateOfCreation=DateTime.Now;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task Update(Address entity)
    {
        var addressToUpdate = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == entity.Id);

        if (addressToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        addressToUpdate.City = entity.City;
        addressToUpdate.Country = entity.Country;
        addressToUpdate.Id = entity.Id;
        addressToUpdate.Street = entity.Street;
        addressToUpdate.AparmentNumber = entity.AparmentNumber;
        addressToUpdate.BuildingNumber = entity.BuildingNumber;
        addressToUpdate.ZipCode = entity.ZipCode;
        addressToUpdate.DateOfUpdate=DateTime.UtcNow;


    }

    public async Task DeleteById(int id)
    {
        var addressToDelete = await _mainContext.Address.SingleOrDefaultAsync(x => x.Id == id);
        if (addressToDelete == null) throw new EntityNotFoundException();
        _mainContext.Address.Remove(addressToDelete);
        await _mainContext.SaveChangesAsync();

        throw new EntityNotFoundException();
    }

    public async Task<int> GetAddressIdByItsAttributesAsync(string country, string city, string zipCode, string street, string buildingNumber,
        string apartmentNumber)
    {
        var address = await _mainContext.Address.FirstOrDefaultAsync(x =>
            x.Country == country && x.City == city && x.ZipCode == zipCode &&
                x.Street == street && x.BuildingNumber == buildingNumber && x.AparmentNumber == apartmentNumber);
        return address?.Id ?? 0;

    }

    public async Task<Address> CreateAndGetAsync(Address address)
    {
        address.DateOfCreation=DateTime.UtcNow;
        address.DateOfUpdate= DateTime.UtcNow;
        await _mainContext.AddAsync(address);
        await _mainContext.SaveChangesAsync();
        return address;
    }
    
}