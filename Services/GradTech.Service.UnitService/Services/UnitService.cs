using GradTech.Abstraction.Unit.Models.Request;
using GradTech.Abstraction.Unit.Models.Response;
using GradTech.DAL.DbAll;
using GradTech.Service.Unit.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GradTech.Service.Unit.Services;

public class UnitService(DalContext dalContext) : IUnitService
{
    private readonly DalContext _dalContext = dalContext;

    public async Task<List<GetUnitResponseDto>> GetUnits()
    {
        var units = await _dalContext.Unit
            .Where(unit => unit.IsAvailable == true)
            .Select(unit => new GetUnitResponseDto
            {
                UnitId = unit.UnitId,
                Make = unit.Make,
                Model = unit.Model,
                Year = unit.Year,
                DailyRate = unit.DailyRate
            })
            .ToListAsync();

        return units;
    }
    
    public async Task<GetUnitResponseDto> GetUnit(long unitId)
    {
        var unit = await _dalContext.Unit
            .Where(unit => unit.UnitId == unitId)
            .Select(unit => new GetUnitResponseDto
            {
                UnitId = unit.UnitId,
                Make = unit.Make,
                Model = unit.Model,
                Year = unit.Year,
                DailyRate = unit.DailyRate
            })
            .FirstOrDefaultAsync();

        return unit;
    }

    public async Task<GetUnitResponseDto> AddUnit(AddUnitRequestDto unit)
    {
        var newUnit = new DAL.DbAll.Entities.Unit
        {
            Model = unit.Model,
            Make = unit.Make,
            Year = unit.Year,
            DailyRate = unit.DailyRate,
            IsAvailable = true
        };

        _dalContext.Unit.Add(newUnit);

        await _dalContext.SaveChangesAsync();

        return new GetUnitResponseDto
        {
            Model = newUnit.Model,
            Make = newUnit.Make,
            DailyRate = newUnit.DailyRate,
            Year = newUnit.Year,
            UnitId = newUnit.UnitId
        };
    }
    
    public async Task<GetUnitResponseDto> EditUnit(EditUnitRequestDto unit)
    {
        var unitToEdit = await _dalContext.Unit
            .Where(unitToEdit => unitToEdit.UnitId == unit.UnitId)
            .FirstOrDefaultAsync();

        if (unitToEdit == null)
        {
            throw new Exception("Unit not found");
        }

        unitToEdit.Model = unit.Model;
        unitToEdit.Make = unit.Make;
        unitToEdit.Year = unit.Year;
        unitToEdit.DailyRate = unit.DailyRate;
        
        await _dalContext.SaveChangesAsync();

        return new GetUnitResponseDto
        {
            Model = unitToEdit.Model,
            Make = unitToEdit.Make,
            DailyRate = unitToEdit.DailyRate,
            Year = unitToEdit.Year,
            UnitId = unitToEdit.UnitId
        };
    }
    
    public async Task<GetUnitResponseDto> DeleteUnit(long unitId)
    {
        var unitToDelete = await _dalContext.Unit
            .Where(unit => unit.UnitId == unitId)
            .FirstOrDefaultAsync();

        if (unitToDelete == null)
        {
            throw new Exception("Unit not found");
        }

        _dalContext.Unit.Remove(unitToDelete);

        await _dalContext.SaveChangesAsync();

        return new GetUnitResponseDto
        {
            Model = unitToDelete.Model,
            Make = unitToDelete.Make,
            DailyRate = unitToDelete.DailyRate,
            Year = unitToDelete.Year,
            UnitId = unitToDelete.UnitId
        };
    }
}