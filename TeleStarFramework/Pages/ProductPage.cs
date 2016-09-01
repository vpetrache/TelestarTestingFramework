using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TeleStarFramework.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {

        }
        [FindsBy(How = How.XPath, Using = "//div[@class='product-name']/h2")]
        private IWebElement productName;

        [FindsBy(How = How.Name, Using = "Submit")]
        private IWebElement addToCart;

        [FindsBy(How = How.Id, Using = "our_price_display2")]
        private IWebElement productPrice;

        public string ProductName()
        {
            return productName.Text;
        }

        public void AddToCart()
        {
            addToCart.Click();
        }

        public string ProductPrice()
        {
            Regex r = new Regex("[0-9,]+");
            Match m = r.Match(productPrice.Text);
            return m.Value;
        }
        
    }
}
