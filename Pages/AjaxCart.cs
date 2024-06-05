using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDFramework.Pages
{
    public class AjaxCart
    {
        private IWebDriver driver;

        public AjaxCart(IWebDriver driver)
        {
            this.driver=driver;
        }
        IWebElement btnAjaxCart => driver.FindElement(By.XPath("//p[text()[normalize-space()='Ajax cart']]"));
        public void forbtnAjaxCart()
        {
            btnAjaxCart.Click();
        }
        IWebElement btnConfigurationforAjaxCart => driver.FindElement(By.XPath("/html/body/div[3]/aside/div/div[4]/div/div/nav/ul/li[11]/ul/li[1]/ul/li[15]/ul/li[1]/a/p"));
        public void forbtnConfigurationforAjaxCart()
        {
            btnConfigurationforAjaxCart.Click();
        }
        IWebElement checkEnableAjaxCart => driver.FindElement(By.Id("EnableAjaxCartPlugin"));
        public void forCheckEnableAjaxCart()
        {
            checkEnableAjaxCart.Click();
        }
        IWebElement btnSaveAjaxCart => driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
        public void forbtnSaveAjaxCart()
        {
            btnSaveAjaxCart.Click();
        }
    }
}
