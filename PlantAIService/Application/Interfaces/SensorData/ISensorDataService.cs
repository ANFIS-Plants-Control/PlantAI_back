using Application.DTOs;

namespace Application.Interfaces.SensorData
{
    public interface ISensorDataService
    {

        Task<ClimatStatusDto?> GetClimatStatus();

    }
}
