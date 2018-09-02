using System;
using System.Linq;
using OpenQA.Selenium;

namespace GoogleUIBase.Pages
{
    public partial class GoogleSearchResultsPage
    {
        public IWebElement SearchInput
        {
            get
            {
                return this.Driver.FindElement(By.Id("lst-ib"));
            }
        }

        public IWebElement FirstSearchResult
        {
            get
            {
                return this.Driver.FindElements(By.XPath("//h3/a")).FirstOrDefault();
            }
        }

        public IWebElement SearchCorrectionPhrase
        {
            get
            {
                return this.Driver.FindElement(By.Id("fprsl"));
            }
        }

        public IWebElement GetResultByTitleContains(string textContains)
        {
            var allResults = this.Driver.FindElements(By.XPath("//h3/a"));
            Console.WriteLine("Results found: " + allResults.Count);
            return allResults.FirstOrDefault(res => res.Text.ToLower().Contains(textContains.ToLower()));
        }
    }
}