namespace GradTech.DAL.DbAll.Entities;

public class Customer
{
    public long CustomerId { get; set; }
    public string UserId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}