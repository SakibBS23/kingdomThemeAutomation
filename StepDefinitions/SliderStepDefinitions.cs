using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SpecFlowBDDFramework.Pages;
using SpecFlowBDDFramework.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBDDFramework.StepDefinitions
{
    [Binding]
    public class SliderStepDefinitions
    {
        private IWebDriver driver;
        private string adminEmail = ConfigReader.GetInstance().GetAnyPropValue("adminlogin");
        private string adminPass = ConfigReader.GetInstance().GetAnyPropValue("adminpass");

        public SliderStepDefinitions(IWebDriver driver)
        {
            this.driver= driver;
        }
        [Given(@"At First Go to the admin page for slider plugin")]
        public void GivenAtFirstGoToTheAdminPageForSliderPlugin()
        {
            driver.Url = ConfigReader.GetInstance().GetBaseUrl();
        }

        [When(@"Click on the login Url for login as admin in slider")]
        public void WhenClickOnTheLoginUrlForLoginAsAdminInSlider()
        {
            IWebElement btn = driver.FindElement(By.XPath("//a[contains(text(),'Account')]"));
            btn.Click();
        }

        [Then(@"Give email and pass for admin login in kingdom for slider")]
        public void ThenGiveEmailAndPassForAdminLoginInKingdomForSlider()
        {
            IWebElement txtmail = driver.FindElement(By.Id("Username"));
            txtmail.Clear();
            txtmail.SendKeys(adminEmail);
            Thread.Sleep(2000);
            IWebElement txtPass = driver.FindElement(By.Id("Password"));
            txtPass.Clear();
            txtPass.SendKeys(adminPass);
            Thread.Sleep(2000);
            IWebElement btnLogin = driver.FindElement(By.XPath("//button[@class='button-1 login-button']"));
            btnLogin.Submit();
            Thread.Sleep(3000);
        }

        [Then(@"Go to admin home before configure slider items")]
        public void ThenGoToAdminHomeBeforeConfigureSliderItems()
        {
            IWebElement btnAdministrator = driver.FindElement(By.XPath("//a[contains(text(),'Administration')]"));
            btnAdministrator.Click();
            Thread.Sleep(3000);
            IWebElement drpdwnNopStationBtn = driver.FindElement(By.XPath("//a[contains(.,'Nop Station')]"));
            drpdwnNopStationBtn.Click();
            Thread.Sleep(3000);
            IWebElement drpdwnPluginBtn = driver.FindElement(By.XPath("//a[contains(.,'Plugins')]"));
            drpdwnPluginBtn.Click();
            Thread.Sleep(3000);
        }

        [Then(@"For configure slider")]
        public void ThenForConfigureSlider()
        {
            var sliderConfig = new Slider(driver);
            sliderConfig.forbtnSlider();
            sliderConfig.forbtnConfigurationforSlider();
            sliderConfig.forCheckEnableSlider();
            sliderConfig.forCheckEnableAjaxLoad();
            sliderConfig.forbtnSaveSlider();
            Thread.Sleep(3000);
            IWebElement alertAssertionCheck = driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]"));
            ClassicAssert.IsTrue(alertAssertionCheck.Displayed, "Assertion checked and its okay!");
            Thread.Sleep(5000);
        }
    }
}
