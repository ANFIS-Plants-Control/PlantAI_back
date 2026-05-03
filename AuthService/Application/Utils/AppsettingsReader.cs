using Microsoft.Extensions.Configuration;

namespace AuthService.Utils
{
    public static class AppsettingsReader
    {

        public static string GetString(string key)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var secretKey = configuration[key];
            Console.WriteLine(secretKey);
            return secretKey.ToString();
        }
    }
}
