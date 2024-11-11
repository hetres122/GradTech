namespace GradTech.Abstraction.AdditionalOptionService.Models.Response;

public class GetAdditionalOptionDto
{
    public long AdditionalOptionId { get; set; }
    public string OptionName { get; set; }
    public decimal Price { get; set; }
}