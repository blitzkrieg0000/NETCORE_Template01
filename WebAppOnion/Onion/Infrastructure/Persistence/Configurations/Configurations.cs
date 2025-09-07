using Microsoft.Extensions.Configuration;

namespace Persistence.Configurations;


static class Configuration {
    public static string ConnectionString {
        get {
            ConfigurationManager configurationManager = new();
            try {
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/UI"));
                configurationManager.AddJsonFile("appsettings.json");
            } catch {
                configurationManager.AddJsonFile("appsettings.Production.json");
            }

            return configurationManager.GetConnectionString("Default");
        }
    }
}

