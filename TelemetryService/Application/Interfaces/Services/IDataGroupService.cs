using Application.DTOs.DataGroup;

namespace Application.Interfaces.Services
{
    public interface IDataGroupService
    {

        Task<ResponseDataGroupDto> SaveAsync(int MqttClientId);
        Task<IEnumerable<ResponseDataGroupDto>> GetAllAsync();

    }
}
