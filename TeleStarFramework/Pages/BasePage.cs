using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TeleStarFramework.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "logo")]
        private IWebElement logo;

        [FindsBy(How = How.XPath, Using = "//ul[@id='nav']/li[4]")]
        private IWebElement menu;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'29-well-being')]/span")]
        private IWebElement subMenu;

        [FindsBy(How = How.ClassName, Using = "shop-total")]
        private IList<IWebElement> cartTotal;

        [FindsBy(How = How.Id, Using = "shopping_cart")]
        private IWebElement cartIcon;

        public void AccessMenu()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(menu).Perform();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(subMenu));     
            subMenu.Click();
        }

        public bool LogoVisibility()
        {
            return logo.Displayed;
        }

        public string PageTitle()
        {
            return driver.Title;
        }

        public string CartPrice()
        {
            Thread.Sleep(2000);
            foreach (IWebElement element in cartTotal)
            {
                Regex x = new Regex("[0-9,]+");
                Match m = x.Match(element.Text);
                return m.Value;
            }

            return "No value found";
        }

        public void GoToCart()
        {
            cartIcon.Click();
        }
    }
}
