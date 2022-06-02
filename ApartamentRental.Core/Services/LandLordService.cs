using ApartamentRental.Core.DTO;
using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Exceptions;
using ApartamentRental.Infrastructure.Repository;

namespace ApartamentRental.Core.Services;

public class LandLordService : ILandLordService
{
    private readonly ILandLordService _landLordService;
    private readonly ILandlordRepository _landLordRepository;
    private readonly AddressRepository _addressRepository;
    private readonly AccountRepository _accountRepository;
    
    public LandLordService(ILandLordService landLordService, ILandlordRepository landLordRepository, AddressRepository addressRepository, AccountRepository accountRepository)
    {
        _landLordService = landLordService;
        _landLordRepository = landLordRepository;
        _addressRepository = addressRepository;
        _accountRepository = accountRepository;
    }

    public async Task CreateNewLandlordAccountAsync(LandLordCreationRequestDto dto)
    {
        var landLords = await _landLordRepository.GetAll();
        
        foreach (var landlord in landLords)
        {
            if (dto.Address == landlord.Account.Address)
            {
                throw new AddressAlreadyTakenException();
            }
        }
        await _accountRepository.Add(new Account()
            {
                FirstName = dto.Name,
                LastName = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.TelNumber,
                Address = dto.Address
                

            });
        
    }
}