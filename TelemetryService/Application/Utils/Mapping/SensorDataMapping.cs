
using Core.Models;
using TelemetryService.Application.DTOs.SensorData;

namespace Application.Utils.Mapping
{
    public static class SensorDataMapping
    {
        public static SensorDataResponseDto ToResponseDto(this SensorData data)
            => new SensorDataResponseDto(data.Id,
                                      data.Value,
                                       data.Date,
                               data.SensorTypeId);

        public static SensorData ToEntity(this CreateSensorDataDto dto) =>
            new SensorData()
            {
                Value = dto.Value,
                Date = dto.Date,
                SensorTypeId = dto.SensorTypeId,
                GroupId = dto.GroupId
            };
    }
}