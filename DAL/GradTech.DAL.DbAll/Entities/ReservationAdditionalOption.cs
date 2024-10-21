namespace GradTech.DAL.DbAll.Entities;

public class ReservationAdditionalOption
{
    public int ReservationId { get; set; }
    public int AdditionalOptionId { get; set; } 
    public virtual Reservation Reservation { get; set; }
    public virtual AdditionalOption AdditionalOption { get; set; }
}