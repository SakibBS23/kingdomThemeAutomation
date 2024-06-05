using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SpecFlowBDDFramework.Pages;
using SpecFlowBDDFramework.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBDDFramework.StepDefinitions
{
    [Binding]
    public class SmartProductBoxStepDefinitions
    {
        private IWebDriver driver;
        private string adminEmail = ConfigReader.GetInstance().GetAnyPropValue("adminlogin");
        private string adminPass = ConfigReader.GetInstance().GetAnyPropValue("adminpass");

        public SmartProductBoxStepDefinitions(IWebDriver driver)
        {
            this.driver= driver;
        }
        [Given(@"At First Go to the admin page for Smart Product box plugin")]
        public void GivenAtFirstGoToTheAdminPageForSmartProductBoxPlugin()
        {
            driver.Url = ConfigReader.GetInstance().GetBaseUrl();
        }

        [When(@"Click on the login Url for login as admin in Smart product box")]
        public void WhenClickOnTheLoginUrlForLoginAsAdminInSmartProductBox()
        {
            IWebElement btn = driver.FindElement(By.XPath("//a[contains(text(),'Account')]"));
            btn.Click();
        }

        [Then(@"Give email and pass for admin login in kingdom for smart product box")]
        public void ThenGiveEmailAndPassForAdminLoginInKingdomForSmartProductBox()
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

        [Then(@"Go to admin home before configure smart product box items")]
        public void ThenGoToAdminHomeBeforeConfigureSmartProductBoxItems()
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

        [Then(@"For configure smart product box")]
        public void ThenForConfigureSmartProductBox()
        {
            var smartProductBoxconfig= new SmartProductBox(driver);
            smartProductBoxconfig.forSmartProductBoxBtn();
            smartProductBoxconfig.forConfigurationBtn();
            Thread.Sleep(3000);
            smartProductBoxconfig.forEnableSmartProductBox();
            smartProductBoxconfig.forbtnSaveSPB();
            //Assertion
            IWebElement alertAssertionCheck = driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]"));
            ClassicAssert.IsTrue(alertAssertionCheck.Displayed,"Assertion checked and its okay!");
            Thread.Sleep(5000);
        }
    }
}
