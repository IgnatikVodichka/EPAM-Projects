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
    public class FootBallPage : BasePage
    {
        public FootBallPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//a[@data-stat-title='Scores & Fixtures']")]
        private IWebElement _scoresAndFixturesButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='downshift-0-input']")]
        private IWebElement _searchInput;

        [FindsBy(How = How.XPath, Using = "//a[@class='sp-c-search__result-item'][1]")]
        private IWebElement _firstSearchResult;

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'sp-c-date-picker-timeline__item-inner')]")]
        private IList<IWebElement> _datesOfCompetitions;

        [FindsBy(How = How.XPath, Using = "//div[@class='sp-c-fixture__wrapper'][1]")]
        private IWebElement _firstSearchResultAccordingToDate;

        public void GoToScoresAndFixtures()
        {
            _scoresAndFixturesButton.Click();
        }

        public void SearchForTeamOrCopetition(string searchQuery)
        {
            _searchInput.SendKeys(searchQuery);
            _firstSearchResult.SendKeys(Keys.Enter);
        }

        public void ChooseDateOfCompetition(string month, int year)
        {
            var monthAndYear = _datesOfCompetitions.Where(date => date.Text.Contains(month) && date.Text.Contains(year.ToString())).FirstOrDefault();
            ScrollToElement(monthAndYear);
            monthAndYear.Click();
        }

        public void ClickFirstSearchResultAccordingToDate()
        {
            _firstSearchResultAccordingToDate.Click();
        }

        public bool CheckThatTeamNamesAndScoresAreCorrect(string teamOrScore)
        {
            return _firstSearchResultAccordingToDate.Text.Contains(teamOrScore);
        }
    }
}
