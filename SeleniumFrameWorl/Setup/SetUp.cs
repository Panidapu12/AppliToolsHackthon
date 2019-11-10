using System;
using System.Collections.Generic;
using System.Text;
using Applitools.Selenium;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AppliToolsHackathon
{

    public class Setup
    {
        public static string TestCaseName;
        public static string AppName = "ACM Demo App";
        public static Eyes eyes;
        [SetUp]
        public void beforeTest()
        {
            Configuration configuration = new Configuration();
            TestCaseName = TestContext.CurrentContext.Test.Name;
            if (!TestContext.CurrentContext.Test.Name.Contains("DynamicContentTest"))
            {
                configuration.configureEnvForTests("V2");
            }
            else
            {
                configuration.configureEnvForTests("AddV2");
            }

            Configuration.driver.Navigate().GoToUrl(Configuration.applicationUrl);
        }
        [TearDown]
        public void afterTest()
        {
            if (eyes.IsOpen)
            {
                try
                {
                    eyes.Close();
                    eyes.AbortIfNotClosed();
                }
                catch (Exception e)
                {

                    Configuration.driver.Close();
                    Assert.Fail(e.Message);
                }
                
            }
            Configuration.driver.Close();


        }

    }
}
