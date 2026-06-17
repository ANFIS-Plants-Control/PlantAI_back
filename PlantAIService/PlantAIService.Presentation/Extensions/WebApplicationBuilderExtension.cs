namespace PlantAIService.Extensions
{
    public static class WebApplicationBuilderExtension
    {

        public static void ImplementBuilderServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddOpenApi();
            builder.Services.AddGrpc();

        }

    }
}
