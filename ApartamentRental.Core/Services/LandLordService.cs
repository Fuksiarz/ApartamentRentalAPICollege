using ApartamentRental.Core.DTO;
using ApartamentRental.Infrastructure.Entities;
using ApartamentRental.Infrastructure.Exceptions;
using ApartamentRental.Infrastructure.Repository;

namespace ApartamentRental.Core.Services;

public class LandLordService : ILandLordService
{
    private readonly ILandlordRepository _landLordRepository;
    private readonly IAccountRepository _accountRepository;
    
    public LandLordService( ILandlordRepository landLordRepository, IAccountRepository accountRepository)
    {
        _landLordRepository = landLordRepository;
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
        var newAcc=  _accountRepository.Add(new Account()
            {
                FirstName = dto.Name,
                LastName = dto.Surname,
                Email = dto.Email,
                PhoneNumber = dto.TelNumber,
                Address = dto.Address
                
            });
        

    }
}