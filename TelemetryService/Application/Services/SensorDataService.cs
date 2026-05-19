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
        public SensorDataService(ISensorDataRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<SensorDataResponseDto>> ReadAllAsync()
        {
            List<SensorData> data = await _repository.ReadAllAsync();
            var response = data.Select(x => x.ToResponseDto());
            return response;
        }

        public async Task WriteAsync(CreateSensorDataDto dto)
        {
            var entity = dto.ToEntity();
            await _repository.WrightAsync(entity);
        }
    }
}