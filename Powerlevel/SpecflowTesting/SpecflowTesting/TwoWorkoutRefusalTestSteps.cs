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
    public class TwoWorkoutRefusalTestSteps : IDisposable
    {
        private string userKey;
        private string passKey;
        private ChromeDriver driver;

        public TwoWorkoutRefusalTestSteps()
        {
            driver = new ChromeDriver();
        }

        [Given(@"I have logged into the Powerlevel website and have navigated to the Create Free Workout page")]
        public void GivenIHaveLoggedIntoThePwoerlevelWebsiteAndHaveNavigatedToTheCreateFreeWorkoutPage()
        {
            driver.Navigate().GoToUrl("https://powerlevel.azurewebsites.net/Account/Login");
            Assert.IsTrue(driver.Url.ToLower().Contains("account"));
            this.userKey = "jacetest";
            this.passKey = "Jace1!";
            var searchUserBox = driver.FindElementById("Username");
            var searchKeyBox = driver.FindElementById("Password");
            searchUserBox.SendKeys(userKey);
            searchKeyBox.SendKeys(passKey);
            var submitButton = driver.FindElementByClassName("btn-primary");
            submitButton.Click();
            driver.Navigate().GoToUrl("https://powerlevel.azurewebsites.net/UserWorkouts");

            //Makes sure jacetest does not have an existing workout leading into this test so that it will always pass
            if(driver.FindElementByXPath("/html/body/div/div/a[2]").Text == "Abandon Workout")
            {
                ThenIAbandonTheSingleWorkout();
            }

            driver.Navigate().GoToUrl("https://powerlevel.azurewebsites.net/UserWorkouts/Create");
        }
        
        [Given(@"I have selected the workout I would like to create")]
        public void GivenIHaveSelectedTheWorkoutIWouldLikeToCreate()
        {
            Assert.IsTrue(driver.Url.ToLower().Contains("create"));
            String backButton = driver.FindElementByClassName("LinkColor").Text;
            Assert.IsTrue(backButton.Contains("Go Back"));
        }
        
        [When(@"I press the Start Workout button")]
        public void WhenIPressTheButton()
        {
            var workoutButton = driver.FindElementByXPath("/html/body/div/div/form/div/div[2]/div/input");
            workoutButton.Click();
            System.Threading.Thread.Sleep(2000);
        }

        [Then(@"I am taken to the Confirmation page")]
        public void ThenIAmTakenToTheConfirmationPage()
        {
            Assert.IsTrue(driver.Url.ToLower().Contains("confirmworkout"));
        }        

        [When(@"I manually redirect to the Create Free Workout page and press the Start Workout button again")]
        public void WhenIManuallyRedirectToTheCreateFreeWorkoutPageAndPressTheButtonAgain()
        {
            driver.Navigate().GoToUrl("https://powerlevel.azurewebsites.net/UserWorkouts/Create");
            String backButton = driver.FindElementByClassName("LinkColor").Text;
            Assert.IsTrue(backButton.Contains("Go Back"));
            var workoutButton = driver.FindElementByClassName("btn-primary");
            workoutButton.Click();
            System.Threading.Thread.Sleep(2000);
        }
        
        [Then(@"I am taken to the Index page")]
        public void ThenIAmTakenToTheIndexPage()
        {
            Assert.IsFalse(driver.Url.ToLower().Contains("confirmworkout"));
            Assert.IsTrue(driver.Url.ToLower().Contains("userworkouts"));
        }

        [Then(@"I abandon the single workout")]
        public void ThenIAbandonTheSingleWorkout()
        {
            var abandonButton = driver.FindElementByXPath("/html/body/div/div/a[2]");
            abandonButton.Click();
            Assert.IsTrue(driver.Url.ToLower().Contains("abandon"));
            var confirmAbandon = driver.FindElementByXPath("/html/body/div/div/div/form/div/input");
            confirmAbandon.Click();
            System.Threading.Thread.Sleep(2000);
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
