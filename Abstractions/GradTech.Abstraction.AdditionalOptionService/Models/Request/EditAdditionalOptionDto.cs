namespace GradTech.Abstraction.AdditionalOptionService.Models.Request;

public class EditAdditionalOptionDto
{
    public long AdditionalOptionId { get; set; }
    public string OptionName { get; set; }
    public decimal Price { get; set; }
}