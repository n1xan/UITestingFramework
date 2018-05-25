using GoogleUIBase.Base;
using OpenQA.Selenium;
using TestingFramework;

namespace GoogleUIBase.Pages
{
    public partial class GoogleSearchResultsPage : IPage
    {
        public string Url { get => "/search"; }

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
            this.Driver.Navigate().GoToUrl(BaseData.BaseUrl + this.Url);
        }

        public void Wait()
        {
            this.Driver.WaitUntilEnabled(By.Id("lst-ib"));
        }
    }
}
