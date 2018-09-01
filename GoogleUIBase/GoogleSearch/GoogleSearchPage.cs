using GoogleUIBase.Base;
using OpenQA.Selenium;
using TestingFramework;

namespace GoogleUIBase.Pages
{
    public partial class GoogleSearchPage : BaseGooglePage, IPage
    {
        public string Url { get => this.BaseUri.AbsoluteUri; }
        
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
            this.Driver.Navigate().GoToUrl( this.BaseUri.AbsoluteUri + this.Url);
            this.Wait();
        }

        public void Wait()
        {
            this.Driver.WaitUntilDisplayed(By.Id("lst-ib"));
        }

        public void PerformSearchWithText(string textToSearch)
        {
            this.SearchInput.SendKeys(textToSearch);
            this.SearchInput.Submit();
        }
    }
}
