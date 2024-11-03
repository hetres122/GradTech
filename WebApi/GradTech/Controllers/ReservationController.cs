using GradTech.Abstraction.ReservationService.Models;
using GradTech.Service.ReservationService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GradTech.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController(IReservationService reservationService) : Controller
{
    private readonly IReservationService _reservationService = reservationService;

    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        var reservations = await _reservationService.GetReservations();

        return Ok(reservations);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddReservation(AddReservationRequestDto reservation)
    {
        var newReservation = await _reservationService.AddReservation(reservation);

        return Ok(newReservation);
    }
    
    [HttpPut]
    public async Task<IActionResult> EditReservation(EditReservationRequestDto reservation)
    {
        var editedReservation = await _reservationService.EditReservation(reservation);

        return Ok(editedReservation);
    }
    
    [HttpDelete("{reservationId}")]
    public async Task<IActionResult> DeleteReservation(long reservationId)
    {
        var deletedReservation = await _reservationService.DeleteReservation(reservationId);

        return Ok(deletedReservation);
    }
}