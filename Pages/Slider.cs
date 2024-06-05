using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDFramework.Pages
{
    public class Slider
    {
        private IWebDriver driver;

        public Slider(IWebDriver driver)
        {
            this.driver=driver;
        }
        IWebElement btnSlider => driver.FindElement(By.XPath("//p[text()[normalize-space()='Slider']]"));
        public void forbtnSlider()
        {
            btnSlider.Click();
        }
        IWebElement btnConfigurationforSlider => driver.FindElement(By.XPath("/html/body/div[3]/aside/div/div[4]/div/div/nav/ul/li[11]/ul/li[1]/ul/li[13]/ul/li[2]/a/p"));
        public void forbtnConfigurationforSlider()
        {
            btnConfigurationforSlider.Click();
        }
        IWebElement checkEnableSlider => driver.FindElement(By.Id("EnableSlider"));
        public void forCheckEnableSlider()
        {
            checkEnableSlider.Click();
        }
        IWebElement checkEnableAjaxLoad => driver.FindElement(By.Id("EnableAjaxLoad"));
        public void forCheckEnableAjaxLoad()
        {
            checkEnableAjaxLoad.Click();
        }
        IWebElement btnSaveSlider => driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
        public void forbtnSaveSlider()
        {
            btnSaveSlider.Click();
        }
    }
}
