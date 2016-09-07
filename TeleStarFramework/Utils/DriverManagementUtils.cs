using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TeleStarFramework.Deserializer;

namespace TeleStarFramework.Utils
{
    public class DriverManagementUtils
    {
        private static NameValueCollection testData = new NameValueCollection();
        public static NameValueCollection TestData
        {

            get
            {
                return testData;
            }

        }


        public static void NavigateToURL(ref IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("URL"));
        }

        public static void MaximizeWindow(ref IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void ManageWait(ref IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Int32.Parse(ConfigurationManager.AppSettings.Get("WaitTime"))));
        }

        public static void ReadXMLData()
        {

            XmlSerializer deserializer = new XmlSerializer(typeof(TestXML));
            TextReader reader = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", string.Empty) + "TestDataFanelFramework.xml");
            var obj = deserializer.Deserialize(reader);
            var testXml = obj as TestXML;
            foreach (var testSet in testXml.TestSets)
            {
                if (testSet.TestName.Equals(TestContext.CurrentContext.Test.MethodName))
                {
                    foreach (var parameter in testSet.Parameters)
                    {
                        testData.Add(parameter.Name, parameter.Value);
                    }
                    break;
                }
            }
            reader.Close();

        }

    }

}
