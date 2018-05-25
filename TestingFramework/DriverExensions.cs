using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestingFramework
{
    public static class DriverExensions
    {
        public static void WaitUntilDisplayed(this IWebDriver driver, By locator, double timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drvr => drvr.FindElement(locator).Displayed);
        }

        public static void WaitUntilEnabled(this IWebDriver driver, By locator, double timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drvr => drvr.FindElement(locator).Enabled);
        }
    }
}
