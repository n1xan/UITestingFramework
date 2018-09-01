using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumWebDriver
{
    public abstract class BaseTest
    {
        public IWebDriver driver;
        public PageManager PageManager { get; private set; }
        
        public void DriverInit(Device device)
        {
            switch (device)
            {
                case Device.InternetExplorer:
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.IgnoreZoomLevel = true;
                    driver = new InternetExplorerDriver(ieOptions);
                    break;
                case Device.HeadlessChrome:
                    ChromeOptions hChOptions = new ChromeOptions();
                    hChOptions.AddArgument("--headless");
                    driver = new ChromeDriver(hChOptions);
                    driver.Manage().Window.Size = new Size(1200, 2000);
                    break;
                case Device.Chrome:
                    ChromeOptions chOptions = new ChromeOptions();
                    driver = new ChromeDriver(chOptions);
                    driver.Manage().Window.Maximize();
                    break;
                case Device.HeadlessFirefox:
                    throw new NotImplementedException();
                case Device.Firefox:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
            
            this.PageManager = new PageManager(driver);
        }
        
        public void DriverDispose(string testName, bool hasPassed)
        {
            if (hasPassed)
            {
                string fileName = $"{testName}.png";
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Png);
                Console.WriteLine(fileName);
            }
            this.driver.Close();
            this.driver.Dispose();
        }
    }
}
