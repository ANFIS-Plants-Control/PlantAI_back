using Application.DTOs.MQTT.BrokerParameters;

namespace Application.Interfaces.Services
{
    public interface IBrokerParametersService
    {

        public Task<ResponseBrokerParametersDto> CreateAsync(CreateBrokerParametersDto dto);
        public Task<ResponseBrokerParametersDto> GetByAddressAsync(CreateBrokerParametersDto dto);
    }
}
