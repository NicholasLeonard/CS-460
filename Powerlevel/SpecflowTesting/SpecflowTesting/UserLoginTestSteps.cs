using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace SpecflowTesting.StepBindings
{
    [Binding]
    public class UserLoginTestSteps : IDisposable
    {
        private string userKey;
        private string passKey;
        private ChromeDriver driver;

        public UserLoginTestSteps()
        {
            driver = new ChromeDriver();
        }

        [Given(@"I have navigated to the user login page on the Powerlevel website")]
        public void GivenIHaveNavigatedToTheUserLoginPageOnThePowerlevelWebsite()
        {
            driver.Navigate().GoToUrl("https://powerlevel.azurewebsites.net/Account/Login");
            Assert.IsTrue(driver.Url.ToLower().Contains("account"));
        }

        [Given(@"I have entered my username and password credentials")]
        public void GivenIHaveEnteredMyUsernameAndPasswordCredentials()
        {
            this.userKey = "jacetest";
            this.passKey = "Jace1!";
            var searchUserBox = driver.FindElementById("Username");
            var searchKeyBox = driver.FindElementById("Password");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Username")));
            searchUserBox.SendKeys(userKey);
            searchKeyBox.SendKeys(passKey);
        }

        [When(@"I press the Log in button")]
        public void WhenIPressTheLogInButton()
        {
            var submitButton = driver.FindElementByClassName("btn-primary");
            submitButton.Click();
        }

        [Then(@"I should navigate to the Powerlevel homepage")]
        public void ThenIShouldNavigateToThePowerlevelHomepage()
        {
            System.Threading.Thread.Sleep(2000);
            Assert.IsTrue(driver.Title.ToLower().Contains("powerlevel"));
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
