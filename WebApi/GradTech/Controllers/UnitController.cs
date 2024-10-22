using GradTech.Abstraction.Unit.Models.Request;
using GradTech.Abstraction.Unit.Models.Response;
using GradTech.Service.Unit.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GradTech.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnitController(IUnitService unitService) : Controller
{
    private readonly IUnitService _unitService = unitService;

    [HttpGet]
    public Task<List<GetUnitResponseDto>> GetAllUnit()
    {
        return this._unitService.GetUnit();
    }

    [HttpPost]
    public Task<GetUnitResponseDto> AddUnit(AddUnitRequestDto unit)
    {
        return this._unitService.AddUnit(unit);
    }
    
    [HttpPut]
    public Task<GetUnitResponseDto> EditUnit(EditUnitRequestDto unit)
    {
        return this._unitService.EditUnit(unit);
    }
    
    [HttpDelete]
    public Task<GetUnitResponseDto> DeleteUnit(long unitId)
    {
        return this._unitService.DeleteUnit(unitId);
    }
}