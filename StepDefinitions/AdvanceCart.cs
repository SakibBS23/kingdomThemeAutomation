//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using SpecFlowBDDFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpecFlowBDDFramework.StepDefinitions
{
    [Binding]
    public class AdvanceCart
    {
        private IWebDriver driver;
        private string adminEmail = ConfigReader.GetInstance().GetAnyPropValue("adminlogin");
        private string adminPass = ConfigReader.GetInstance().GetAnyPropValue("adminpass");

        public AdvanceCart(IWebDriver driver)
        {
            this.driver=driver;
        }
        [Given(@"Nevigate to the admin page")]
        public void GivenNevigateToTheAdminPage()
        {
            driver.Url = ConfigReader.GetInstance().GetBaseUrl();
        }
        [When(@"Nevigate to Click on the login url")]
        public void WhenNevigateToClickOnTheLoginUrl()
        {
            IWebElement btn = driver.FindElement(By.XPath("//a[contains(text(),'Account')]"));
            btn.Click();
            //Thread.Sleep(5000);
        }

        [Then(@"After login go to admin home")]
        public void ThenAfterLoginGoToAdminHome()
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
        [Then(@"logout link should be visible")]
        public void ThenLogoutLinkShouldBeVisible()
        {
            IWebElement AccountNamelink = driver.FindElement(By.LinkText("John Smith"));
            //Assert.IsTrue(logoutlink.Displayed, "The logout link should be visible");
            ClassicAssert.True(AccountNamelink.Displayed, "The logout link should be visible");
            
        }
        

        [Then(@"After go to admin home configure attributes")]
        public void ThenAfterGoToAdminHomeConfigureAttributes()
        {
            //for moving public store to admin page

            IWebElement btnAdministrator = driver.FindElement(By.XPath("//a[contains(text(),'Administration')]"));
            btnAdministrator.Click();
            Thread.Sleep(3000);
            IWebElement drpdwnNopStationBtn = driver.FindElement(By.XPath("//a[contains(.,'Nop Station')]"));
            drpdwnNopStationBtn.Click();
            Thread.Sleep(3000);
            IWebElement drpdwnPluginBtn = driver.FindElement(By.XPath("//a[contains(.,'Plugins')]"));
            drpdwnPluginBtn.Click();
            Thread.Sleep(3000);
            IWebElement drpdwnAdvanceCart = driver.FindElement(By.XPath("//a[contains(.,'Advance cart')]"));
            drpdwnAdvanceCart.Click();
            Thread.Sleep(3000);
            IWebElement btnConfiguration = driver.FindElement(By.XPath("(//p[text()=' Configuration'])[1]"));
            btnConfiguration.Click();
            Thread.Sleep(3000);

            //attribute access

            IWebElement ckBuynowBtn = driver.FindElement(By.XPath("(//input[@name='EnableBuyNowButton'])[1]"));
            ckBuynowBtn.Click();
            Thread.Sleep(2000);
            IWebElement ckSelectQuantityBtn = driver.FindElement(By.XPath("(//input[@name='AllowCustomersToSelectQuantityFromProductBox'])[1]"));
            ckSelectQuantityBtn.Click();
            IWebElement ckQuickViewBtn = driver.FindElement(By.XPath("(//input[@name='OpenQuickViewIfRedirectToDetailsPageRequired'])[1]"));
            ckQuickViewBtn.Click();
            IWebElement ckAddedtoCartBtn = driver.FindElement(By.XPath("(//input[@name='EnableAddedToCartNotificationPopup'])[1]"));
            ckAddedtoCartBtn.Click();

            //save button and go to public store

            IWebElement btnSave = driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
            btnSave.Click();
            Thread.Sleep(3000);
            IWebElement btnPublicStore = driver.FindElement(By.XPath("//a[contains(text(),'Public store')]"));
            btnPublicStore.Click();
            Thread.Sleep(5000);
            IWebElement gotoBestSale = driver.FindElement(By.XPath("(//div[@class='container carousel-container'])[3]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(gotoBestSale);
            actions.Perform();
            Thread.Sleep(5000);
            Actions builder = new Actions(driver);
            builder.MoveToElement(driver.FindElement(By.XPath("(//img[@alt='Picture of Panasonic 4K USD TV'])[last()]")))
            .Click().Build().Perform();
            Thread.Sleep(5000);
            IWebElement addtocartTvBtn = driver.FindElement(By.XPath("(//button[@class='button-1 add-to-cart-button'])[1]"));
            addtocartTvBtn.Click();
            Thread.Sleep(5000);
          
            
        }
    }
}
