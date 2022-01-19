using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoremIpsum.Tests
{
    public class Part2Tests : BaseTest
    {
        private const int TomeToWait = 10;
        private const string ExpectedPhrase = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";
        private static readonly List<int> AmountOfWords = new List<int> { 10, -1, 0, 5, 20 };
        private static List<string> RadioButtons = new List<string> { "words", "bytes" };
        private const int HowManyTimes = 10;

        [Test]
        public void CheckThatFirstParagraphNotStartsWithLoremIpsum()
        {
            GetHomePage().UncheckStratWithLoremIpsumCheckBox();
            GetHomePage().ClickGenerateLoremIpsumTextButton();
            Assert.False(GetGeneratedPage().GetFirstParagraphText().Contains(ExpectedPhrase));
        }

        [Test]
        public void CheckThatOutputWordsHaveCorrectAmount()
        {
            GetHomePage().ChooseTypeOfRadioButton(RadioButtons[0]);
            foreach (int amount in AmountOfWords)
            {
                GetHomePage().InputAmountOf(amount);
                GetHomePage().ClickGenerateLoremIpsumTextButton();
                GetGeneratedPage().ImplicitlWait(TomeToWait);
                if (amount >= 5)
                {
                    Assert.True(GetGeneratedPage().GetAmountOfGeneratedWords() == amount);
                }
                else
                {
                    Assert.True(GetGeneratedPage().GetAmountOfGeneratedWords() == 5);
                }
                GetWebDriver().Navigate().Back();
            }
        }

        [Test]
        public void CheckThatOutputBytesHaveCorrectAmount()
        {
            GetHomePage().ChooseTypeOfRadioButton(RadioButtons[1]);

            foreach (int amount in AmountOfWords)
            {
                GetHomePage().InputAmountOf(amount);
                GetHomePage().ClickGenerateLoremIpsumTextButton();
                GetGeneratedPage().ImplicitlWait(TomeToWait);
                if (amount >= 3)
                {
                    Assert.True(GetGeneratedPage().GetAmountOfGeneratedChars() == amount);
                }
                else if (amount <= 0)
                {
                    Assert.True(GetGeneratedPage().GetAmountOfGeneratedChars() == 5);
                }
                else
                {
                    Assert.True(GetGeneratedPage().GetAmountOfGeneratedChars() == 3);
                }
                GetWebDriver().Navigate().Back();
            }
        }

        [Test]
        public void CheckAverageParagraphsContainLorem()
        {
            float counter = 0;
            for (int i = 0; i < HowManyTimes; i++)
            {
                GetHomePage().ClickGenerateLoremIpsumTextButton();
                GetGeneratedPage().ImplicitlWait(TomeToWait);
                counter += GetGeneratedPage().GetHowManyParagraphsWithLorem();
                GetWebDriver().Navigate().Back();
            }
            counter /= HowManyTimes;
            Assert.True(counter < 3);
        }
    }
}