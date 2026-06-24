using Application.DTOs.FnnAnswerDTOs;

namespace Application.Interfaces.Repositories
{
    public interface IFnnRepository
    {
        public Task CreateAsync(FnnCreateDto dto);
    }
}