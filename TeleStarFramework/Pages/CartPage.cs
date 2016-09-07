using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TeleStarFramework.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.ClassName, Using = "product-name")]
        private IWebElement productName;

        [FindsBy(How = How.Id, Using = "total_price")]
        private IWebElement totalPrice;

        [FindsBy(How = How.ClassName, Using = "cart-price")]
        private IWebElement productPrice;

        [FindsBy(How = How.Id, Using = "total_shipping")]
        private IWebElement shippingPrice;

        [FindsBy(How = How.ClassName, Using = "cart_quantity_button")]
        private IWebElement quantityAdd;

        public string ProductName()
        {
            return productName.FindElement(By.TagName("a")).Text;
        }

        public double DisplayedTotalPrice()
        {
            Regex r = new Regex("[0-9,]+");
            Match m = r.Match(totalPrice.Text);
            return Double.Parse(m.Value.Replace(",", "."));
        }

        public double TotalPrice(string productQuantity)
        {
            if (shippingPrice.Text.Contains("Livrare"))
            {
                Regex r = new Regex("[0-9,]+");
                Match m = r.Match(productPrice.Text);
                return Double.Parse(m.Value.Replace(",", ".")) * Double.Parse(productQuantity);
            }
            else {
                Regex r = new Regex("[0-9,]+");
                Match m = r.Match(productPrice.Text);
                Match n = r.Match(shippingPrice.Text);
                double fullPrice = Double.Parse(m.Value.Replace(",", ".")) * Double.Parse(productQuantity);
                double shipPrice = Double.Parse(n.Value.Replace(",", "."));
                return fullPrice + shipPrice;
            }
        }

        public void AddQuantity(string quantity)
        {
       
            for (int i = 1; i < Int32.Parse(quantity); i++)
            {
                quantityAdd.FindElement(By.TagName("input")).Click();
            }
            Thread.Sleep(2000);

        }
    }
}
