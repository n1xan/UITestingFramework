using GoogleUIBase.Base;
using OpenQA.Selenium;
using TestingFramework;

namespace GoogleUIBase.Pages
{
    public partial class GoogleSearchPage : IPage
    {
        public string Url { get => "/"; }

        public IWebDriver Driver { get; set; }

        public GoogleSearchPage()
        {
        }

        public GoogleSearchPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void Navigate()
        {
            this.Driver.Navigate().GoToUrl( BaseData.BaseUrl + this.Url);
        }

        public void Wait()
        {
            this.Driver.WaitUntilDisplayed(By.Id("lst-ib"));
        }
    }
}
