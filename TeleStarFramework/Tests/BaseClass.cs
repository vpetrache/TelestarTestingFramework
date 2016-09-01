using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleStarFramework.Utils;

namespace TeleStarFramework.Tests
{
    public class BaseClass : DriverManagementUtils
    {
        protected IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver(System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", string.Empty));
            DriverManagementUtils.NavigateToURL(ref driver);
            DriverManagementUtils.MaximizeWindow(ref driver);
            DriverManagementUtils.ReadXMLData();

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
