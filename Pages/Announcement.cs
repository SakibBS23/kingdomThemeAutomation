using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDFramework.Pages
{
    public class Announcement
    {
        private IWebDriver driver;

        public Announcement(IWebDriver driver)
        {
            this.driver=driver;
        }
        IWebElement txtName => driver.FindElement(By.XPath("(//input[contains(@class,'form-control text-box')])[1]"));
        IWebElement txtTitle => driver.FindElement(By.XPath("(//input[contains(@class,'form-control text-box')])[2]"));
        IWebElement txtDescription => driver.FindElement(By.Id("Description_ifr"));
        IWebElement txtDisplayorder => driver.FindElement(By.XPath("(//input[@class='form-control'])[1]"));
        public void txtNameField(string Name)
        {
            txtName.SendKeys(Name);
        }
        public void txtTitleField(string Title)
        {
            txtTitle.SendKeys(Title);
        }
        public void txtDescriptionField(string Description)
        {
            txtDescription.SendKeys(Description);
        }
        public void textDisplayorderField(string DisplayOrder)
        {
            txtDisplayorder.Clear();
            txtDisplayorder.SendKeys(DisplayOrder);
        }
    }
}
