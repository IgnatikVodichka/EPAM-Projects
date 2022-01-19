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
    public class SportPage : BasePage
    {
        public SportPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//div[@role='menubar']//a[@data-stat-title='Football']")]
        private IWebElement _footballButtonInSportMenu;

        public void GoToFootballPage()
        {
            _footballButtonInSportMenu.Click();
        }

    }
}