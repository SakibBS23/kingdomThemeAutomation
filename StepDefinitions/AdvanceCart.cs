using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using SpecFlowBDDFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        [Then(@"After login go to admin home")]
        public void ThenAfterLoginGoToAdminHome()
        {
            throw new PendingStepException();
        }

    }
}
