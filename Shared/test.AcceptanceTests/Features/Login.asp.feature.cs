﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace test.Evolution2.AcceptanceTests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class LoggingInFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Login.asp.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Logging In", "In order to log into Evo2\r\nAs a user\r\nI should be able to attempt to log into evo" +
                    "2 crm", ProgrammingLanguage.CSharp, new string[] {
                        "Evo2"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Logging In")))
            {
                test.Evolution2.AcceptanceTests.Features.LoggingInFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login to Evo2 successfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Logging In")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("WebDriver", "Chrome")]
        public virtual void LoginToEvo2Successfully_With_Chrome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to Evo2 successfully", new string[] {
                        "Selenium"});
#line 9
this.ScenarioSetup(scenarioInfo);
 testRunner.Given("I am using the \"Chrome\" browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""); }
            testRunner.Given("I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.asp\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "When I type \"ashows\" into the \"#user\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "When I type \"ashows\" into the \"#user\" element"); }
 testRunner.When("I type \"ashows\" into the \"#user\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I type \"sales3\" into the \"[name=Password]\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I type \"sales3\" into the \"[name=Password]\" element"); }
#line 12
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I click the element \"#image1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I click the element \"#image1\""); }
            testRunner.And("I type \"sales3\" into the \"[name=Password]\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Then I wait \"4\" seconds until the browser is redirected to \"http://localhost/evol" +
    "ution2/fresh/eLead-V45/elead_track/index.aspx?login=1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Then I wait \"4\" seconds until the browser is redirected to \"http://localhost/evol" +
    "ution2/fresh/eLead-V45/elead_track/index.aspx?login=1\""); }
 testRunner.And("I click the element \"#image1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("I wait \"4\" seconds until the browser is redirected to \"http://localhost/evolution" +
                    "2/fresh/eLead-V45/elead_track/index.aspx?login=1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login to Evo2 successfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Logging In")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("WebDriver", "AndroidChrome")]
        public virtual void LoginToEvo2Successfully_With_AndroidChrome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to Evo2 successfully", new string[] {
                        "Selenium"});
#line 9
this.ScenarioSetup(scenarioInfo);
 testRunner.Given("I am using the \"AndroidChrome\" browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""); }
            testRunner.Given("I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.asp\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "When I type \"ashows\" into the \"#user\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "When I type \"ashows\" into the \"#user\" element"); }
 testRunner.When("I type \"ashows\" into the \"#user\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I type \"sales3\" into the \"[name=Password]\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I type \"sales3\" into the \"[name=Password]\" element"); }
#line 12
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I click the element \"#image1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I click the element \"#image1\""); }
            testRunner.And("I type \"sales3\" into the \"[name=Password]\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Then I wait \"4\" seconds until the browser is redirected to \"http://localhost/evol" +
    "ution2/fresh/eLead-V45/elead_track/index.aspx?login=1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Then I wait \"4\" seconds until the browser is redirected to \"http://localhost/evol" +
    "ution2/fresh/eLead-V45/elead_track/index.aspx?login=1\""); }
 testRunner.And("I click the element \"#image1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("I wait \"4\" seconds until the browser is redirected to \"http://localhost/evolution" +
                    "2/fresh/eLead-V45/elead_track/index.aspx?login=1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login to Evo2 successfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Logging In")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("WebDriver", "IE")]
        public virtual void LoginToEvo2Successfully_With_IE()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to Evo2 successfully", new string[] {
                        "Selenium"});
#line 9
this.ScenarioSetup(scenarioInfo);
 testRunner.Given("I am using the \"IE\" browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""); }
            testRunner.Given("I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.asp\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "When I type \"ashows\" into the \"#user\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "When I type \"ashows\" into the \"#user\" element"); }
 testRunner.When("I type \"ashows\" into the \"#user\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I type \"sales3\" into the \"[name=Password]\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I type \"sales3\" into the \"[name=Password]\" element"); }
#line 12
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I click the element \"#image1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I click the element \"#image1\""); }
            testRunner.And("I type \"sales3\" into the \"[name=Password]\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Then I wait \"4\" seconds until the browser is redirected to \"http://localhost/evol" +
    "ution2/fresh/eLead-V45/elead_track/index.aspx?login=1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Then I wait \"4\" seconds until the browser is redirected to \"http://localhost/evol" +
    "ution2/fresh/eLead-V45/elead_track/index.aspx?login=1\""); }
 testRunner.And("I click the element \"#image1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("I wait \"4\" seconds until the browser is redirected to \"http://localhost/evolution" +
                    "2/fresh/eLead-V45/elead_track/index.aspx?login=1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login to Evo2 successfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Logging In")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("WebDriver", "Firefox")]
        public virtual void LoginToEvo2Successfully_With_Firefox()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to Evo2 successfully", new string[] {
                        "Selenium"});
#line 9
this.ScenarioSetup(scenarioInfo);
 testRunner.Given("I am using the \"Firefox\" browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""); }
            testRunner.Given("I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.asp\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "When I type \"ashows\" into the \"#user\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "When I type \"ashows\" into the \"#user\" element"); }
 testRunner.When("I type \"ashows\" into the \"#user\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I type \"sales3\" into the \"[name=Password]\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I type \"sales3\" into the \"[name=Password]\" element"); }
#line 12
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I click the element \"#image1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I click the element \"#image1\""); }
            testRunner.And("I type \"sales3\" into the \"[name=Password]\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Then I wait \"4\" seconds until the browser is redirected to \"http://localhost/evol" +
    "ution2/fresh/eLead-V45/elead_track/index.aspx?login=1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Then I wait \"4\" seconds until the browser is redirected to \"http://localhost/evol" +
    "ution2/fresh/eLead-V45/elead_track/index.aspx?login=1\""); }
 testRunner.And("I click the element \"#image1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.Then("I wait \"4\" seconds until the browser is redirected to \"http://localhost/evolution" +
                    "2/fresh/eLead-V45/elead_track/index.aspx?login=1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login to Evo2 unsuccessfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Logging In")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("WebDriver", "Chrome")]
        public virtual void LoginToEvo2Unsuccessfully_With_Chrome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to Evo2 unsuccessfully", new string[] {
                        "Selenium"});
#line 18
this.ScenarioSetup(scenarioInfo);
 testRunner.Given("I am using the \"Chrome\" browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""); }
            testRunner.Given("I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.asp\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "When I type \"ashows\" into the \"#user\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "When I type \"ashows\" into the \"#user\" element"); }
 testRunner.When("I type \"ashows\" into the \"#user\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I type \"salesxxx3\" into the \"[name=Password]\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I type \"salesxxx3\" into the \"[name=Password]\" element"); }
#line 21
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I click the element \"#image1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I click the element \"#image1\""); }
            testRunner.And("I type \"salesxxx3\" into the \"[name=Password]\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Then The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text" +
    " \"User Name or Password were not found.\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Then The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text" +
    " \"User Name or Password were not found.\""); }
 testRunner.And("I click the element \"#image1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text \"Use" +
                    "r Name or Password were not found.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login to Evo2 unsuccessfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Logging In")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("WebDriver", "AndroidChrome")]
        public virtual void LoginToEvo2Unsuccessfully_With_AndroidChrome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to Evo2 unsuccessfully", new string[] {
                        "Selenium"});
#line 18
this.ScenarioSetup(scenarioInfo);
 testRunner.Given("I am using the \"AndroidChrome\" browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""); }
            testRunner.Given("I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.asp\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "When I type \"ashows\" into the \"#user\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "When I type \"ashows\" into the \"#user\" element"); }
 testRunner.When("I type \"ashows\" into the \"#user\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I type \"salesxxx3\" into the \"[name=Password]\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I type \"salesxxx3\" into the \"[name=Password]\" element"); }
#line 21
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I click the element \"#image1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I click the element \"#image1\""); }
            testRunner.And("I type \"salesxxx3\" into the \"[name=Password]\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Then The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text" +
    " \"User Name or Password were not found.\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Then The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text" +
    " \"User Name or Password were not found.\""); }
 testRunner.And("I click the element \"#image1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text \"Use" +
                    "r Name or Password were not found.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login to Evo2 unsuccessfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Logging In")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("WebDriver", "IE")]
        public virtual void LoginToEvo2Unsuccessfully_With_IE()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to Evo2 unsuccessfully", new string[] {
                        "Selenium"});
#line 18
this.ScenarioSetup(scenarioInfo);
 testRunner.Given("I am using the \"IE\" browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""); }
            testRunner.Given("I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.asp\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "When I type \"ashows\" into the \"#user\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "When I type \"ashows\" into the \"#user\" element"); }
 testRunner.When("I type \"ashows\" into the \"#user\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I type \"salesxxx3\" into the \"[name=Password]\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I type \"salesxxx3\" into the \"[name=Password]\" element"); }
#line 21
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I click the element \"#image1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I click the element \"#image1\""); }
            testRunner.And("I type \"salesxxx3\" into the \"[name=Password]\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Then The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text" +
    " \"User Name or Password were not found.\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Then The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text" +
    " \"User Name or Password were not found.\""); }
 testRunner.And("I click the element \"#image1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text \"Use" +
                    "r Name or Password were not found.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login to Evo2 unsuccessfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Logging In")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("WebDriver", "Firefox")]
        public virtual void LoginToEvo2Unsuccessfully_With_Firefox()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login to Evo2 unsuccessfully", new string[] {
                        "Selenium"});
#line 18
this.ScenarioSetup(scenarioInfo);
 testRunner.Given("I am using the \"Firefox\" browser", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Given I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.as" +
    "p\""); }
            testRunner.Given("I have navigated to the url \"http://localhost/evolution2/fresh/loginstay.asp\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "When I type \"ashows\" into the \"#user\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "When I type \"ashows\" into the \"#user\" element"); }
 testRunner.When("I type \"ashows\" into the \"#user\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I type \"salesxxx3\" into the \"[name=Password]\" element"; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I type \"salesxxx3\" into the \"[name=Password]\" element"); }
#line 21
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "And I click the element \"#image1\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "And I click the element \"#image1\""); }
            testRunner.And("I type \"salesxxx3\" into the \"[name=Password]\" element", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 if (testRunner.ScenarioContext.ContainsKey("CurrentStep")) { testRunner.ScenarioContext["CurrentStep"] = "Then The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text" +
    " \"User Name or Password were not found.\""; } else { testRunner.ScenarioContext.Add("CurrentStep", "Then The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text" +
    " \"User Name or Password were not found.\""); }
 testRunner.And("I click the element \"#image1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.Then("The element \"form div:nth-child(1) div.Login:nth-child(2)\" contains the text \"Use" +
                    "r Name or Password were not found.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
