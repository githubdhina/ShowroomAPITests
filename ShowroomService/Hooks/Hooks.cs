using ShowroomService.Helper;

namespace ShowroomService.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        public static ExtentReportHelper? ExtentReporter;

        private ScenarioContext _scenarioContext;
        private FeatureContext _featureContext;

        public Hooks(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            _scenarioContext = scenarioContext;
            _featureContext = featureContext;
            ExtentReporter = new ExtentReportHelper(_scenarioContext, _featureContext);
            
        }


        [BeforeScenario()]
        public void BeforeScenarioSetUp()
        {
            ExtentReporter.HtmlReportBeforeScenario();
        }

        [AfterStep]
        public void AfterStep()
        {

            ExtentReporter.HtmlReportAfterEachScenarioStep();

        }

        [AfterScenario()]
        public void AfterScenarioSetUp()
        {
            ExtentReportHelper.HtmlReportAfterScenario();
        }


    }
}