using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BBC.Tests
{
    using BBC.Pages;
    public class BaseTest
    {
        private IWebDriver driver;
        private const string BbcURL = " https://bbc.com/ ";

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.BinaryLocation = @"/Applications/BraveBrowser.app/Contents/MacOS/Brave Browser";
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(BbcURL);
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
        public NewsPage GetNewsPage()
        {
            return new NewsPage(GetWebDriver());
        }

        public SearchPage GetSearchPage()
        {
            return new SearchPage(GetWebDriver());
        }

        public CoronavirusPage GetCoronavirusPage()
        {
            return new CoronavirusPage(GetWebDriver());
        }

        public SportPage GetSportPage()
        {
            return new SportPage(GetWebDriver());
        }

        public FootBallPage GetFootBallPage()
        {
            return new FootBallPage(GetWebDriver());
        }
    }
}