using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BBC.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//nav[@class='orb-nav']//a[text()='News']")]
        private IWebElement _newsButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='orb-nav-links']//a[text()='Sport']")]
        private IWebElement _sportButtonInMenu;

        public void GoToNews()
        {
            _newsButton.Click();
        }

        public void GoToSportsPage()
        {
            _sportButtonInMenu.Click();
        }
    }
}