using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace GoogleUIBase.Pages
{
    public partial class GoogleSearchResultsPage
    {
        public void AssertFirstResultContainsText(string expectedText)
        {
            string firstResultText = this.FirstSearchResult.Text;
            Assert.AreEqual(expectedText, firstResultText, "Actual result does not contain the expected phrase.");
        }
    }
}
