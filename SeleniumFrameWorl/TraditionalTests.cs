using AppliToolsHackaThon;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AppliToolsHackathon

{
    [TestFixture]
    public class TraditionalTests : Setup
    {

        //Change V1 to V2 under Setup/Setup.CS -> BeforeTest method - >configuration.configureEnvForTests("V2"); to run tests in V1
        //Change V1 to V2 under Setup/Setup.CS -> BeforeTest method - >configuration.configureEnvForTests("AddV2"); to run tests in V1
        [Test]
        public void LoginPageUIElementsTest()
        {
            var loginpage = Pages.loginPage;
                Assert.Multiple(() =>
                {
                    Assert.That(loginpage.loginFormLabel.IsPresent() == true, "Checking if login form label exists");
                    Assert.That(loginpage.loginFormLabel.getText() == "Login Form", "Checking the title of login form label");
                    Assert.That(loginpage.UserName.IsPresent() == true, "Checking if username text box pesent");
                    Assert.That(loginpage.userNameLabel.IsPresent() == true, "Checking if username label exists");
                    Assert.That(loginpage.PassWord.IsPresent() == true, "checking if password text field present");
                    Assert.That(loginpage.passWordLabel.IsPresent() == true, "Checking if password label exists");
                    Assert.That(loginpage.UserName.GetAttribute("placeholder") == "Enter your username", "Checking the username placeholder value");
                    Assert.That(loginpage.PassWord.GetAttribute("placeholder") == "Enter your password", "Checking the password placeholder value");
                    Assert.That(loginpage.RememberMeCheckBox.IsPresent() == true, "Checking if remember me check box exists");
                    Assert.That(loginpage.RememberMeCheckBox.getText() =="Remember Me", "Checking if remember me text present");
                    Assert.That(loginpage.allImages.Count == 4, "checking if all images are loaded");
                    Assert.That(loginpage.faceBookIcon.IsPresent() == true, "checking if Facebook icon exists");
                    Assert.That(loginpage.TwitterIcon.IsPresent() == true, "checking if twitter icon present");
                    Assert.That(loginpage.LinkedInIcon.IsPresent() == true, "Checking if linked icon present");
                    Assert.That(loginpage.loginButton.IsPresent() == true, "Checking if login button present");
                    Assert.That(loginpage.loginButton.GetCssValue("background-color") == "rgba(4, 123, 248, 1)", "checking the backgound color of login button " + loginpage.loginButton.GetCssValue("background-color"));
            });
        }

        [Test]
        [TestCase("","")]
        [TestCase("","test")]
        [TestCase("test","")]
        [TestCase("test","test")]
        public void dataDrivenLogin(string username, string password)
        {
            var loginPage = Pages.loginPage;
            loginPage.loginToApp(username, password);
            Assert.Multiple(() =>
            {
                if (username =="" && password =="")
                {
                    Assert.That(loginPage.LoginErrorAlert.getText() == "Both Username and Password must be present", "Validating login when username and password are incorrect");
                }
                else if(username =="" && password !="")
                {
                    Assert.That(loginPage.LoginErrorAlert.getText() == "Username must be present", "Validating login with incorrect username");
                }
                else if (username !="" && password =="")
                {
                    Assert.That(loginPage.LoginErrorAlert.getText() == "Password must be present", "Validating login with invalid password");
                }
                else if (username != "" && password !="")

                {
                    Assert.That(Pages.landingPage.ShowExpenseChartButton.IsPresent() == true, "Validating if show expenses chart button exists");
                }
            });
        }
         
        
        [Test]
        public void TableSortTest()
        {
            Pages.loginPage.loginToApp("test", "test");
            List<double> originalData = getAmountFromRecentTransTable();
            Pages.landingPage.Amount_RecentTransactions.ClickOn();
            List<double> sortedData = getAmountFromRecentTransTable();
            originalData.Sort();
            Assert.Multiple(() => {
                for (int i = 0; i < originalData.Count; i++)
                {
                    //TestContext.WriteLine(sortedData[i]);
                    Assert.AreEqual(originalData[i], sortedData[i], "Comparing the amount in ascending order0");
                }
            }
            );
                
           

        }

        public static List<double> getAmountFromRecentTransTable()
        {
            List<double> amountlist = new List<double>();

            List<string> dataFromtable = Pages.landingPage.RecentTransactionsTable.getColumnDataFromATableByIdex(4, true);
            foreach (var item in dataFromtable)
            {
                string amount = item.Replace("USD", "");
                amount = amount.Trim();
                amount = amount.Replace(" ", "");
                amountlist.Add(double.Parse(amount));
            }
            return amountlist;

        }


        [Test]
        public void CanvasDataValidation()
        {
           // Pages.loginPage.loginToApp("test", "test");
            //Pages.landingPage.ShowExpenseChartButton.ClickOn();
            //Unable to validate bar chart data since it is a canvas
            //Canvas is rendering data as image, so could not read the data to validate using traditional selenium.
            //Pages.landingPage.addDataSet.ClickOn();
        }

        [Test]
        public void DynamicContentTest()
        {
            if (Configuration.driver.Url.Contains("V2"))
            {
                Pages.loginPage.loginToApp("test", "test");
            }
            
            Assert.Multiple(() =>
            {
                Assert.That(Pages.landingPage.flashSale1.IsPresent() == true, "Checking if flashhsale1 exists");
                Assert.That(Pages.landingPage.flashSale2.IsPresent() == true, "Checking if flashsale2 exists");
            });
        }
    }
}
