using OpenQA.Selenium;

namespace Selenium.Library.ObjectRepository.WebRepository
{
    public static class LogInLocator
    {
        #region Locators: ID

        public static By LogInUserNameBoxID => By.Id("login_username");
        public static By LogInPasswordBoxID => By.Id("login_password");

        #endregion Locators: ID

        #region Locators: XPath

        public static By LogInButtonXPath => By.XPath("//*[@id=\"login\"]/div[4]/input");

        #endregion Locators: XPath

        #region Locators: CSSSelector

        public static By DisplayedUserCSSSelector => By.CssSelector(".usertext");

        #endregion Locators: CSSSelector
    }
}