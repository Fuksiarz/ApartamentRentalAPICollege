using ApartamentRental.Core.DTO;

namespace ApartamentRental.Core.Services;

public interface IApartmentService
{
    Task<IEnumerable<ApartmentBasicInformationResponseDto>>
        GetAllApartmentsBasicInfosAsync();

    Task AddNewApartmentToExistingLandLordAsync(ApartmentBasicInformationResponseDto dto);
    Task<ApartmentBasicInformationResponseDto?> GetTheCheapestApartmentAsync();
    Task AddNewApartmentToExistingLandLordAsync(ApartmentCreationRequestDto dto);
}