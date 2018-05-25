using OpenQA.Selenium;

namespace GoogleUIBase.Pages
{
    public partial class GoogleSearchPage
    {
        public IWebElement SearchInput
        {
            get
            {
                return this.Driver.FindElement(By.Id("lst-ib"));
            }
        }

        public IWebElement SearchButton
        {
            get
            {
                return this.Driver.FindElement(By.Name("btnK"));
            }
        }
    }
}
