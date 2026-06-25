using Application.DTOs.ControlElementDTOs;

namespace Application.Interfaces.Repositories
{
    public interface IControlElementRepository
    {
        public Task CreateAsync(ControlElementCreateDto dto);

    }
}