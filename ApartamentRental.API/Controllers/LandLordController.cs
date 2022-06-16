using ApartamentRental.Core.DTO;
using ApartamentRental.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApartamentRental.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LandLordController : ControllerBase
{
    private readonly ILandLordService _landLordService;

    public LandLordController(ILandLordService landLcordService)
    {
        _landLordService = landLcordService;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateNewLandlordAccount([FromBody] LandLordCreationRequestDto dto)
    { 
        await _landLordService.CreateNewLandlordAccountAsync(dto);
        return NoContent();
    }
}