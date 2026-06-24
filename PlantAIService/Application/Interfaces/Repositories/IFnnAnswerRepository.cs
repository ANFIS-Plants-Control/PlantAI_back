using Application.DTOs.FnnAnswerDTOs;
using Core.Models;

namespace Application.Interfaces.Repositories
{
    public interface IFnnAnswerRepository
    {
        public Task CreateAsync(FnnAnswer entity);
    }
}