using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeleStarFramework.Pages
{
    public class CategoryPage : BasePage
    {
        public CategoryPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//div[@class='breadcrumbs']/ul")]
        private IWebElement breadcrumbs;

        //[FindsBy(How = How.ClassName, Using = "product-name")]
        [FindsBy(How = How.ClassName, Using = "name")]
        private IList<IWebElement> products;

        //[FindsBy(How = How.ClassName, Using = "list")]
        //private IWebElement listFiltering;

        public string CheckBreadcrumbs()
        {
            return breadcrumbs.Text.Replace(" ", string.Empty).Replace("&", string.Empty);
        }

        public void clickSelectedProduct(string productName)
        {
            //listFiltering.Click();
            foreach (IWebElement element in products)
            {
                var product = element.FindElement(By.TagName("span"));
                if (product.Text.Trim().Contains(productName.Trim()))
                {
                    Actions action = new Actions(driver);
                    action.MoveToElement(product).Perform();
                    product.Click();
                    return;
                }
            }
        }
    }
}
