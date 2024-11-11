namespace GradTech.DAL.DbAll.Entities;

public class ReservationAdditionalOption
{
    public long ReservationId { get; set; }
    public long AdditionalOptionId { get; set; } 
    public virtual Reservation Reservation { get; set; }
    public virtual AdditionalOption AdditionalOption { get; set; }
}