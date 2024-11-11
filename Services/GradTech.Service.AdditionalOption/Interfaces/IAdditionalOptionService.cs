using GradTech.Abstraction.AdditionalOptionService.Models.Request;
using GradTech.Abstraction.AdditionalOptionService.Models.Response;

namespace GradTech.Service.AdditionalOption.Interfaces;

public interface IAdditionalOptionService
{
    public Task<List<GetAdditionalOptionDto>> GetAdditionalOptions();
    
    public Task<GetAdditionalOptionDto> GetAdditionalOption(long additionalOptionId);
    
    public Task<GetAdditionalOptionDto> AddAdditionalOption(AddAdditionalOptionDto additionalOption);
    
    public Task<GetAdditionalOptionDto> EditAdditionalOption(EditAdditionalOptionDto additionalOption);
    
    public Task<GetAdditionalOptionDto> DeleteAdditionalOption(long additionalOptionId);
    
    public Task<GetAdditionalOptionDto> AddAdditionalOptionToReservation(long additionalOptionId, long reservationId);
    
    public Task<GetAdditionalOptionDto> RemoveAdditionalOptionFromReservation(long additionalOptionId, long reservationId);
    
    public Task<List<GetAdditionalOptionDto>> GetAdditionalOptionsForReservation(long reservationId);
    
}