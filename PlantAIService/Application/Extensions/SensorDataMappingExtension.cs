using Application.DTOs;

namespace Application.Extensions
{
    public static class SensorDataMappingExtension
    {

        public static ClimatStatusDto DataGroupToClimatStatus(this List<SensorDataDto> dto)
            => new ClimatStatusDto(
                DataGroupId: dto.FirstOrDefault()?.DataGroupId ?? -1,
                Temperature: dto.FirstOrDefault(x => x.SensorTypeId == 1)?.Value ?? 0, 
                Humidity: dto.FirstOrDefault(x => x.SensorTypeId == 2)?.Value ?? 0, 
                CO2: dto.FirstOrDefault(x => x.SensorTypeId == 3)?.Value ?? 0
            );

    }
}
