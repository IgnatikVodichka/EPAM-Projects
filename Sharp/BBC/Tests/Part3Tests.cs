using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace BBC.Tests
{
    public class Part3Tests : BaseTest
    {
        private const string SearchQuery = "Europa League";
        private const int Year = 2021;
        private const string Month = "APR";
        private static Dictionary<string, string> TeamsAndScores = new Dictionary<string, string>(){
                                                                                                    {"Manchester United", "6"},
                                                                                                    {"Roma","2"}
                                                                                                    };

        [Test]
        public void CheckThatTeamsAndScoresAreCorrect()
        {
            GetHomePage().GoToSportsPage();
            GetSportPage().GoToFootballPage();
            GetFootBallPage().GoToScoresAndFixtures();
            GetFootBallPage().SearchForTeamOrCopetition(SearchQuery);
            GetFootBallPage().ChooseDateOfCompetition(Month, Year);
            GetFootBallPage().ImplicitlWait(10);
            foreach (KeyValuePair<string, string> teamAndScore in TeamsAndScores)
            {
                Assert.True(GetFootBallPage().CheckThatTeamNamesAndScoresAreCorrect(teamAndScore.Key));
                Assert.True(GetFootBallPage().CheckThatTeamNamesAndScoresAreCorrect(teamAndScore.Value));
            }
            GetFootBallPage().ClickFirstSearchResultAccordingToDate();
            foreach (KeyValuePair<string, string> teamAndScore in TeamsAndScores)
            {
                Assert.True(GetFootBallPage().CheckThatTeamNamesAndScoresAreCorrect(teamAndScore.Key));
                Assert.True(GetFootBallPage().CheckThatTeamNamesAndScoresAreCorrect(teamAndScore.Value));
            }
        }
    }
}