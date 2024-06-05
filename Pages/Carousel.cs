using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpecFlowBDDFramework.Pages
{
    public class Carousel
    {
        private IWebDriver driver;

        public Carousel(IWebDriver driver)
        {
            this.driver=driver;
        }
        IWebElement btnCarousel => driver.FindElement(By.XPath("//p[text()[normalize-space()='Carousel']]"));
        IWebElement btnCarouselsdeatils => driver.FindElement(By.XPath("//p[text()=' Carousels']"));
        IWebElement exceptionCheck => driver.FindElement(By.XPath("//h1[text()[normalize-space()='Carousels']]"));
        IWebElement BtnAddNewCarousel => driver.FindElement(By.XPath("//a[contains(.,'Add new')]"));
        IWebElement txtCarouselName => driver.FindElement(By.XPath("(//input[contains(@class,'form-control text-box')])[1]"));
        IWebElement checkbtnDisplayTitle => driver.FindElement(By.XPath("(//input[@name='DisplayTitle'])[1]"));
        IWebElement txtTitle => driver.FindElement(By.XPath("(//input[contains(@class,'form-control text-box')])[2]"));
        IWebElement drpdwnProductSource => driver.FindElement(By.Id("ProductSourceTypeId"));
        IWebElement btnSaveandCotinue => driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[2]"));
        IWebElement DrpdwnSelectWidgetzone => driver.FindElement(By.Id("AddWidgetZoneModel_WidgetZone"));
        IWebElement btnAddWidgetZone => driver.FindElement(By.XPath("//button[text()='Add widget zone']"));
        IWebElement btnSaveCarousel => driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[1]"));
        IWebElement btnCarouselPublicStore => driver.FindElement(By.XPath("(//a[@class='nav-link'])[3]"));
        public void ForbtnCarousel()
        {
            btnCarousel.Click();
        }
        public void forbtnCarouselDetail()
        {
            btnCarouselsdeatils.Click();
        }
        public void forbtnAddnewCarousel()
        {
            BtnAddNewCarousel.Click();
        }
        public void fortxtCarouselName(string carouselName)
        {
            txtCarouselName.SendKeys(carouselName);
        }
        public void forCheckbtnDisplayTitle()
        {
            checkbtnDisplayTitle.Click();
        }
        public void fortxtTitle(string CarouselTitle)
        {
            txtTitle.SendKeys(CarouselTitle);
        }
        public void forDrpdwnProductSource(string ProductSource)
        {
            drpdwnProductSource.SendKeys(ProductSource);
        }
        public void forbtnSaveandContinue()
        {
            btnSaveandCotinue.Click();
        }
        public void forDrpdwnSelectWidgetZone(string WidgetZone)
        {
            /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => DrpdwnSelectWidgetzone);*/
            /*Actions actions = new Actions(driver);
            actions.MoveToElement(DrpdwnSelectWidgetzone);
            actions.Perform();*/

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", DrpdwnSelectWidgetzone);

            /* DrpdwnSelectWidgetzone.Clear();
             DrpdwnSelectWidgetzone.SendKeys(WidgetZone);*/
            SelectElement selectOption = new SelectElement(DrpdwnSelectWidgetzone);
            selectOption.SelectByText(WidgetZone);
        }
        public void forbtnAddWidgetZone()
        {
            btnAddWidgetZone.Click();
        }
        public void forbtnSaveCarousel()
        {
            btnSaveCarousel.Click();
        }
        public void forBtnCarouselPublicStore()
        {
            btnCarouselPublicStore.Click();
        }
    }
}
