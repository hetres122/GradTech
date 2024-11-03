using GradTech.Abstraction.Unit.Models.Request;
using GradTech.Abstraction.Unit.Models.Response;

namespace GradTech.Service.Unit.Interfaces;

public interface IUnitService
{
    public Task<List<GetUnitResponseDto>> GetUnits();
    
    public Task<GetUnitResponseDto> GetUnit(long unitId);
    
    public Task<GetUnitResponseDto> AddUnit(AddUnitRequestDto unit);
    
    public Task<GetUnitResponseDto> EditUnit(EditUnitRequestDto unit);
    
    public Task<GetUnitResponseDto> DeleteUnit(long unitId);
}