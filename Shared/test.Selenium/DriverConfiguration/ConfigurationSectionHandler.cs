using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Xml;
using System.Collections;
using System.ComponentModel;

namespace test.Selenium.DriverConfiguration
{
    public class ConfigurationSectionHandler : ConfigurationSection
    {
        static public ConfigurationSectionHandler CreateFromXml(XmlNode xmlContent)
        {
            ConfigurationSectionHandler section = new ConfigurationSectionHandler();
            section.Init();
            section.Reset(null);
            using (var reader = new XmlNodeReader(xmlContent))
            {
                section.DeserializeSection(reader);
            }
            section.ResetModified();
            return section;
        }

        [ConfigurationProperty("remoteDrivers")]
        public RemoteWebDriverConfigCollection RemoteDrivers
        {
            get
            {
                return (RemoteWebDriverConfigCollection)this["remoteDrivers"];
            }
        }
    }

    public class DesiredCapabilitiesConfigCollection : ConfigurationElementCollection, IEnumerable<DesiredCapabilityConfigElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new DesiredCapabilityConfigElement();
        }


        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((DesiredCapabilityConfigElement)element).Key;
        }

        protected override string ElementName
        {
            get
            {
                return "desiredCapabilities";
            }
        }

        public new IEnumerator<DesiredCapabilityConfigElement> GetEnumerator()
        {
            foreach (DesiredCapabilityConfigElement item in (this as IEnumerable))
            {
                yield return item;
            }
        }
    }

    public class DesiredCapabilityConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }

        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("type", IsRequired = true)]
        public Type Type
        {
            get { return this["type"] as Type; }
            set { this["type"] = value; }
        }

        public Object GetValue()
        {
            return Convert.ChangeType(this.Value, this.Type);
        }
    }

    public class RemoteWebDriverConfigCollection : ConfigurationElementCollection, IEnumerable<RemoteWebDriverConfigElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new RemoteWebDriverConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((RemoteWebDriverConfigElement)element).Key;
        }

        protected override string ElementName
        {
            get
            {
                return "remoteDrivers";
            }
        }

        [ConfigurationProperty("defaultHubUri", IsRequired = false, DefaultValue = "http://localhost:8080/wd/hub/")]
        public string DefaultHubUri
        {
            get { return (string)this["defaultHubUri"]; }
            set { this["defaultHubUri"] = value; }
        }

        [ConfigurationProperty("commandTimeout", IsRequired = false)]
        public int CommandTimeout
        {
            get { return (int)this["commandTimeout"]; }
            set { this["commandTimeout"] = value; }
        }

        public new IEnumerator<RemoteWebDriverConfigElement> GetEnumerator()
        {
            foreach (RemoteWebDriverConfigElement item in (this as IEnumerable))
            {
                yield return item;
            }
        }

        public IEnumerable<RemoteWebDriverConfigElement> GetActiveDrivers()
        {
            return this.Where(driver => driver.Active == true);
        }

    }

    public class RemoteWebDriverConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("desiredCapabilities")]
        public DesiredCapabilitiesConfigCollection DesiredCapabilities
        {
            get { return (DesiredCapabilitiesConfigCollection)this["desiredCapabilities"]; }
        }

        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }

        [ConfigurationProperty("testMethodSuffix", DefaultValue = null)]
        public string TestMethodSuffix
        {
            get { return (string)this["testMethodSuffix"]; }
            set { this["testMethodSuffix"] = value; }
        }

        [ConfigurationProperty("active", IsRequired = false, DefaultValue = true)]
        public bool Active
        {
            get { return (bool)this["active"]; }
            set { this["active"] = value; }
        }

        [ConfigurationProperty("browserName", IsRequired = true)]
        public string BrowserName
        {
            get { return (string)this["browserName"]; }
            set { this["browserName"] = value; }
        }

        [ConfigurationProperty("browserHeight", IsRequired = false, DefaultValue = null)]
        public int? BrowserHeight
        {
            get { return (int?)this["browserHeight"]; }
            set { this["browserHeight"] = value; }
        }

        [ConfigurationProperty("browserWidth", IsRequired = false, DefaultValue = null)]
        public int? BrowserWidth
        {
            get { return (int?)this["browserWidth"]; }
            set { this["browserWidth"] = value; }
        }


        [ConfigurationProperty("browserTags", IsRequired = false, DefaultValue = null)]
        public string BrowserTags
        {
            get { return (string)this["browserTags"]; }
            set { this["browserTags"] = value; }
        }


        [ConfigurationProperty("platform", IsRequired = true)]
        public string Platform
        {
            get { return (string)this["platform"]; }
            set { this["platform"] = value; }
        }

        [ConfigurationProperty("version", IsRequired = true)]
        public string Version
        {
            get { return (string)this["version"]; }
            set { this["version"] = value; }
        }

        [ConfigurationProperty("hubUri", IsRequired = false, DefaultValue = null)]
        public string HubUri
        {
            get { return (string)this["hubUri"]; }
            set { this["hubUri"] = value; }
        }
    }
}
