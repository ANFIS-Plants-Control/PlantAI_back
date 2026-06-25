using Application.DTOs.FnnAnswerDTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class FnnAnswerService : IFnnAnswerService
    {
        private readonly IFnnAnswerRepository _repository;
        public Task CreateAsync(FnnAnswerCreateDto dto)
        {

            throw new NotImplementedException();
        }
    }
}