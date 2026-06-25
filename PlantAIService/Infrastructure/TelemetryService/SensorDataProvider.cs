using Application.Interfaces.SensorData;

namespace Infrastructure.TelemetryService
{
    public class SensorDataProvider : ISensorDataProvider
    {
        private HttpClient _httpClient;
        public SensorDataProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Telemetry");
        }

        public async Task<string> GetSensorDataAsync()
        {
            var response = await _httpClient.GetAsync("SensorData/data-groups");
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
