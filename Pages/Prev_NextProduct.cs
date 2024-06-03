using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDFramework.Pages
{
    public class Prev_NextProduct
    {
        private IWebDriver driver;

        public Prev_NextProduct(IWebDriver driver)
        {
            this.driver=driver;
        }
        IWebElement drpdwnPrevNextBtn => driver.FindElement(By.XPath("//p[text()[normalize-space()='Prev/Next product']]"));
        IWebElement btnPrevNextConfiguration => driver.FindElement(By.XPath("/html/body/div[3]/aside/div/div[4]/div/div/nav/ul/li[11]/ul/li[1]/ul/li[6]/ul/li[1]/a/p"));
        IWebElement txtPrevNextSettings => driver.FindElement(By.XPath("//h1[text()[normalize-space()='Prev/Next product settings']]"));
        IWebElement BtnEnableloop => driver.FindElement(By.XPath("(//input[@name='EnableLoop'])[1]"));
        IWebElement BtnSaveforPrevNext => driver.FindElement(By.XPath("//button[@class='btn btn-primary']"));
        IWebElement BtnPrevNextPublicStore => driver.FindElement(By.XPath("(//a[@class='nav-link'])[3]"));
        public void prevnextbtn()
        {
            drpdwnPrevNextBtn.Click();
        }
        public void prevnextConfig()
        {
            btnPrevNextConfiguration.Click();
        }
        public void enableloop()
        {
            BtnEnableloop.Click();
        }
        public void savePrevNext()
        {
            BtnSaveforPrevNext.Click();
        }
        public void prevNextPublicStore()
        {
            BtnPrevNextPublicStore.Click();
        }
    }
}
