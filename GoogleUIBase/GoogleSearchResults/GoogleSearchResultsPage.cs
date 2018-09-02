using System;
using GoogleUIBase.Base;
using OpenQA.Selenium;
using TestingFramework;

namespace GoogleUIBase.Pages
{
    public partial class GoogleSearchResultsPage : BaseGooglePage, IPage
    {
        public string Url { get => this.BaseUri.AbsoluteUri + "search"; }

        public IWebDriver Driver { get; set; }

        public GoogleSearchResultsPage()
        {
        }

        public GoogleSearchResultsPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void Navigate()
        {
            this.Driver.Navigate().GoToUrl(this.BaseUri.AbsoluteUri + this.Url);
        }

        public void Wait()
        {
            this.Driver.WaitUntilEnabled(By.Id("lst-ib"));
        }
    }
}