namespace GradTech.Abstraction.Unit.Models.Response;

public class GetUnitResponseDto
{
    public long UnitId { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public decimal DailyRate { get; set; }
}