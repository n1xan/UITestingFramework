using System;
using System.Drawing;
using GoogleUIBase.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumWebDriver
{
    public abstract class BaseTest
    {
        public IWebDriver driver;
        internal PageManager PageManager { get; private set; }

        protected string baseURL = "http://www.google.bg";
        
        public void DriverInit()
        {
            //InternetExplorerOptions options = new InternetExplorerOptions();
            //options.IgnoreZoomLevel = true;
            //driver = new InternetExplorerDriver(options);

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Size = new Size(1200, 2000);
            this.PageManager = new PageManager(driver);
        }
        
        public void DriverDispose(string testName)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile($"{testName}.png", ScreenshotImageFormat.Png);
            this.driver.Dispose();
        }
    }
}
