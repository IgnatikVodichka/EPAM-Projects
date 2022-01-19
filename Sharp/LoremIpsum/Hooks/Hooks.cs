using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;


namespace LoremIpsum.Hooks
{
    [Binding]
    public class Hooks
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        private readonly ScenarioContext _scenarioContext;
        private readonly FeatureContext _featureContext;
        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
        }

        [BeforeTestRun]
        public static void InitializeReporting()
        {
            var htmlReporter = new ExtentHtmlReporter(@"/Users/ignat/Desktop/EPAM Project/Sharp/LoremIpsum/Reports/SpecFlowLoremIpsumTestReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext _scenarioContext)
        {
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext _featureContext)
        {
            featureName = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        }

        [AfterScenario]
        public static void AfterTestRun()
        {

        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

    }
}