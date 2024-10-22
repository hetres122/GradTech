namespace GradTech.DAL.DbAll.Entities;

public class AdditionalOption
{
    public long AdditionalOptionId { get; set; }
    public string OptionName { get; set; }
    public decimal Price { get; set; }
    public virtual ICollection<ReservationAdditionalOption> ReservationAdditionalOptions { get; set; }
}