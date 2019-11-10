using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace AppliToolsHackathon
{
    public class Configuration
    {
        public static IWebDriver driver;
        public static string applicationUrl;
        public void configureEnvForTests(string version)
        {
            driver = new ChromeDriver();

            if (version == "V1")
            {
                applicationUrl = "https://demo.applitools.com/hackathon.html";
            }
            else if (version == "V2")
            {
                applicationUrl = "https://demo.applitools.com/hackathonV2.html";
            }
            else if (version == "AddV1")
            {
                applicationUrl = "https://demo.applitools.com/hackathonApp.html?showAd=true";
            }
            else
            {
                applicationUrl = "https://demo.applitools.com/hackathonV2.html?showAd=true";
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
        }
    }
}
