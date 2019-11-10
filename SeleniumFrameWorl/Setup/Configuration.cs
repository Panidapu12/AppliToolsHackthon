using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Applitools.Selenium;
using Applitools;

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
            if (Setup.eyes  == null)
            {
                Setup.eyes = new Eyes();
                BatchInfo bi = new BatchInfo();
                bi.Name = "Hackathon";
                Setup.eyes.Batch = bi;
                Setup.eyes.ApiKey = "kmvqkRPsxiUvHnB97E99BRhZqEXoAJ5DrRgnuXWjiatzo110";
                Setup.eyes.ForceFullPageScreenshot = true;
                Setup.eyes.MatchLevel = MatchLevel.Strict;
            }
            

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }
    }
}
