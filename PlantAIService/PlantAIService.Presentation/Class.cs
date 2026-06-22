using Infrastructure.AiServices.Anfis;
using Microsoft.AspNetCore.Mvc;

namespace PlantAIService
{

    [ApiController]
    [Route("/aaa")]
    public class Class : Controller
    {

        private NetAnswer.NetAnswerClient _client;
        public Class(NetAnswer.NetAnswerClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var a = await _client.GetNetAnswerAsync(new SensorDatas() { Temperature = (float)0, Humidity = (float)0 , Co2 = (float)0 });
            return Ok(a);
        }

    }

}
