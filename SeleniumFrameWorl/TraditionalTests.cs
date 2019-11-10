using AppliToolsHackaThon;
using NUnit.Framework;
using System;


namespace AppliToolsHackathon

{
    [TestFixture]
    public class TraditionalTests
    {
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
                    Assert.That(loginpage.loginButton.GetCssValue("background-color") == "rgb(4, 123, 248)", "checking the backgound color of login button " + loginpage.loginButton.GetCssValue("background-color"));
            });
        }
           
    }
}
