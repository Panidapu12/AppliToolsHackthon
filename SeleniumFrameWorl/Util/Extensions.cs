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
            int timeOut = 10000;
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

        public static List<string> getColumnDataFromATableByIdex(this IWebElement element, int indexOfcoloumn, bool isTableHasHeader)
        {
            List<string> amountlist = new List<string>();
            try
            {
                var rowElements = element.FindElements(By.TagName("tr"));
                if (isTableHasHeader)
                {
                    for (int i = 1; i < rowElements.Count; i++)
                    {
                        var cellEelements = rowElements[i].FindElements(By.TagName("td"));
                        amountlist.Add(cellEelements[indexOfcoloumn].getText());
                    }
                }
                else
                {
                    foreach (var item in rowElements)
                    {
                        var cellEelements = item.FindElements(By.TagName("td"));
                        amountlist.Add(cellEelements[indexOfcoloumn].getText());
                    }
                }

            }
            catch (Exception)
            {

               
            }

            return amountlist;
        }

    }
}
