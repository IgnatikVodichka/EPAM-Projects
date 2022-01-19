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
    public class CoronavirusPage : BasePage
    {
        public CoronavirusPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//nav[@class='nw-c-nav__wide-secondary']//span[text()='Your Coronavirus Stories']")]
        private IWebElement _yourCoronavirusStoriesButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='/news/52143212']")]
        private IWebElement _sendYourQuestion;

        [FindsBy(How = How.XPath, Using = "//textarea[contains(@id,'hearken-embed-module')]")]
        private IWebElement _yourQuestionField;

        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Name']")]
        private IWebElement _yourNameField;

        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Email address']")]
        private IWebElement _yourEmailField;

        [FindsBy(How = How.XPath, Using = "//label//input[@type='checkbox']")]
        private IWebElement _acceptTermsAndServices;

        [FindsBy(How = How.XPath, Using = "//button[@class='button' and text()='Submit']")]
        private IWebElement _submitFormButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-error-message']")]
        private IList<IWebElement> _errorMessagesFormList;

        public void GoToYourCoronavirusStories()
        {
            _yourCoronavirusStoriesButton.Click();
        }

        public void GoToSendYourQuestions()
        {
            _sendYourQuestion.Click();
        }

        public IList<IWebElement> GetErrorMessagesFormList()
        {
            return _errorMessagesFormList;
        }

        public void FillInTheFormAndSubmit(bool accept, string question, string name, string email)
        {
            _yourQuestionField.SendKeys(question);
            _yourNameField.SendKeys(name);
            _yourEmailField.SendKeys(email);
            if (accept)
                _acceptTermsAndServices.Click();
            _submitFormButton.Submit();
        }
        public bool CheckIfErrorMessageIsDisplayed(int i)
        {
            return _errorMessagesFormList.ElementAt(i).Displayed;
        }

        public bool CheckIfTermsAndServicesErrorMessageIsDisplayed()
        {
            return _errorMessagesFormList.Where(message => message.Text.Contains("must be accepted")).Last().Displayed;
        }
    }
}