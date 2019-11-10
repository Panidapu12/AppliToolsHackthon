using AppliToolsHackaThon;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliToolsHackathon
{
    [TestFixture]
    public class VisualAITests : Setup
    {
        //Change V1 to V2 under Setup/Setup.CS -> BeforeTest method - >configuration.configureEnvForTests("V2"); to run tests in V1
        //Change V1 to V2 under Setup/Setup.CS -> BeforeTest method - >configuration.configureEnvForTests("AddV2"); to run tests in V1
        [Test]
        public void LoginPageUIElementsTest()
        {
            eyes.Open(Configuration.driver, AppName, TestCaseName);
            eyes.CheckWindow();
        }


        [Test]
        [TestCase("", "")]
        [TestCase("", "test")]
        [TestCase("test", "")]
        [TestCase("test", "test")]
        public void dataDrivenLogin(string username, string password)
        {
            Pages.loginPage.loginToApp(username, password);
            eyes.Open(Configuration.driver, AppName, TestCaseName);
            eyes.CheckWindow();
        }
        [Test]
        public void TableSortTest()
        {
            Pages.loginPage.loginToApp("username", "password");
            Pages.landingPage.Amount_RecentTransactions.ClickOn();
            eyes.Open(Configuration.driver, AppName, TestCaseName);
            eyes.CheckWindow();
        }

        [Test]
        public void CanvasDataValidation()
        {
            Pages.loginPage.loginToApp("test", "test");
            Pages.landingPage.ShowExpenseChartButton.ClickOn();
            eyes.Open(Configuration.driver, AppName, TestCaseName);
            eyes.CheckElement(By.Id("canvas"));
        }
        [Test]
        public void CanvasDataValidation2()
        {
            Pages.loginPage.loginToApp("test", "test");
            Pages.landingPage.ShowExpenseChartButton.ClickOn();
            Pages.landingPage.addDataSet.ClickOn();
            eyes.Open(Configuration.driver, AppName, TestCaseName);
            eyes.CheckElement(By.Id("canvas"));
        }

        [Test]
        public void DynamicContentTest()
        {
            if (Configuration.driver.Url.Contains("V2"))
            {
                Pages.loginPage.loginToApp("test", "test");
            }
            eyes.Open(Configuration.driver, AppName, TestCaseName);
            eyes.MatchLevel = Applitools.MatchLevel.Layout;
            eyes.CheckRegion(By.ClassName("element-balances"));
        }
    }
}
