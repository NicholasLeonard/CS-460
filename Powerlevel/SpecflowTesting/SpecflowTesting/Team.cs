using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTesting
{
    [Binding]
    public class Team : IDisposable
    {
        private ChromeDriver driver;

        public Team()
        {
            driver = new ChromeDriver();
        }

        string TeamupButtontext;

        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            driver.Navigate().GoToUrl("https://powerlevel.azurewebsites.net/Account/Login");
            Assert.IsTrue(driver.Url.ToLower().Contains("account"));
        }

        [Given(@"navgated to my user profile")]
        public void GivenNavgatedToMyUserProfile()
        {
            var userName = driver.FindElementById("Username");
            var password = driver.FindElementById("Password");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Username")));
            userName.SendKeys("chi");
            password.SendKeys("Test123!");
            var loginButton = driver.FindElementByClassName("btn-primary");
            loginButton.Click();
          
            driver.Navigate().GoToUrl("https://powerlevel.azurewebsites.net/user/Profiles/15");
        }

        [When(@"I click the teamup button")]
        public void WhenIClickTheTeamupButton()
        {
            var teamupButton = driver.FindElementByClassName("btn-success");
            TeamupButtontext = teamupButton.Text;
            teamupButton.Click();
        }

        [Then(@"the page remain unchanged")]
        public void ThenThePageRemainUnchanged()
        {
            Assert.IsTrue(TeamupButtontext.Length == 0); //the button is empty
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
