using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.Library.Helpers
{
    public class WaitHelpers
    {
        public static bool WaitFor(Func<bool> waitFunction, string timeoutMessage)
        {
            return WaitFor<bool>(waitFunction, timeoutMessage);
        }

        public static T WaitFor<T>(Func<T> waitFunction, string timeoutMessage)
        {
            return WaitFor<T>(waitFunction, TimeSpan.FromSeconds(5), timeoutMessage);
        }

        public static T WaitFor<T>(Func<T> waitFunction, TimeSpan timeout, string timeoutMessage)
        {
            DateTime endTime = DateTime.Now.Add(timeout);
            T value = default(T);
            Exception lastException = null;
            while (DateTime.Now < endTime)
            {
                try
                {
                    value = waitFunction();
                    if (typeof(T) == typeof(bool))
                    {
                        if ((bool)(object)value)
                        {
                            return value;
                        }
                    }
                    else if (value != null)
                    {
                        return value;
                    }

                    System.Threading.Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    // Swallow for later re-throwing
                    lastException = e;
                }
            }

            if (lastException != null)
            {
                throw new WebDriverException("Operation timed out", lastException);
            }

            Assert.Fail("Condition timed out: " + timeoutMessage);
            return default(T);
        }
    }
}
