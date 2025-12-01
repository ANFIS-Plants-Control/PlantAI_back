using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using PlantAI.Grpc;
using System.Net;

namespace PlantAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public Calculator.CalculatorClient _client;
        public ValuesController(Calculator.CalculatorClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                HttpClient.DefaultProxy = new WebProxy();
                var answer = await _client.AddAsync(new AddRequest { A = 2, B = 5 });

                return Ok(answer.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
