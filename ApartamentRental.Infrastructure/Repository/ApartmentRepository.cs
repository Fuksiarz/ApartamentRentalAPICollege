using ApartamentRental.Infrastructure.Context;
using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ApartamentRental.Infrastructure.Repository;

public class ApartmentRepository : IApartmentRepository
{
    private readonly MainContext _mainContext;
    public ApartmentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Apartment>> GetAll()
    {
         var apartments = await _mainContext.Apartment.ToListAsync();

        foreach (var apartment in apartments)
        {
            await _mainContext.Entry(apartment).Reference(x => x.Address).LoadAsync();
            
        }

        return apartments;
    }

    public async Task<Apartment> GetById(int id)
    {
        var apartment = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == id);
        if (apartment == null) throw new EntityNotFoundException();
        {
            await _mainContext.Entry(apartment).Reference(x => x.Address).LoadAsync();
            return apartment;
        }

    }

    public async Task Add(Apartment entity)
    {

        entity.DateOfCreation=DateTime.UtcNow;
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task Update(Apartment entity)
    {
        var apartmentToUpdate = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == entity.Id);

        if (apartmentToUpdate == null)
        {
            throw new EntityNotFoundException();

        }

        apartmentToUpdate.Floor = entity.Floor;
        apartmentToUpdate.IsElevator = entity.IsElevator;
        apartmentToUpdate.RentAmount = entity.RentAmount;
        apartmentToUpdate.SquareMeters = entity.SquareMeters;
        apartmentToUpdate.NumberOfRooms = entity.NumberOfRooms;
        apartmentToUpdate.DateOfUpdate = DateTime.UtcNow;
        
        
        
        throw new NotImplementedException();
    }

    public async Task DeleteById(int id)
    {
        var apartmentToDelete = await _mainContext.Apartment.SingleOrDefaultAsync(x => x.Id == id);
        if (apartmentToDelete == null) throw new EntityNotFoundException();
        _mainContext.Apartment.Remove(apartmentToDelete);
        await _mainContext.SaveChangesAsync();
        
    }
}