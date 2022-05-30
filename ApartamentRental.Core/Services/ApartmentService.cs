using System.Collections;
using ApartamentRental.Core.DTO;
using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Repository;

namespace ApartamentRental.Core.Services;

public class ApartmentService : IApartmentService
{
    private readonly IApartmentRepository _apartmentRepository;

    public ApartmentService(IApartmentRepository apartmentRepository)
    {
        _apartmentRepository = apartmentRepository;
    }

    public async Task<IEnumerable<ApartmentBasicInformationResponseDto>> GetAllApartmentsBasicInfosAsync()
    {
        var apartments = await _apartmentRepository.GetAll();
        return apartments.Select(x => new ApartmentBasicInformationResponseDto(
            x.RentAmount,
            x.NumberOfRooms,
            x.SquareMeters,
            x.IsElevator,
            x.Address.City,
            x.Address.Street
        ));
    }

    public Task AddNewApartmentToExistingLandLordAsync(ApartmentBasicInformationResponseDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<ApartmentBasicInformationResponseDto?> GetTheCheapestApartmentAsync()
    {
        var apartments = await _apartmentRepository.GetAll();
        var cheapestOne = apartments.MinBy(x => x.RentAmount);
        if (cheapestOne is null) return null;
        return new ApartmentBasicInformationResponseDto(
            cheapestOne.RentAmount,
            cheapestOne.NumberOfRooms,
            cheapestOne.SquareMeters,
            cheapestOne.IsElevator,
            cheapestOne.Address.City,
            cheapestOne.Address.Street);

    }
    
    
}