using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace AppliToolsHackaThon
{
    public static class Extensions
    {
        public static void ClickOn(this IWebElement element)
        {
            try
            {
                if (element.IsPresent())
                {
                    element.Click();
                }
                else
                {
                    Assert.Fail("Unable to find element");
                }
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        public static bool IsPresent(this IWebElement element)
        {
            bool elementVisible = false;
            var time = Stopwatch.StartNew();
            int timeOut = 120000;
            while (time.ElapsedMilliseconds < timeOut)
            {
                try
                {
                    elementVisible = element.Displayed;
                }
                catch (Exception)
                {
                    elementVisible = false;
                    Thread.Sleep(2000);
                }
                if (elementVisible)
                {
                    break;
                }
            }
            return elementVisible;
        }

        public static void enterText(this IWebElement element, string text)
        {
            try
            {
                if (element.IsPresent())
                {
                    if (element.Enabled)
                    {
                        element.Clear();
                        element.SendKeys(text);
                    }
                    else
                    {
                        Assert.Fail("Element is not eanbled");
                    }

                }
                else
                {
                    Assert.Fail("Element is not visible");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.Message);
            }

        }

        public static string getText(this IWebElement element)
        {
            string text = "";
            try
            {
                if (element.IsPresent())
                {
                    text = element.Text;
                }
                else
                {
                    Assert.Fail("Element not visible");
                }
            }
            catch (Exception e)
            {

                Assert.Fail(e.Message);
            }
            return text;



        }

    }
}
