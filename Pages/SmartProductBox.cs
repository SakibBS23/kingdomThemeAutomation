using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDFramework.Pages
{
    public class SmartProductBox
    {
        private IWebDriver driver;

        public SmartProductBox(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement btnSmartProductBox => driver.FindElement(By.XPath("//a[contains(.,'Smart product box')]"));
        public void forSmartProductBoxBtn()
        {
            btnSmartProductBox.Click();
        }
        IWebElement btnConfiguration => driver.FindElement(By.XPath("/html/body/div[3]/aside/div/div[4]/div/div/nav/ul/li[11]/ul/li[1]/ul/li[11]/ul/li[1]/a/p"));
        public void forConfigurationBtn()
        {
            btnConfiguration.Click();
        }
        IWebElement checkBoxEnableSmartProductBox => driver.FindElement(By.Id("EnableSmartProductBox"));
        public void forEnableSmartProductBox()
        {
            checkBoxEnableSmartProductBox.Click();
        }
        IWebElement btnSaveforSmartProductBox => driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
        public void forbtnSaveSPB()
        {
            btnSaveforSmartProductBox.Click();
        }
        //IWebElement AlertAssertionCheck => driver.FindElement(By.XPath("//div[contains(@class,'alert alert-success')]"));

    }
}
