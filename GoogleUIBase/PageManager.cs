using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TestingFramework;

namespace GoogleUIBase.Base
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
            Uri currentUri = new Uri(this.Driver.Url);

            if (currentUri.AbsolutePath == page.Url)
            {
                return page;
            }
            else
            {
                throw new Exception($"Expected page with URL: {page.Url} was not reached. Actual URL: {currentUri.AbsolutePath}");
            }            
        }

        public TPage CreatePage<TPage>(string baseUrl) where TPage : IPage, new()
        {
            var page = new TPage();
            page.Driver = Driver;

            Driver.Navigate().GoToUrl(baseUrl + page.Url);
            page.Wait();

            return page;
        }
    }
}
