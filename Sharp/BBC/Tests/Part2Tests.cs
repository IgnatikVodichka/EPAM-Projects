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
    public class Part2Tests : BaseTest
    {
        private const string Question = "My question?";
        private const string Name = "";
        private const string Email = "Tester@Testirovich.com";
        private const bool AcceptTermsAndCoditions = false;

        [Test]
        public void GoToFillInAndSubmitCoronaVirusForm()
        {
            GetHomePage().GoToNews();
            GetNewsPage().GoToCoronavirusPage();
            GetCoronavirusPage().GoToYourCoronavirusStories();
            GetCoronavirusPage().GoToSendYourQuestions();
            GetCoronavirusPage().FillInTheFormAndSubmit(AcceptTermsAndCoditions, Question, Name, Email);
            GetCoronavirusPage().ImplicitlWait(10);

            if (!AcceptTermsAndCoditions)
            {
                Assert.True(GetCoronavirusPage().CheckIfTermsAndServicesErrorMessageIsDisplayed());
            }
            int errorList = GetCoronavirusPage().GetErrorMessagesFormList().Count;
            if (errorList > 0)
            {
                for (int i = 0; i < errorList; i++)
                {
                    Assert.True(GetCoronavirusPage().CheckIfErrorMessageIsDisplayed(i));
                }
            }
        }
    }
}