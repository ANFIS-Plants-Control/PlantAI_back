using Application.DTOs.SensorData;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utils.Mapping;
using Core.Models;
using TelemetryService.Application.DTOs.SensorData;

namespace Application.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly ISensorDataRepository _repository;
        private readonly IDataGroupRepository _dataGroupRepository;
        public SensorDataService(ISensorDataRepository repository, IDataGroupRepository dataGroupRepository)
        {
            _repository = repository;
            _dataGroupRepository = dataGroupRepository;
        }
        public async Task<IEnumerable<SensorDataResponseDto>> GetAllAsync()
        {
            List<SensorData> data = await _repository.GetAllAsync();
            var response = data.Select(x => x.ToResponseDto());
            return response;
        }

        public async Task<GroupedDataResponseDto> GetLastDataAsync()
        {
            var data = await _dataGroupRepository.GetLastGroupdSensorDataAsync();
            var response = data.ToGroupedDataResponse();
            return response;
        }

        public async Task SaveAsync(IEnumerable<CreateSensorDataDto> dto, int groupId)
        {
            await _repository.SaveAsync(dto.Select(x => x.ToEntity(groupId)));
        }
    }
}