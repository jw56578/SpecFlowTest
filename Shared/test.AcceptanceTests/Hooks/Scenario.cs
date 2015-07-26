using BoDi;
using test.SpecFlowPlugin.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace test.Evolution2.AcceptanceTests.Hooks
{
    [Binding]
    public class Scenario
    {
        public Scenario(IObjectContainer objectContainer)
        {
            objectContainer.RegisterInstanceAs<IWebDriverFactory>(new WebDriverFactory());
            objectContainer.RegisterInstanceAs<IMethodDecorator>(new MethodDecorator());
            objectContainer.RegisterInstanceAs<IConfiguration>(new  DevConfiguration ());
        
        }
        [BeforeScenario]
        public void Before()
        {
            FeatureContext.Current.Set<IMethodDecorator>(new MethodDecorator());
        }
    }
}
