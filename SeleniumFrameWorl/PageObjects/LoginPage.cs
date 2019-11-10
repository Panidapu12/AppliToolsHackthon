using System;
using System.Collections.Generic;
using System.Text;
using AppliToolsHackaThon;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace AppliToolsHackathon
{
    public class LoginPage
    {


        [FindsBy(How = How.XPath, Using = "/html/body/div/div/h4")]
        public IWebElement loginFormLabel { get; set; }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PassWord { get; set; }
        [FindsBy(How = How.Id, Using = "log-in")]
        public IWebElement loginButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "img")]

        public IList<IWebElement> allImages { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/form/div[1]/label")]
        public IWebElement userNameLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/form/div[2]/label")]
        public IWebElement passWordLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/form/div[3]/div[1]/label")]
        public IWebElement RememberMeCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/form/div[3]/div[2]/a[1]/img")]
        public IWebElement TwitterIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/form/div[3]/div[2]/a[2]/img")]
        public IWebElement faceBookIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div/div/form/div[3]/div[2]/a[3]/img")]
        public IWebElement LinkedInIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'random_id')]")]
        public IWebElement LoginErrorAlert { get; set; }

        public void loginToApp(string username, string password)
        {
            Pages.loginPage.UserName.enterText(username);
            Pages.loginPage.PassWord.enterText(password);
            Pages.loginPage.loginButton.ClickOn();
        }
    }
}
