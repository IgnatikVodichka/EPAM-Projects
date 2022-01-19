using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LoremIpsum.Pages;
using LoremIpsum.Drivers;
using NUnit.Framework;

namespace LoremIpsum.Steps
{
    [Binding]
    public sealed class StepDefinitions
    {
        private static long _defaultTimeOut = 90;
        public IWebDriver driver;
        private readonly ScenarioContext _scenarioContext;
        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"/Applications/BraveBrowser.app/Contents/MacOS/Brave Browser";
            driver = new ChromeDriver(options);
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

        public HomePage GetHomePage()
        {
            return new HomePage(driver);
        }

        [Given("User opens Home Page (.*)")]
        public void UserOpensHomePage(string homePage)
        {
            GetHomePage().OpenHomePage(homePage);
        }

        [When("User changes language (.*)")]
        public void ChangesLanguage(string language)
        {
            GetHomePage().ClickChangeLanguageButton(language);
        }

        [Then("User checks that first paragraph contains expected word (.*)")]
        public void ChecksThatFirstParagraphStartsWithExpectedWord(string word)
        {
            GetHomePage().waitForPageLoadComplete(_defaultTimeOut);
            Assert.True(GetHomePage().GetFirstParagraphText().Contains(word));
        }
    }
}