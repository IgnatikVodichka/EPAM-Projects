using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace BBC.Tests
{
    public class Part1Tests : BaseTest
    {
        private const string ExpectedArticleHeading = "Andrew accuser’s 2009 deal with Epstein published";
        private static List<string> ExpectedArticlesHeadings = new List<string> { "Fire flares up again at South Africa's parliament",
                                                                                    "The fossil expert who left his own footprint behind",
                                                                                    "Gymnast defector fled back to North - South Korea",
                                                                                    "French MPs get death threats over Covid-19 pass",
                                                                                    "Bowie estate sells rights to entire body of work"
                                                                                };

        private const string ExpectedFirstArticle = "Tech Tech Boom";

        [Test]
        public void CheckThatTheFirstArticleInNewsIsCorrect()
        {
            GetHomePage().GoToNews();
            Assert.True(GetNewsPage().GetFirstNewsArticleText().Contains(ExpectedArticleHeading));
        }

        [Test]
        public void CheckThatTheSecondaryArticlesInNewsAreCorrect()
        {
            GetHomePage().GoToNews();
            for (int i = 0; i < ExpectedArticlesHeadings.Count(); i++)
            {
                Assert.True(GetNewsPage().GetSecondaryArticleAt(i).Contains(ExpectedArticlesHeadings.ElementAt(i)));
            }
        }

        [Test]
        public void CheckThatFirstArticleAfterSearchIsCorrect()
        {
            GetHomePage().GoToNews();
            GetNewsPage().EnterTextInTopRightSearchFieldAndSubmit(GetNewsPage().GetTechNewsCategoryLinkText());
            GetSearchPage().WaitVisibilityOfElement(10, GetSearchPage().GetFirstArticle());
            Assert.True(GetSearchPage().GetFirstArticle().Text == ExpectedFirstArticle);
        }
    }
}