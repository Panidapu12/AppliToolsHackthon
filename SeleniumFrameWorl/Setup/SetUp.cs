using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AppliToolsHackathon
{

    public class Setup
    {
        [SetUp]
        public void beforeTest()
        {
            Configuration configuration = new Configuration();

            if (!TestContext.CurrentContext.Test.Name.Contains("DynamiContentTest"))
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
            Configuration.driver.Close();
        }

    }
}
