using OpenQA.Selenium;
using SpecFlowBDDFramework.Model;
using SpecFlowBDDFramework.Pages;
using SpecFlowBDDFramework.Utility;
using SpecFlowBDDFramework.Utility.DataProvider;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowBDDFramework.StepDefinitions
{
    [Binding]
    public class CarouselsStepDefinitions
    {
        private IWebDriver driver;
        private string adminEmail = ConfigReader.GetInstance().GetAnyPropValue("adminlogin");
        private string adminPass = ConfigReader.GetInstance().GetAnyPropValue("adminpass");
        //private string rootPath;

        public CarouselsStepDefinitions(IWebDriver driver)
        {
            this.driver=driver;
        }
        [Given(@"At First Go to the admin page for Carousel")]
        public void GivenAtFirstGoToTheAdminPageForCarousel()
        {
            driver.Url = ConfigReader.GetInstance().GetBaseUrl();
        }

        [When(@"Click on the login Url for login as admin in Carousel")]
        public void WhenClickOnTheLoginUrlForLoginAsAdminInCarousel()
        {
            IWebElement btn = driver.FindElement(By.XPath("//a[contains(text(),'Account')]"));
            btn.Click();
        }

        [Then(@"Give email and pass for admin login in kingdom")]
        public void ThenGiveEmailAndPassForAdminLoginInKingdom()
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

        [Then(@"Go to admin home and configure Carousel items")]
        public void ThenGoToAdminHomeAndConfigureCarouselItems()
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
            var btnCarouseloptions = new Carousel(driver);
            btnCarouseloptions.ForbtnCarousel();
            btnCarouseloptions.forbtnCarouselDetail();
            btnCarouseloptions.forbtnAddnewCarousel();

            string jsonFilePathCarousel = "TestData\\CarouselData.json";

            string _jsonFilePathCarousel = Path.Combine(rootPath, jsonFilePathCarousel);
            Console.WriteLine(_jsonFilePathCarousel);
            CarouselAddItemModel carouselAddItemModel = null;
            try
            {
                carouselAddItemModel = JSONFileReader.ReadJsonFile<CarouselAddItemModel>(_jsonFilePathCarousel);
                Console.WriteLine(carouselAddItemModel);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            btnCarouseloptions.fortxtCarouselName(carouselAddItemModel.CarouselName);
            btnCarouseloptions.forCheckbtnDisplayTitle();
            btnCarouseloptions.fortxtTitle(carouselAddItemModel.CarouselTitle);
            btnCarouseloptions.forDrpdwnProductSource(carouselAddItemModel.ProductSource);
            btnCarouseloptions.forbtnSaveandContinue();
            Thread.Sleep(5000);
            btnCarouseloptions.forDrpdwnSelectWidgetZone(carouselAddItemModel.WidgetZone);
            btnCarouseloptions.forbtnAddWidgetZone();
            btnCarouseloptions.forbtnSaveCarousel();
            btnCarouseloptions.forBtnCarouselPublicStore();
            Thread.Sleep(3000);
        }
    }
}
