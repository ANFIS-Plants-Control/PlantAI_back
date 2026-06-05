
using Core.Models;
using TelemetryService.Application.DTOs.SensorData;

namespace Application.Utils.Mapping
{
    public static class SensorDataMapping
    {
        public static SensorDataResponseDto ToResponseDto(this SensorData data)
            => new SensorDataResponseDto(data.Id,
                                      data.Value,
                               data.SensorTypeId);

        public static SensorData ToEntity(this CreateSensorDataDto dto, int goupId) =>
            new SensorData()
            {
                Value = dto.Value,
                SensorTypeId = dto.SensorTypeId,
                GroupId = goupId
            };
    }
}