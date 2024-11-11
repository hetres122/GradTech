using GradTech.Abstraction.AdditionalOptionService.Models.Request;
using GradTech.Service.AdditionalOption.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradTech.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class AdditionalOption(IAdditionalOptionService additionalOption) : Controller
{
    private readonly IAdditionalOptionService _additionalOption = additionalOption;

    [HttpGet]
    public async Task<IActionResult> GetAdditionalOptions()
    {
        var additionalOptions = await _additionalOption.GetAdditionalOptions();

        return Ok(additionalOptions);
    }
    
    [HttpGet("{additionalOptionId}")]
    public async Task<IActionResult> GetAdditionalOption(long additionalOptionId)
    {
        var additionalOption = await _additionalOption.GetAdditionalOption(additionalOptionId);

        return Ok(additionalOption);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAdditionalOption(AddAdditionalOptionDto additionalOption)
    {
        var newAdditionalOption = await _additionalOption.AddAdditionalOption(additionalOption);

        return Ok(newAdditionalOption);
    }
    
    [HttpPut]
    public async Task<IActionResult> EditAdditionalOption(EditAdditionalOptionDto additionalOption)
    {
        var editedAdditionalOption = await _additionalOption.EditAdditionalOption(additionalOption);

        return Ok(editedAdditionalOption);
    }
    
    [HttpDelete("{additionalOptionId}")]
    public async Task<IActionResult> DeleteAdditionalOption(long additionalOptionId)
    {
        var deletedAdditionalOption = await _additionalOption.DeleteAdditionalOption(additionalOptionId);

        return Ok(deletedAdditionalOption);
    }
    
    [HttpPost("{additionalOptionId}/{reservationId}")]
    public async Task<IActionResult> AddAdditionalOptionToReservation(long additionalOptionId, long reservationId)
    {
        var newAdditionalOption = await _additionalOption.AddAdditionalOptionToReservation(additionalOptionId, reservationId);

        return Ok(newAdditionalOption);
    }
    
    [HttpDelete("{additionalOptionId}/{reservationId}")]
    public async Task<IActionResult> RemoveAdditionalOptionFromReservation(long additionalOptionId, long reservationId)
    {
        var removedAdditionalOption = await _additionalOption.RemoveAdditionalOptionFromReservation(additionalOptionId, reservationId);

        return Ok(removedAdditionalOption);
    }
    
    [HttpGet("/reservation/{reservationId}")]
    public async Task<IActionResult> GetAdditionalOptionsForReservation(long reservationId)
    {
        var additionalOptions = await _additionalOption.GetAdditionalOptionsForReservation(reservationId);

        return Ok(additionalOptions);
    }
}