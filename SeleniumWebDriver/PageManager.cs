using System;
using OpenQA.Selenium;
using TestingFramework;

namespace SeleniumWebDriver
{
    public class PageManager : IPageManager
    {
        public IWebDriver Driver { get; set; }

        public PageManager(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public TPage GetPage<TPage>() where TPage : IPage, new()
        {
            var page = new TPage();
            page.Driver = Driver;
            page.Wait();
            string currentUrl = this.Driver.Url.Substring(0,this.Driver.Url.IndexOf('?') > 0 ? this.Driver.Url.IndexOf('?') : this.Driver.Url.Length - 1);
            string expectedUrl = page.Url;

            if (currentUrl == expectedUrl)
            {
                return page;
            }
            else
            {
                throw new Exception($"Expected page with URL: {expectedUrl} was not reached. Actual URL: {currentUrl}");
            }
        }

        public TPage CreatePage<TPage>() where TPage : IPage, new()
        {
            var page = new TPage();
            page.Driver = Driver;

            Driver.Navigate().GoToUrl(page.Url);
            page.Wait();

            return page;
        }
    }
}
