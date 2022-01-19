using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LoremIpsum.Pages
{
    public class GeneratedPage : BasePage
    {
        public GeneratedPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//p[1]")]
        private IWebElement _firstParagraph;

        [FindsBy(How = How.Id, Using = "lipsum")]
        private IWebElement _generatedWords;

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'lorem')]")]
        private IList<IWebElement> _paragraphsWithLorem;

        public string GetFirstParagraphText()
        {
            return _firstParagraph.Text;
        }

        public int GetAmountOfGeneratedWords()
        {
            return _generatedWords.Text.Split(" ").Count();
        }

        public int GetAmountOfGeneratedChars()
        {
            return _generatedWords.Text.ToCharArray().Count();
        }

        public int GetHowManyParagraphsWithLorem()
        {
            return _paragraphsWithLorem.Count();
        }
    }
}