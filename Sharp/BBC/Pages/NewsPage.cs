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
    public class NewsPage : BasePage
    {
        public NewsPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//h3[contains(@class,'gs-c-promo-heading')][1]")]
        private IWebElement _firstNewsArticle;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'gel-layout__item nw-c-top-stories__secondary-item')]")]
        private IList<IWebElement> _secondaryArticlesList;

        [FindsBy(How = How.XPath, Using = "//nav[@class='nw-c-nav__wide']//a[contains(@class,'nw-o-link')]//span[text()='Tech']")]
        private IWebElement _techNewsCategoryLink;

        [FindsBy(How = How.Id, Using = "orb-search-q")]
        private IWebElement _topRightSerachField;

        [FindsBy(How = How.XPath, Using = "//nav[@class='nw-c-nav__wide']//span[text()='Coronavirus']")]
        private IWebElement _coronaVirusButton;

        public string GetFirstNewsArticleText()
        {
            return _firstNewsArticle.Text;
        }

        public string GetSecondaryArticleAt(int i)
        {
            return _secondaryArticlesList.ElementAt(i).Text;
        }

        public string GetTechNewsCategoryLinkText()
        {
            return _techNewsCategoryLink.Text;
        }

        public void EnterTextInTopRightSearchFieldAndSubmit(string text)
        {
            _topRightSerachField.SendKeys(text + Keys.Enter);
        }

        public void GoToCoronavirusPage()
        {
            _coronaVirusButton.Click();
        }
    }
}