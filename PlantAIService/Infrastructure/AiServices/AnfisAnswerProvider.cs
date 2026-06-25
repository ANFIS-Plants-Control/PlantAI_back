using Application.DTOs;
using Application.Interfaces.Anfis;
using Infrastructure.AiServices.Anfis;

namespace Infrastructure.AiServices
{
    internal class AnfisAnswerProvider : IAnfisAnswerProvider
    {

        private NetAnswer.NetAnswerClient _netClient;
        public async Task<double> GetNetAnswer(ClimatStatusDto dto)
        {
            var response = await _netClient.GetNetAnswerAsync(new SensorDatas() { Temperature = dto.Temperature, Humidity = dto.Humidity, Co2 = dto.CO2 });
            return response.Ans;
        }
    }
}
