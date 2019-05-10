using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;

namespace Powerlevel.Feature
{
    [Binding]
    public class TeamSystem : IDisposable
    {
        private string SearchKeyword;
        private ChromeDriver driver;
        public TeamSystem()
        {
            //driver = new ChromeDriver(@"C:\users\chi\Downloads\chromedriver_win32\"); //init TeamSystem to use chrome driver
            driver = new ChromeDriver();
        }

        [Given(@"I have logged in and navigated to other user's profile")]
        public void GivenIHaveLoggedInAndNavigatedToOtherUserProfile()
        {
            driver.Navigate().GoToUrl("http://google.com/");
            Assert.IsTrue(driver.Title.ToLower().Contains("google"));
        }

        [Given(@"I have not already teamed up with the user")]
        public void GivenIHaveNotAlreadyTeamedUpWithTheUser()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"I press the join team button")]
        public void WhenIPressTheJoinTeamButton()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"it should redirect the user to their own user profile page")]
        public void ThenItShouldRedirectTheUserToTheirOwnUserProfilePage()
        {
            //ScenarioContext.Current.Pending();
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Dispose();
                driver = null;
            }
        }
    }
}
