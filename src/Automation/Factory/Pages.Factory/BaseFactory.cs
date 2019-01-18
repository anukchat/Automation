using API.Page.Repository;
using Common.Library.enums;
using Pages.Contracts;
using Selenium.Page.Repository;
using System;

namespace Pages.Factory
{
    public class BaseFactory
    {
        public static T GetInstance<T>(ToolType tool)
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
            }

            return obj;
        }
    }
}