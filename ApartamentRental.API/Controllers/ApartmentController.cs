using ApartamentRental.Core.DTO;
using ApartamentRental.Core.Services;
using ApartamentRental.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ApartamentRental.API.Controllers;

[Route("api/[controller]")]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentService _apartmentService;

    public ApartmentController(IApartmentService apartmentService)
    {

        _apartmentService = apartmentService;

    }
    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewApartment([FromBody] ApartmentBasicInformationResponseDto dto)
    {
        try
        {
            await _apartmentService.AddNewApartmentToExistingLandLordAsync(dto);

        }
        catch (EntityNotFoundException)
        {
            return BadRequest();
        }

        return NoContent();


    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _apartmentService.GetAllApartmentsBasicInfosAsync());
    }
    [HttpGet("GetTheCheapest")]
    public async Task<IActionResult> GetTheCheapestApartment()
    {
        var apartment =  await _apartmentService.GetTheCheapestApartmentAsync();

        return Ok(apartment);
    }



}