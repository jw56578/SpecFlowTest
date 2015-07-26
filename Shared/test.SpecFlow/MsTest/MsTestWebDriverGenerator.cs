using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.CodeDom.Compiler;
using System.CodeDom;

using TechTalk.SpecFlow.Generator;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;
using TechTalk.SpecFlow.UnitTestProvider;
using TechTalk.SpecFlow.Utils;

using test.SpecFlowPlugin.CodeDomExtensions;

namespace test.SpecFlowPlugin.MsTest
{

    public static class LogWriter
    {
        private const string LogFileName = @"C:\MsTestWebDriverGeneratorLog.txt";

        public static void WriteLine(string logText)
        {
            StreamWriter logWriter;
            if (!File.Exists(LogFileName))
            {
                logWriter = new StreamWriter(LogFileName);
            }
            else
            {
                logWriter = File.AppendText(LogFileName);
            }

            logWriter.Write(DateTime.Now);
            logWriter.WriteLine(logText);
            logWriter.Close();
        }
    }

    public class MsTestWebDriverPlugin : IGeneratorPlugin
    {
        #region IGeneratorPlugin Members

        public void RegisterConfigurationDefaults(TechTalk.SpecFlow.Generator.Configuration.SpecFlowProjectConfiguration specFlowConfiguration)
        {

        }

        public void RegisterCustomizations(BoDi.ObjectContainer container, TechTalk.SpecFlow.Generator.Configuration.SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<MsTestWebDriverGenerator, IUnitTestGeneratorProvider>();
            container.RegisterTypeAs<MsTestRuntimeProvider, IUnitTestRuntimeProvider>();
        }

        public void RegisterDependencies(BoDi.ObjectContainer container)
        {
        }

        #endregion

    }

    public class MsTestWebDriverGenerator : MsTestGeneratorProvider
    {

        private const string GivenIAmUsingTheBrowser = @" testRunner.Given(""I am using the \""{0}\"" browser"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), ""Given "");";
        private const string UpdateScenarioCurrentStep = @" if (testRunner.ScenarioContext.ContainsKey(""CurrentStep"")) {{ testRunner.ScenarioContext[""CurrentStep""] = ""{0}""; }} else {{ testRunner.ScenarioContext.Add(""CurrentStep"", ""{0}""); }}";

        public MsTestWebDriverGenerator(CodeDomHelper codeDomHelper)
            : base(codeDomHelper)
        {
        }

        private static List<CodeMemberMethod> GetSeleniumTestMethods(TestClassGenerationContext generationContext)
        {
            List<CodeMemberMethod> seleniumTestMethods = new List<CodeMemberMethod>();
            List<CodeMemberMethod> allTestMethods = GetAllTestMethods(generationContext);

            return GetSeleniumTestMethods(allTestMethods);
        }

        private static List<CodeMemberMethod> GetSeleniumTestMethods(List<CodeMemberMethod> codeMemberMethods)
        {
            List<CodeMemberMethod> seleniumTestMethods = new List<CodeMemberMethod>();

            foreach (var currentMember in codeMemberMethods)
            {
                if (GetScenarioTags(((CodeMemberMethod)currentMember).Statements).Contains("Selenium"))
                {
                    seleniumTestMethods.Add(currentMember);
                }
            }

            return seleniumTestMethods;
        }

        private static List<CodeMemberMethod> GetAllTestMethods(TestClassGenerationContext generationContext)
        {
            List<CodeMemberMethod> testMethods = new List<CodeMemberMethod>();

            CodeTypeMemberCollection testClassMembers = generationContext.TestClass.Members;
            int memberCount = testClassMembers.Count;

            for (int i = 0; i < memberCount; i++)
            {
                CodeTypeMember currentMember = testClassMembers[i];

                foreach (CodeAttributeDeclaration memberAttribute in currentMember.CustomAttributes)
                {
                    if (memberAttribute.Name == TEST_ATTR)
                    {
                        testMethods.Add((CodeMemberMethod)currentMember);
                    }
                }
            }

            return testMethods;
        }


        private static List<string> GetBrowserTagsList(test.Selenium.DriverConfiguration.RemoteWebDriverConfigElement driverConfigElement)
        {
            List<string> browserTagsList = new List<string>();
            if (driverConfigElement.BrowserTags != null)
            {
                string[] browserTags = driverConfigElement.BrowserTags.Split();
                browserTagsList = browserTags.ToList<string>();
            }

            return browserTagsList;
        }

        private List<CodeMemberMethod> CreateWebDriverTestMethods(List<CodeMemberMethod> testMethods, TestClassGenerationContext generationContext, test.Selenium.DriverConfiguration.ConfigurationSectionHandler webDriverConfig)
        {
            List<CodeMemberMethod> webDriverTestMethods = new List<CodeMemberMethod>();

            var activeDrivers = webDriverConfig.RemoteDrivers.GetActiveDrivers();

            foreach (CodeMemberMethod testMethod in testMethods)
            {
                foreach (var remoteDriver in activeDrivers)
                {
                    var browserTagsList = GetBrowserTagsList(remoteDriver);

                    var scenarioTags = GetScenarioTags(testMethod.Statements);

                    // If there are any Not<tag> tags, add the driver's key to a list of keys to ignore
                    var tagsStartingWithNot = scenarioTags.FindAll(item => item.StartsWith("Not"));
                    // We need to ensure that these actually correspond to driver tags.  If it doesn't, then discard it.
                    var startingWithNotTagsToDiscard = new List<string>();
                    tagsStartingWithNot.ForEach(item =>
                    {
                        bool tagExistsInSomeDriver = false;
                        var browserTagToIgnore = item.Substring("Not".Length, item.Length - "Not".Length);
                        foreach (var driver in activeDrivers)
                        {
                            if (browserTagsList.Contains(browserTagToIgnore))
                            {
                                tagExistsInSomeDriver = true;
                            }
                        }
                        if (!tagExistsInSomeDriver)
                        {
                            startingWithNotTagsToDiscard.Add(item);
                        }
                    });
                    tagsStartingWithNot.RemoveAll(item => startingWithNotTagsToDiscard.Contains(item));

                    var keysToIgnore = new List<string>();

                    tagsStartingWithNot.ForEach(item =>
                    {
                        var browserTagToIgnore = item.Substring("Not".Length, item.Length - "Not".Length);
                        // Find any browsers that have this tag
                        foreach (var driver in activeDrivers)
                        {
                            if (browserTagsList.Contains(browserTagToIgnore))
                            {
                                keysToIgnore.Add(driver.Key);
                            }
                        }
                    });

                    var tagsStartingWithOnly = scenarioTags.FindAll(item => item.StartsWith("Only"));

                    // We need to ensure that these actually correspond to driver tags.  If it doesn't, then discard it.
                    var startingWithOnlyTagsToDiscard = new List<string>();
                    tagsStartingWithOnly.ForEach(item =>
                    {
                        bool tagExistsInSomeDriver = false;
                        var onlyBrowserTag = item.Substring("Only".Length, item.Length - "Only".Length);
                        foreach (var driver in activeDrivers)
                        {
                            if (GetBrowserTagsList(driver).Contains(onlyBrowserTag))
                            {
                                tagExistsInSomeDriver = true;
                            }
                        }
                        if (!tagExistsInSomeDriver)
                        {
                            startingWithOnlyTagsToDiscard.Add(item);
                        }
                    });

                    tagsStartingWithOnly.RemoveAll(item => startingWithOnlyTagsToDiscard.Contains(item));
                    // If there is an Only<tag> tag, add all other driver keys to the ignore list
                    if (tagsStartingWithOnly.Count > 0)
                    {
                        var lastStartingWithOnlyTag = tagsStartingWithOnly[tagsStartingWithOnly.Count - 1];
                        var onlyBrowserTag = lastStartingWithOnlyTag.Substring("Only".Length, lastStartingWithOnlyTag.Length - "Only".Length);
                        foreach (var driver in activeDrivers)
                        {
                            if (!GetBrowserTagsList(driver).Contains(onlyBrowserTag))
                            {
                                keysToIgnore.Add(driver.Key);
                            }
                        }
                    }

                    if (keysToIgnore.Contains(remoteDriver.Key)) { continue; }
                    // Duplicate the test method verbatim, alter its method name and add a property so it's unique to this remoteDriver
                    CodeMemberMethod clonedTestMethod = testMethod.Clone();

                    string testMethodSuffix = "_With_" + remoteDriver.Key;
                    if (remoteDriver.TestMethodSuffix != String.Empty)
                    {
                        testMethodSuffix = remoteDriver.TestMethodSuffix;
                    }

                    clonedTestMethod.Name = clonedTestMethod.Name + testMethodSuffix;

                    CodeDomHelper.AddAttribute(clonedTestMethod, PROPERTY_ATTR, "WebDriver", remoteDriver.Key);

                    // We need to set up the scenario first, so we insert our Given directly after it.
                    int insertIndex = GetScenarioSetupStatementIndex(clonedTestMethod.Statements) + 1;
                    clonedTestMethod.Statements.Insert(insertIndex, new CodeSnippetStatement(String.Format(GivenIAmUsingTheBrowser, remoteDriver.Key)));

                    webDriverTestMethods.Add(clonedTestMethod);
                }
            }

            return webDriverTestMethods;
        }

        // Find the TechTalk.Specflow.ScenarioInfo assignment contsructor's string array of tags.
        private static List<string> GetScenarioTags(CodeStatementCollection statements)
        {
            List<string> scenarioTags = new List<string>();

            for (int index = 0; index < statements.Count; index++)
            {
                if (statements[index] is CodeVariableDeclarationStatement)
                {
                    var declaration = (CodeVariableDeclarationStatement)statements[index];

                    if (declaration.Type.BaseType == typeof(TechTalk.SpecFlow.ScenarioInfo).ToString())
                    {
                        var createExpression = (CodeObjectCreateExpression)declaration.InitExpression;
                        var lastCreateExpressionParam = createExpression.Parameters[createExpression.Parameters.Count - 1];
                        if (lastCreateExpressionParam is CodeArrayCreateExpression)
                        {
                            var arrayInitializers = ((CodeArrayCreateExpression)lastCreateExpressionParam).Initializers;
                            for (int initializerIndex = 0; initializerIndex < arrayInitializers.Count; initializerIndex++)
                            {
                                string tagName = ((CodePrimitiveExpression)arrayInitializers[initializerIndex]).Value.ToString();
                                scenarioTags.Add(tagName);
                            }
                        }
                    }
                }
            }

            return scenarioTags;
        }

        // Find the "testRunner.ScenarioSetup()" call.  We want to call the implicit GivenIAmUsingTheBrowser(string remoteDriverKey) step immediately after it.
        private static int GetScenarioSetupStatementIndex(CodeStatementCollection statements)
        {
            int index;

            for (index = 0; index < statements.Count; index++)
            {
                if (statements[index] is CodeExpressionStatement)
                {
                    CodeExpressionStatement statement = (CodeExpressionStatement)statements[index];
                    CodeMethodInvokeExpression expression = (CodeMethodInvokeExpression)statement.Expression;
                    if (expression.Method.MethodName == "ScenarioSetup")
                    {
                        return index;
                    }
                }
            }

            return index;
        }

        private static string ToLiteral(string input)
        {
            using (var writer = new StringWriter())
            {
                using (var provider = CodeDomProvider.CreateProvider("CSharp"))
                {
                    provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                    return writer.ToString();
                }
            }
        }

        // Find all "testRunner.Given/When/Then" calls.  We want to update the ScenarioContext with their info so the tests can log better information.
        private static List<KeyValuePair<int, string>> GetTestRunnerStatements(CodeStatementCollection statements)
        {
            List<KeyValuePair<int, string>> results = new List<KeyValuePair<int, string>>();

            for (int index = 0; index < statements.Count; index++)
            {
                if (statements[index] is CodeExpressionStatement)
                {
                    CodeExpressionStatement statement = (CodeExpressionStatement)statements[index];
                    CodeMethodInvokeExpression expression = (CodeMethodInvokeExpression)statement.Expression;
                    string methodName = expression.Method.MethodName;
                    if (methodName == "Given" || methodName == "When" || methodName == "Then" || methodName == "And")
                    {
                        var parameters = expression.Parameters;
                        string stepNameParam = ((CodePrimitiveExpression)parameters[0]).Value.ToString();
                        string fullEscapedStepName = ToLiteral(methodName + " " + stepNameParam);
                        string escapedStepName = fullEscapedStepName.Substring(1, fullEscapedStepName.Length - 2);
                        results.Add(new KeyValuePair<int, string>(index, escapedStepName));
                    }
                }
            }

            return results;
        }

        // Retrieve the test methods, duplicate them for each driver, then replace the originals.
        public override void FinalizeTestClass(TestClassGenerationContext generationContext)
        {
            test.Selenium.DriverConfiguration.ConfigurationSectionHandler webDriverConfig = test.Selenium.DriverConfiguration.ConfigurationReader.GetConfigurationFromFeatureFile(generationContext.Feature.SourceFile);

            // Loop through all TestMethods and add the ScnearionContext["CurrentStep"] statement so our tests can know what step they are on.
            List<CodeMemberMethod> allTestMethods = GetAllTestMethods(generationContext);
            foreach (var testMethod in allTestMethods)
            {
                var testRunnerStatements = GetTestRunnerStatements(testMethod.Statements);
                foreach (var testRunnerStatement in testRunnerStatements)
                {
                    testMethod.Statements.Insert(testRunnerStatement.Key, new CodeSnippetStatement(String.Format(UpdateScenarioCurrentStep, testRunnerStatement.Value)));
                }
            }

            // Look for all Selenium TestMethods (@Selenium tag) and create a _With_<browserKey> TestMethod for each desired browserKey
            List<CodeMemberMethod> seleniumTestMethods = GetSeleniumTestMethods(allTestMethods);
            List<CodeMemberMethod> webDriverTestMethods = CreateWebDriverTestMethods(seleniumTestMethods, generationContext, webDriverConfig);
            seleniumTestMethods.ForEach(method => generationContext.TestClass.Members.Remove(method));
            webDriverTestMethods.ForEach(method => generationContext.TestClass.Members.Add(method));


            base.FinalizeTestClass(generationContext);
        }
    }
}
