using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDFramework.Pages
{
    public class ProductTab
    {
        private IWebDriver driver;

        public ProductTab(IWebDriver driver)
        {
            this.driver=driver;
        }
        IWebElement btnProductTab => driver.FindElement(By.XPath("//p[text()[normalize-space()='Product tab']]"));
        public void forbtnProductTab()
        {
            btnProductTab.Click();
        }
        IWebElement btnConfigurationforProductTab => driver.FindElement(By.XPath("/html/body/div[3]/aside/div/div[4]/div/div/nav/ul/li[11]/ul/li[1]/ul/li[12]/ul/li[2]/a"));
        public void forbtnConfigurationforProductTab()
        {
            btnConfigurationforProductTab.Click();
        }
        IWebElement checkEnableProductTab => driver.FindElement(By.Id("EnableProductTab"));
        public void forCheckEnableProductTab()
        {
            checkEnableProductTab.Click();
        }
        IWebElement checkEnableAjaxLoad => driver.FindElement(By.Id("EnableAjaxLoad"));
        public void forCheckEnableAjaxLoad()
        {
            checkEnableAjaxLoad.Click();
        }
        IWebElement btnSaveProductTab => driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
        public void forbtnSaveProductTab()
        {
            btnSaveProductTab.Click();
        }
    }
}
