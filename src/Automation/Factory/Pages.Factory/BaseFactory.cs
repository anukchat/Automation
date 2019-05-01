using Common.Library.enums;
using Pages.Contracts;
using Selenium.Page.Repository;
using Selenium.Page.Repository.Pages;
using System;

namespace Pages.Factory
{
    public class BaseFactory
    {
        public static T GetInstance<T>(Platform tool, object param = null)
        {
            T obj = default(T);

            if (tool == Platform.Web)
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