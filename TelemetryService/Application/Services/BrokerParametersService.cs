using Application.DTOs.MQTT.BrokerParameters;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Utils.Mapping;

namespace Application.Services
{
    public class BrokerParametersService : IBrokerParametersService
    {
        private readonly IBrokersParametersRepository _repository;
        public BrokerParametersService(IBrokersParametersRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseBrokerParametersDto> CreateAsync(CreateBrokerParametersDto dto)
        {
            CheckParamters(dto);

            try
            {
                await _repository.CreateAsync(dto.ToEntity());
                var response = await _repository.GetByAddressAsync(dto.host, dto.port);
                return response.ToResponse();
            }
            catch (Exception ex) 
            {
                throw new Exception($"{dto.host}:{dto.port} address already exists");
            }
        }

        public async Task<ResponseBrokerParametersDto> GetByAddressAsync(CreateBrokerParametersDto dto)
        {
            CheckParamters(dto);

            try
            {
                var response = await _repository.GetByAddressAsync(dto.host, dto.port);
                return response.ToResponse();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        private void CheckParamters(CreateBrokerParametersDto dto)
        {
            if (dto == null)
                throw new Exception("Nothing to create");

            if (string.IsNullOrWhiteSpace(dto.host))
                throw new Exception("Host cannot be empty");
        }
    }
}
