using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace LoremIpsum.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        public void OpenHomePage(string url) { driver.Navigate().GoToUrl(url); }

        [FindsBy(How = How.XPath, Using = "//div[@id='Languages']/a")]
        private IList<IWebElement> _languages;

        [FindsBy(How = How.XPath, Using = "//div[@id='Panes']//p[1]")]
        private IWebElement _firstParagraph;

        [FindsBy(How = How.Id, Using = "generate")]
        private IWebElement _generateLoremIpsumTextButton;

        [FindsBy(How = How.XPath, Using = "//input[@id='amount']")]
        private IWebElement _amountInputField;

        [FindsBy(How = How.XPath, Using = "//label")]
        private IList<IWebElement> _labels;

        public void ClickChangeLanguageButton(string Language)
        {
            _languages.Where(lang => lang.Text.Contains(Language)).FirstOrDefault().Click();
        }
        public string GetFirstParagraphText()
        {
            return _firstParagraph.Text;
        }

        public void ClickGenerateLoremIpsumTextButton()
        {
            _generateLoremIpsumTextButton.Click();
        }

        public void UncheckStratWithLoremIpsumCheckBox()
        {
            _labels.ElementAt(4).Click();
        }

        public void InputAmountOf(int amount)
        {
            _amountInputField.Clear();
            _amountInputField.SendKeys(amount.ToString());
        }

        public void ChooseTypeOfRadioButton(string radiobutton)
        {
            _labels.Where(labels => labels.Text.Contains(radiobutton)).FirstOrDefault().Click();
        }
    }
}