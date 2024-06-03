using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowBDDFramework.Model;
using SpecFlowBDDFramework.Pages;
using SpecFlowBDDFramework.Utility;
using SpecFlowBDDFramework.Utility.DataProvider;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowBDDFramework.StepDefinitions
{
    [Binding]
    public class AnnouncementStepDefinitions
    {
        private IWebDriver driver;
        private string adminEmail = ConfigReader.GetInstance().GetAnyPropValue("adminlogin");
        private string adminPass = ConfigReader.GetInstance().GetAnyPropValue("adminpass");
        private Announcement txtFieldName;
        private Announcement txtFieldTitle;
        private Announcement txtDescription;
        private Announcement txtDisplayOrder;

        public AnnouncementStepDefinitions(IWebDriver driver)
        {
            this.driver= driver;
        }
        [Given(@"Go to the admin page")]
        public void GivenGoToTheAdminPage()
        {
            driver.Url = ConfigReader.GetInstance().GetBaseUrl();
        }

        [When(@"Click on the login Url")]
        public void WhenClickOnTheLoginUrl()
        {
            IWebElement btn = driver.FindElement(By.XPath("//a[contains(text(),'Account')]"));
            btn.Click();
        }

        [Then(@"Give email and pass for login")]
        public void ThenGiveEmailAndPassForLogin()
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

        [Then(@"Make sure that the username should be visible after login")]
        public void ThenMakeSureThatTheUsernameShouldBeVisibleAfterLogin()
        {
            IWebElement AccountNamelink = driver.FindElement(By.LinkText("John Smith"));
            ClassicAssert.IsTrue(AccountNamelink.Displayed, "The logout link should be visible");
        }

        [Then(@"Go to admin home and configure announcement item")]
        public void ThenGoToAdminHomeAndConfigureAnnouncementItem()
        {
            //for read json rootpath
            string rootPath = HelperUtility.GetInstance().GetProjectRootPath();

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
            IWebElement drpdwnAnnouncementBtn = driver.FindElement(By.XPath("//p[text()[normalize-space()='Announcement']]"));
            drpdwnAnnouncementBtn.Click();
            IWebElement BtnAnnouncementItems = driver.FindElement(By.XPath("//p[text()=' Announcement items']"));
            BtnAnnouncementItems.Click();
            //Assertion used
            IWebElement headerAnnouncementItem = driver.FindElement(By.XPath("//h1[text()[normalize-space()='Announcement items']]"));
            ClassicAssert.IsTrue(headerAnnouncementItem.Displayed, "this is announcement item page");
            //add new button
            IWebElement btnAddmew = driver.FindElement(By.XPath("//a[contains(.,'Add new')]"));
            btnAddmew.Click();
            Thread.Sleep(3000);
            string jsonFilePathAnnouncement = "TestData\\AnnouncementData.json";

            string _jsonFilePathAnnouncement = Path.Combine(rootPath, jsonFilePathAnnouncement);
            Console.WriteLine(_jsonFilePathAnnouncement);
            AnnouncementAddItemModel announcementAddItem = null;
            try
            {
                announcementAddItem = JSONFileReader.ReadJsonFile<AnnouncementAddItemModel>(_jsonFilePathAnnouncement);
                Console.WriteLine(announcementAddItem.Name);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            txtFieldName = new Announcement(driver);
            txtFieldName.txtNameField(announcementAddItem.Name);
            txtFieldTitle = new Announcement(driver);
            txtFieldTitle.txtTitleField(announcementAddItem.Title);
            Thread.Sleep(3000);
            txtDescription = new Announcement(driver);
            txtDescription.txtDescriptionField(announcementAddItem.Description);
            txtDisplayOrder = new Announcement(driver);

            txtDisplayOrder.textDisplayorderField(announcementAddItem.DisplayOrder);
            Thread.Sleep(2000);
            IWebElement btnSave = driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[1]"));
            btnSave.Click();
            
        }

        [Then(@"Make changes on the configuration part")]
        public void ThenMakeChangesOnTheConfigurationPart()
        {
            Thread.Sleep(3000);
            IWebElement btnConfiguration = driver.FindElement(By.XPath("(//p[text()=' Configuration'])[2]"));
            btnConfiguration.Click();
            IWebElement checkEnable = driver.FindElement(By.XPath("(//input[@class='check-box'])[1]"));
            checkEnable.Click();
            IWebElement checkAllowCustomerToMinimize = driver.FindElement(By.XPath("(//input[@name='AllowCustomersToMinimize'])[1]"));
            checkAllowCustomerToMinimize.Click();
            IWebElement checkAllowCustomerToClose = driver.FindElement(By.XPath("(//input[@name='AllowCustomersToClose'])[1]"));
            checkAllowCustomerToClose.Click();
            IWebElement btnSaveAnnouncement = driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
            btnSaveAnnouncement.Click();
            IWebElement btnPublicStore = driver.FindElement(By.XPath("(//a[@class='nav-link'])[3]"));
            btnPublicStore.Click();
            Thread.Sleep(3000);
            IWebElement btnminimize = driver.FindElement(By.XPath("(//i[@class='icon icon-down-arrow'])[2]"));
            btnminimize.Click();
            Thread.Sleep(2000);
            btnminimize.Click();
            Thread.Sleep(2000);
            IWebElement btnClose = driver.FindElement(By.XPath("(//i[@class='icon icon-close'])[2]"));
            btnClose.Click();
        }
    }
}
