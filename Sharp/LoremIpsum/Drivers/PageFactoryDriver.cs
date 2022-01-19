using OpenQA.Selenium;
using LoremIpsum.Pages;

namespace LoremIpsum.Drivers
{
    public class PageFactoryDriver
    {
        public IWebDriver driver;

        public PageFactoryDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePage GetHomePage()
        {
            return new HomePage(driver);
        }
    }
}