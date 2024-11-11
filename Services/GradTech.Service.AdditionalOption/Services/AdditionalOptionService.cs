using GradTech.Abstraction.AdditionalOptionService.Models.Request;
using GradTech.Abstraction.AdditionalOptionService.Models.Response;
using GradTech.DAL.DbAll;
using GradTech.Service.AdditionalOption.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GradTech.Service.AdditionalOption.Services;

public class AdditionalOptionService(DalContext dalContext): IAdditionalOptionService
{
    private readonly DalContext _dalContext = dalContext;
    
    public async Task<List<GetAdditionalOptionDto>> GetAdditionalOptions()
    {
       var additionalOptions = await _dalContext.AdditionalOptions
            .Select(additionalOption => new GetAdditionalOptionDto
            {
                AdditionalOptionId = additionalOption.AdditionalOptionId,
                OptionName = additionalOption.OptionName,
                Price = additionalOption.Price
            })
            .ToListAsync();
        
        return additionalOptions;
    }

    public Task<GetAdditionalOptionDto> GetAdditionalOption(long additionalOptionId)
    {
        var additionalOption = _dalContext.AdditionalOptions
            .Where(additionalOption => additionalOption.AdditionalOptionId == additionalOptionId)
            .Select(additionalOption => new GetAdditionalOptionDto
            {
                AdditionalOptionId = additionalOption.AdditionalOptionId,
                OptionName = additionalOption.OptionName,
                Price = additionalOption.Price
            })
            .FirstOrDefaultAsync();
        
        return additionalOption;
    }
    
    public async Task<GetAdditionalOptionDto> AddAdditionalOption(AddAdditionalOptionDto additionalOption)
    {
        var newAdditionalOption = new DAL.DbAll.Entities.AdditionalOption
        {
            OptionName = additionalOption.OptionName,
            Price = additionalOption.Price
        };
        
        _dalContext.AdditionalOptions.Add(newAdditionalOption);
        
        await _dalContext.SaveChangesAsync();
        
        return new GetAdditionalOptionDto
        {
            AdditionalOptionId = newAdditionalOption.AdditionalOptionId,
            OptionName = newAdditionalOption.OptionName,
            Price = newAdditionalOption.Price
        };
    }

    public async Task<GetAdditionalOptionDto> EditAdditionalOption(EditAdditionalOptionDto additionalOption)
    {
        var additionalOptionToEdit = await _dalContext.AdditionalOptions
            .Where(additionalOption => additionalOption.AdditionalOptionId == additionalOption.AdditionalOptionId)
            .FirstOrDefaultAsync();
        
        additionalOptionToEdit.OptionName = additionalOption.OptionName;
        additionalOptionToEdit.Price = additionalOption.Price;
        
        await _dalContext.SaveChangesAsync();
        
        return new GetAdditionalOptionDto
        {
            AdditionalOptionId = additionalOptionToEdit.AdditionalOptionId,
            OptionName = additionalOptionToEdit.OptionName,
            Price = additionalOptionToEdit.Price
        };
    }

    public async Task<GetAdditionalOptionDto> DeleteAdditionalOption(long additionalOptionId)
    {
        var additionalOptionToDelete = await _dalContext.AdditionalOptions
            .Where(additionalOption => additionalOption.AdditionalOptionId == additionalOptionId)
            .FirstOrDefaultAsync();
        
        _dalContext.AdditionalOptions.Remove(additionalOptionToDelete);
        
        await _dalContext.SaveChangesAsync();
        
        return new GetAdditionalOptionDto
        {
            AdditionalOptionId = additionalOptionToDelete.AdditionalOptionId,
            OptionName = additionalOptionToDelete.OptionName,
            Price = additionalOptionToDelete.Price
        };
    }

    public async Task<GetAdditionalOptionDto> AddAdditionalOptionToReservation(long additionalOptionId, long reservationId)
    {
        var newReservationAdditionalOption = new DAL.DbAll.Entities.ReservationAdditionalOption
        {
            AdditionalOptionId = additionalOptionId,
            ReservationId = reservationId
        };
        
        _dalContext.ReservationAdditionalOptions.Add(newReservationAdditionalOption);
        
        await _dalContext.SaveChangesAsync();
        
        var additionalOption = await _dalContext.ReservationAdditionalOptions
            .Where(r => r.AdditionalOptionId == additionalOptionId && r.ReservationId == reservationId)
            .Include(r => r.AdditionalOption)
            .FirstOrDefaultAsync();

        if (additionalOption == null || additionalOption.AdditionalOption == null)
        {
            throw new InvalidOperationException("AdditionalOption not found for the reservation.");
        }

        return new GetAdditionalOptionDto
        {
            AdditionalOptionId = additionalOption.AdditionalOptionId,
            OptionName = additionalOption.AdditionalOption.OptionName,
            Price = additionalOption.AdditionalOption.Price
        };
    }

    public async Task<GetAdditionalOptionDto> RemoveAdditionalOptionFromReservation(long additionalOptionId, long reservationId)
    {
        var reservationAdditionalOptionToDelete = await _dalContext.ReservationAdditionalOptions
            .Where(reservationAdditionalOption =>
                reservationAdditionalOption.AdditionalOptionId == additionalOptionId &&
                reservationAdditionalOption.ReservationId == reservationId).Include(reservationAdditionalOption =>
                reservationAdditionalOption.AdditionalOption)
            .FirstOrDefaultAsync();

        if (reservationAdditionalOptionToDelete != null)
        {
            _dalContext.ReservationAdditionalOptions.Remove(reservationAdditionalOptionToDelete);

            await _dalContext.SaveChangesAsync();

            return new GetAdditionalOptionDto
            {
                AdditionalOptionId = reservationAdditionalOptionToDelete.AdditionalOptionId,
                OptionName = reservationAdditionalOptionToDelete.AdditionalOption.OptionName,
                Price = reservationAdditionalOptionToDelete.AdditionalOption.Price
            };
        }

        return new GetAdditionalOptionDto();
    }

    public async Task<List<GetAdditionalOptionDto>> GetAdditionalOptionsForReservation(long reservationId)
    {
        var additionalOptionsForReservation = await _dalContext.ReservationAdditionalOptions
            .Where(reservationAdditionalOption => reservationAdditionalOption.ReservationId == reservationId)
            .Select(reservationAdditionalOption => new GetAdditionalOptionDto
            {
                AdditionalOptionId = reservationAdditionalOption.AdditionalOptionId,
                OptionName = reservationAdditionalOption.AdditionalOption.OptionName,
                Price = reservationAdditionalOption.AdditionalOption.Price
            })
            .ToListAsync();
        
        return additionalOptionsForReservation;
    }
    
}