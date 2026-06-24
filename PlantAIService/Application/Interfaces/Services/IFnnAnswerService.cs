using Application.DTOs.FnnAnswerDTOs;

namespace Application.Interfaces.Services
{
    public interface IFnnAnswerService
    {
        public Task CreateAsync(FnnAnswerCreateDto dto);
    }
}