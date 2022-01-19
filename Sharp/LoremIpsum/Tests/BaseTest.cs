using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using LoremIpsum.Pages;

namespace LoremIpsum.Tests
{


    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        private IWebDriver driver;
        private const string _loremIpsumURL = "https://www.lipsum.com/";


        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"/Applications/BraveBrowser.app/Contents/MacOS/Brave Browser";
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(_loremIpsumURL);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public IWebDriver GetWebDriver()
        {
            return driver;
        }

        public HomePage GetHomePage()
        {
            return new HomePage(GetWebDriver());
        }

        public GeneratedPage GetGeneratedPage()
        {
            return new GeneratedPage(GetWebDriver());
        }
    }
}