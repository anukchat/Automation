using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Library.Helpers;
using System;

namespace Selenium.Library.Extensions
{
    public static class DriverExtensions
    {
        public static IWebElement GetElement(this ISearchContext context, By by, int timeOut = 20)
        {
            IWebElement element = null;
            try
            {
                var wait = new DefaultWait<ISearchContext>(context)
                {
                    Timeout = TimeSpan.FromSeconds(timeOut)
                };
                return wait.Until((ctx) =>
                {
                    WaitHelpers.WaitFor(() => ctx.FindElements(by).Count != 0, "Not Able to find element! ELement might not be present");
                    element = ctx.FindElement(by);
                    if (!element.Displayed)
                        return null;
                    return element;
                });
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("OOPs!! Unable to find the mentioned element! Exception: {0}", ex.Message);
            }
            return element;
        }

        public static void ClickElement(this IWebElement element, int timeout = 20)
        {
            var wait = new DefaultWait<IWebElement>(element)
            {
                Timeout = TimeSpan.FromSeconds(timeout)
            };
            wait.Until((ctx) =>
            {
                var el = element.Displayed ? element : null;
                try
                {
                    if (el != null && el.Enabled)
                    {
                        return el;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
            element.Click();
        }

        public static void EnterText(this IWebElement element, string text)
        {
            WaitHelpers.WaitFor(() => element.Displayed && element.Enabled, "Not Able to find element! ELement might not be present");
            element.SendKeys(text);
        }
    }
}