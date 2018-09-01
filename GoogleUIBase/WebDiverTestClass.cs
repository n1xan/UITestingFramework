using GoogleUIBase.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumWebDriver
{
    [TestClass]
    public class WebDiverTestClass : BaseTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            // Select Test Device and initialize the Driver
            base.DriverInit(Device.Chrome);
        }

        [TestMethod]
        public void GoogleVerifyFirstResult()
        {
            string searchPhrase = "selenium webdriver";
            string expectedResult = "Selenium WebDriver";

            var searchPage = this.PageManager.CreatePage<GoogleSearchPage>();
            searchPage.PerformSearchWithText(searchPhrase);

            var resultsPage = this.PageManager.GetPage<GoogleSearchResultsPage>();
            resultsPage.AssertFirstResultContainsText(expectedResult);
        }

        [TestMethod]
        public void GoogleVerifyResultExists()
        {
            string searchPhrase = "selenium";
            string expectedResult = "Selenium - Web Browser Automation";

            var searchPage = this.PageManager.CreatePage<GoogleSearchPage>();
            searchPage.PerformSearchWithText(searchPhrase);

            var resultsPage = this.PageManager.GetPage<GoogleSearchResultsPage>();
            var firstResult = resultsPage.GetResultByTitleContains(expectedResult);

            resultsPage.AssertFirstResultContainsText(expectedResult);
        }

        [TestMethod]
        public void GoogleVerifySearchPhraseCorrection()
        {
            string searchPhrase = "C# Develper";
            string expectedCorrection = "C# Developer";

            var searchPage = this.PageManager.CreatePage<GoogleSearchPage>();
            searchPage.PerformSearchWithText(searchPhrase);

            var resultsPage = this.PageManager.GetPage<GoogleSearchResultsPage>();
            var actualSearchCorrection = resultsPage.SearchCorrectionPhrase.Text;

            Assert.AreEqual(expectedCorrection, actualSearchCorrection, "Search correction does not match the expected value.");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            base.DriverDispose(
                this.TestContext.TestName, 
                this.TestContext.CurrentTestOutcome == UnitTestOutcome.Passed);
        }
    }
}
