using NUnit.Framework;
using System;
using TeleStarFramework.Pages;
using TeleStarFramework.Tests;
using TeleStarFramework.Utils;

namespace TeleStarFramework
{
    [TestFixture]
    public class UnitTest1 : BaseClass

    {
        [Test]
        public void AddingFreeDeliveryProduct()
        {
            var homepage = new BasePage(driver);
            Assert.IsTrue(homepage.LogoVisibility());
            StringAssert.Contains(DriverManagementUtils.TestData.Get("BasePageTitle"), homepage.PageTitle());
            homepage.AccessMenu();

            StringAssert.Contains(DriverManagementUtils.TestData.Get("CategoryPageTitle"), homepage.PageTitle());

            var categoryPage = new CategoryPage(driver);
            StringAssert.Contains(DriverManagementUtils.TestData.Get("BreadCrumbs").Replace(" ", string.Empty), categoryPage.CheckBreadcrumbs());

            categoryPage.clickSelectedProduct(DriverManagementUtils.TestData.Get("ProductName"));
            var productPage = new ProductPage(driver);

            StringAssert.Contains(DriverManagementUtils.TestData.Get("FullProductName"), productPage.PageTitle());
            StringAssert.Contains(DriverManagementUtils.TestData.Get("FullProductName"), productPage.ProductName());

            productPage.AddToCart();
            StringAssert.Contains(productPage.ProductPrice(), productPage.CartPrice());

            productPage.GoToCart();

            var cartPage = new CartPage(driver);
            StringAssert.Contains(DriverManagementUtils.TestData.Get("BasketPageTitle"), cartPage.PageTitle());
            StringAssert.Contains(DriverManagementUtils.TestData.Get("FullProductName").ToUpper(), cartPage.ProductName());

            cartPage.AddQuantity(DriverManagementUtils.TestData.Get("ProductQuantity"));
            Assert.AreEqual(cartPage.TotalPrice(DriverManagementUtils.TestData.Get("ProductQuantity")), cartPage.DisplayedTotalPrice());
        }

        [Test]
        public void AddingPaidDeliveryProduct()
        {
            var homepage = new BasePage(driver);
            Assert.IsTrue(homepage.LogoVisibility());
            homepage.AccessMenu();

            var categoryPage = new CategoryPage(driver);
            categoryPage.clickSelectedProduct(DriverManagementUtils.TestData.Get("SecondProductName"));

            var productPage = new ProductPage(driver);
            productPage.AddToCart();
            StringAssert.Contains(productPage.ProductPrice(), productPage.CartPrice());
            productPage.GoToCart();

            var cartPage = new CartPage(driver);
            cartPage.AddQuantity(DriverManagementUtils.TestData.Get("SecondProductQuantity"));
            Assert.AreEqual(cartPage.TotalPrice(DriverManagementUtils.TestData.Get("SecondProductQuantity")), cartPage.DisplayedTotalPrice());
        }
    }
}
