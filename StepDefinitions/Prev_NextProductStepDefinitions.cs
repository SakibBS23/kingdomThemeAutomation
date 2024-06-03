using OpenQA.Selenium;
using SpecFlowBDDFramework.Pages;
using SpecFlowBDDFramework.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBDDFramework.StepDefinitions
{
    [Binding]
    public class Prev_NextProductStepDefinitions
    {
        private IWebDriver driver;
        private string adminEmail = ConfigReader.GetInstance().GetAnyPropValue("adminlogin");
        private string adminPass = ConfigReader.GetInstance().GetAnyPropValue("adminpass");

        public Prev_NextProductStepDefinitions(IWebDriver driver)
        {
            this.driver=driver;
        }
        [Given(@"At First Go to the admin page")]
        public void GivenAtFirstGoToTheAdminPage()
        {
            driver.Url = ConfigReader.GetInstance().GetBaseUrl();
        }

        [When(@"Click on the login Url for login as admin")]
        public void WhenClickOnTheLoginUrlForLoginAsAdmin()
        {
            IWebElement btn = driver.FindElement(By.XPath("//a[contains(text(),'Account')]"));
            btn.Click();
        }

        [Then(@"Give email and pass for admin login")]
        public void ThenGiveEmailAndPassForAdminLogin()
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

        [Then(@"Go to admin home and configure announcement items")]
        public void ThenGoToAdminHomeAndConfigureAnnouncementItems()
        {
            //for find xpath and elements
            IWebElement btnAdministrator = driver.FindElement(By.XPath("//a[contains(text(),'Administration')]"));
            btnAdministrator.Click();
            Thread.Sleep(3000);
            IWebElement drpdwnNopStationBtn = driver.FindElement(By.XPath("//a[contains(.,'Nop Station')]"));
            drpdwnNopStationBtn.Click();
            Thread.Sleep(3000);
            IWebElement drpdwnPluginBtn = driver.FindElement(By.XPath("//a[contains(.,'Plugins')]"));
            drpdwnPluginBtn.Click();
            Thread.Sleep(3000);
            var btnprevnextBtn = new Prev_NextProduct(driver);
            btnprevnextBtn.prevnextbtn();
            Thread.Sleep(2000);
            btnprevnextBtn.prevnextConfig();
            btnprevnextBtn.enableloop();
            btnprevnextBtn.savePrevNext();
            btnprevnextBtn.prevNextPublicStore();
        }
    }
}
