using Common.Library.enums;
using Pages.Contracts;
using Selenium.Page.Repository;
using Selenium.Page.Repository.Pages;
using System;

namespace Pages.Factory
{
    public class BaseFactory
    {
        public static T GetInstance<T>(ToolType tool, object param = null)
        {
            T obj = default(T);

            if (tool == ToolType.Selenium)
            {
                if (typeof(T) == typeof(IBase))
                {
                    obj = (T)Activator.CreateInstance(typeof(SeleniumBase),param);
                }
                else if (typeof(T) == typeof(ILogIn))
                {
                    obj = (T)Activator.CreateInstance(typeof(SeleniumLogInPage), param);
                }
            }

            return obj;
        }
    }
}