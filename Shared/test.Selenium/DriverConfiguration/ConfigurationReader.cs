using System.IO;
using System.Xml;

namespace test.Selenium.DriverConfiguration
{
    // Since the generator runs in the visual studio process, we can't use ConfigurationManager, as it'll just return VS's config.
    // So we pass in the Feature file from the generationContext, and look in the Feature directory, then its parent, etc, until we find an app.config to read.
    public static class ConfigurationReader
    {
        private const string ConfigNodeSelector = "/configuration/webDriverConfig";

        public static ConfigurationSectionHandler GetConfigurationSectionFromFile(string configFile)
        {
            XmlDocument configDocument = new XmlDocument();
            configDocument.Load(configFile);
            XmlNode configNode = configDocument.SelectSingleNode(ConfigNodeSelector);
            return ConfigurationSectionHandler.CreateFromXml(configNode);
        }

        public static ConfigurationSectionHandler GetConfigurationFromFeatureFile(string path)
        {
            string nearestAppConfigPath = GetAppConfigFromFeatureFilePath(path);
            return GetConfigurationSectionFromFile(nearestAppConfigPath);
        }

        public static string GetAppConfigFromFeatureFilePath(string path)
        {
            string potentialPath = Path.Combine(path, "app.config");
            if (File.Exists(potentialPath))
            {
                return potentialPath;
            }
            else
            {
                return GetAppConfigFromFeatureFilePath(Directory.GetParent(path).ToString());
            }
        }

    }
}
