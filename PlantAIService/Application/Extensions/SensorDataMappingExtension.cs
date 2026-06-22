using Application.DTOs;

namespace Application.Extensions
{
    public static class SensorDataMappingExtension
    {

        public static ClimatStatusDto DataGroupToClimatStatus(this List<SensorDataDto> dto)
            => new ClimatStatusDto(
                temperature: dto.FirstOrDefault(x => x.SensorTypeId == 1)?.Value ?? 0, 
                humidity: dto.FirstOrDefault(x => x.SensorTypeId == 2)?.Value ?? 0, 
                co2: dto.FirstOrDefault(x => x.SensorTypeId == 3)?.Value ?? 0
            );

    }
}
