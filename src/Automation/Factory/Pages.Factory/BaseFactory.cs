using API.Page.Repository;
using Common.Library.enums;
using Pages.Contracts;
using Selenium.Page.Repository;
using Selenium.Page.Repository.Pages;
using System;

namespace Pages.Factory
{
    public class BaseFactory
    {
        public static T GetInstance<T>(ToolType tool,object param=null)
        {
            T obj = default(T);

            if (tool == ToolType.API)
            {
                if (typeof(T) == typeof(IBase))
                {
                    obj = (T)Activator.CreateInstance(typeof(APIBase));
                }
            }
            else if (tool == ToolType.Selenium)
            {
                if (typeof(T) == typeof(IBase))
                {
                    obj = (T)Activator.CreateInstance(typeof(SeleniumBase));
                }
                else if (typeof(T) == typeof(ILogIn))
                {
                    obj = (T)Activator.CreateInstance(typeof(SeleniumLogInPage),param);
                }
            }

            return obj;
        }
    }
}