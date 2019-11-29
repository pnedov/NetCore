using Microsoft.Extensions.Configuration;
using System.IO;

namespace MoviesBox.SharedLogic.Helpers
{
  public static class HelperMethods
  {
    /// <summary>
    /// Gets the root configuration.
    /// </summary>
    public static IConfigurationRoot GetRootConfig()
    {
      var configurationBuilder = new ConfigurationBuilder();
      var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
      configurationBuilder.AddJsonFile(path, false);

      return configurationBuilder.Build();
    }

    /// <summary>
    /// Gets the application configuration value.
    /// </summary>
    /// <param name="key">The key parameter.</param>
    public static string GetAppConfigValue(string key)
    {
      var appSetting = GetRootConfig().GetSection("appSettings");

      return appSetting.GetSection(key).Value;
    }
  }
}
