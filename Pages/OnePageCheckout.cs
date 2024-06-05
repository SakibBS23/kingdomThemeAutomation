using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDFramework.Pages
{
    public class OnePageCheckout
    {
        private IWebDriver driver;

        public OnePageCheckout(IWebDriver driver)
        {
            this.driver=driver;
        }
        IWebElement btnOPC => driver.FindElement(By.XPath("//p[text()[normalize-space()='Opc']]"));
        public void forbtnOPC()
        {
            btnOPC.Click();
        }
        IWebElement btnConfigurationforOPC => driver.FindElement(By.XPath("/html/body/div[3]/aside/div/div[4]/div/div/nav/ul/li[11]/ul/li[1]/ul/li[14]/ul/li[1]/a/p"));
        public void forbtnConfigurationforOPC()
        {
            btnConfigurationforOPC.Click();
        }
        IWebElement checkEnableOPC => driver.FindElement(By.Id("EnableOnePageCheckout"));
        public void forCheckEnableOPC()
        {
            checkEnableOPC.Click();
        }
        IWebElement btnSaveOPC => driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
        public void forbtnSaveOPC()
        {
            btnSaveOPC.Click();
        }
    }
}
