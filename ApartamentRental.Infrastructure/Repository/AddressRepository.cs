using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;

namespace ApartamentRental.Infrastructure.Repository;

public class AddressRepository : IAddressRepository
{
    private readonly MainContext _mainContext;
    public AddressRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    public Task<IEnumerable<Address>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Address> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Address entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Address entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}