namespace GradTech.Abstraction.Unit.Models.Request;

public class EditUnitRequestDto
{
    public long UnitId { get; set; }
    
    public string Make { get; set; }
    
    public string Model { get; set; }
    
    public string Year { get; set; }
    
    public decimal DailyRate { get; set; }
    
    public bool IsAvailable { get; set; }
}