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
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//span[@role='text']/p/span[1]")]
        private IWebElement _firstArticle;

        public IWebElement GetFirstArticle()
        {
            return _firstArticle;
        }
    }
}