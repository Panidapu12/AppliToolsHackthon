using System;
using System.Collections.Generic;
using System.Text;
using AppliToolHackathon;
using SeleniumExtras.PageObjects;

namespace AppliToolsHackathon
{
    public static class Pages
    {
        public static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Configuration.driver, page);
            return page;
        }
        public static LoginPage loginPage
        {
            get
            { return GetPage<LoginPage>(); }
        }
        public static LandingPage landingPage
        {
            get
            {
                return GetPage<LandingPage>();
            }
        }
    }
}
