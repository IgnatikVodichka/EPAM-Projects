using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoremIpsum.Tests
{
    public class Part1Tests : BaseTest
    {
        private const string ExpectedWord = "рыба";
        private const string Language = "Pyccкий";
        private const string ExpectedPhrase = "Lorem ipsum dolor sit amet, consectetur adipiscing elit";

        [Test]
        public void CheckThatFishIsInFirstParagraph()
        {
            GetHomePage().ClickChangeLanguageButton(Language);
            Assert.True(GetHomePage().GetFirstParagraphText().Contains(ExpectedWord));
        }

        [Test]
        public void CheckThatDefaultGenerationStartsWithLoremIpsum()
        {
            GetHomePage().ClickGenerateLoremIpsumTextButton();
            Assert.True(GetGeneratedPage().GetFirstParagraphText().Contains(ExpectedPhrase));
        }
    }
}