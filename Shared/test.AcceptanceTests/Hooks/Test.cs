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
    public class Test
    {

        [BeforeTestRun]
        public static void Before()
        {
            if (System.Net.Dns.GetHostAddresses("sqlelead1")[0].ToString().StartsWith("1.1.") ||
                System.Net.Dns.GetHostAddresses("devsqlelead1")[0].ToString().StartsWith("1.1."))
            {
                // Assert.Fail("These tests are not intended to run against production.");
            }

           
           

        }


    }
}
