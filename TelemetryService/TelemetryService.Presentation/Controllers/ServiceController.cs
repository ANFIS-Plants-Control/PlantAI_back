using Microsoft.AspNetCore.Mvc;

namespace TelemetryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : Controller
    {
        private readonly IEnumerable<EndpointDataSource> _endpointDataSources;

        public ServiceController(IEnumerable<EndpointDataSource> endpointDataSources)
        {
            _endpointDataSources = endpointDataSources;
        }

        [HttpGet("endpoints")]
        public IActionResult GetAllEndpoints()
        {
            var endpoints = _endpointDataSources
                .SelectMany(ds => ds.Endpoints)
                .OfType<RouteEndpoint>()
                .Select(e => new
                {
                    Pattern = e.RoutePattern.RawText,
                    Methods = e.Metadata?.GetMetadata<HttpMethodMetadata>()?.HttpMethods ?? new List<string>(),
                    DisplayName = e.DisplayName,
                    Order = e.Order
                })
                .ToList();

            return Ok(endpoints);
        }
    }
}
