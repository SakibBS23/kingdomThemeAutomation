using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SpecFlowBDDFramework.Pages;
using SpecFlowBDDFramework.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBDDFramework.StepDefinitions
{
    [Binding]
    public class ProductTabStepDefinitions
    {
        private IWebDriver driver;
        private string adminEmail = ConfigReader.GetInstance().GetAnyPropValue("adminlogin");
        private string adminPass = ConfigReader.GetInstance().GetAnyPropValue("adminpass");

        public ProductTabStepDefinitions(IWebDriver driver)
        {
            this.driver=driver;
        }
        [Given(@"At First Go to the admin page for Product tab plugin")]
        public void GivenAtFirstGoToTheAdminPageForProductTabPlugin()
        {
            driver.Url = ConfigReader.GetInstance().GetBaseUrl();

        }

        [When(@"Click on the login Url for login as admin in product tab")]
        public void WhenClickOnTheLoginUrlForLoginAsAdminInProductTab()
        {
            IWebElement btn = driver.FindElement(By.XPath("//a[contains(text(),'Account')]"));
            btn.Click();
        }

        [Then(@"Give email and pass for admin login in kingdom for product tab")]
        public void ThenGiveEmailAndPassForAdminLoginInKingdomForProductTab()
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

        [Then(@"Go to admin home before configure product tab items")]
        public void ThenGoToAdminHomeBeforeConfigureProductTabItems()
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

        [Then(@"For configure product tab")]
        public void ThenForConfigureProductTab()
        {
            var productTabConfig = new ProductTab(driver);
            productTabConfig.forbtnProductTab();
            productTabConfig.forbtnConfigurationforProductTab();
            productTabConfig.forCheckEnableProductTab();
            productTabConfig.forCheckEnableAjaxLoad();
            productTabConfig.forbtnSaveProductTab();
            Thread.Sleep(3000);
            IWebElement alertAssertionCheck = driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]"));
            ClassicAssert.IsTrue(alertAssertionCheck.Displayed, "Assertion checked and its okay!");
            Thread.Sleep(5000);
        }
    }
}
