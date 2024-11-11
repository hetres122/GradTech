using GradTech.Abstraction.ReservationService.Models;
using GradTech.Service.ReservationService.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradTech.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController(IReservationService reservationService, UserManager<IdentityUser> userManager) : Controller
{
    private readonly IReservationService _reservationService = reservationService;
    private readonly UserManager<IdentityUser> _userManager = userManager;


    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        var userId = _userManager.GetUserId(User);
        var reservations = await _reservationService.GetReservations(userId);

        return Ok(reservations);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddReservation(AddReservationRequestDto reservation)
    {
        var userId = _userManager.GetUserId(User);
        var newReservation = await _reservationService.AddReservation(reservation, userId);

        return Ok(newReservation);
    }
    
    [HttpPut]
    public async Task<IActionResult> EditReservation(EditReservationRequestDto reservation)
    {
        var userId = _userManager.GetUserId(User);
        var editedReservation = await _reservationService.EditReservation(reservation, userId);

        return Ok(editedReservation);
    }
    
    [HttpDelete("{reservationId}")]
    public async Task<IActionResult> DeleteReservation(long reservationId)
    {
        var deletedReservation = await _reservationService.DeleteReservation(reservationId);

        return Ok(deletedReservation);
    }
}