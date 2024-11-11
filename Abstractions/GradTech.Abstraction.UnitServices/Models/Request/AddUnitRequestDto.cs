namespace GradTech.Abstraction.Unit.Models.Request;

public class AddUnitRequestDto
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public decimal DailyRate { get; set; }
}