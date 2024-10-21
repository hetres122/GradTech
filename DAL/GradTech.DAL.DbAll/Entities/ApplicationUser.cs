using Microsoft.AspNetCore.Identity;

namespace GradTech.DAL.DbAll.Entities;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Customer> Customers { get; set; }
}