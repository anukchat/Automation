using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Library.Extensions
{
    public static class DriverExtensions
    {
        public static IWebElement FindElement(this ISearchContext context, By by, int timeOut = 20)
        {
            IWebElement element=null;
            try
            {
                var wait = new DefaultWait<ISearchContext>(context);
                wait.Timeout = TimeSpan.FromSeconds(timeOut);
                return wait.Until(ctx =>
                {
                    element = ctx.FindElement(by);
                    if (!element.Displayed)
                        return null;
                    return element;
                });
            }
            
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("OOPs!! Unable to find the mentioned element!");
            }
            return element;
        }

    }
}
