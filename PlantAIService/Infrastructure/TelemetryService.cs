using Application.DTOs;
using System.Net;
using System.Text.Json;

namespace Infrastructure
{
    public class TelemetryService
    {

        HttpClient client;
        string telemetryServiceAddr;
        public TelemetryService(string telemetryServiceAddr)
        {
            this.telemetryServiceAddr = telemetryServiceAddr;
            client = new HttpClient();
        }

        public async Task<List<SensorDataDto>> GetLastDatasAsync()
        {
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, telemetryServiceAddr);

            using HttpResponseMessage response = await client.SendAsync(request);

            if(response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error while request data");
            }
            var content = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<List<SensorDataDto>>(content);
            return data;
        }

    }
}
