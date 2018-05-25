using System;
using GoogleUIBase.Base;
using GoogleUIBase.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TestingFramework;

namespace SeleniumWebDriver
{
    [TestClass]
    public class WebDiverTestClass : BaseTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            base.DriverInit();
        }

        [TestMethod]
        public void GoogleVerifyFirstResult()
        {
            var searchPage = this.PageManager.CreatePage<GoogleSearchPage>(this.baseURL);
            searchPage.SearchInput.SendKeys("selenium webdriver");
            searchPage.SearchInput.Submit();

            var resultsPage = this.PageManager.GetPage<GoogleSearchResultsPage>();
            string firstResultText = resultsPage.FirstSearchResult.Text;
            
            Assert.AreEqual("Selenium WebDriver", firstResultText);
        }

        [TestMethod]
        public void GoogleVerifyResultExists()
        {
            var searchPage = this.PageManager.CreatePage<GoogleSearchPage>(this.baseURL);
            searchPage.SearchInput.SendKeys("selenium");
            searchPage.SearchInput.Submit();

            string expectedResult = "Selenium - Web Browser Automation";

            var resultsPage = this.PageManager.GetPage<GoogleSearchResultsPage>();
            var firstResult = resultsPage.GetResultByTitleContains(expectedResult);

            Assert.IsNotNull(firstResult, $"'{expectedResult}' result was not found.");
            Assert.AreEqual(expectedResult, firstResult.Text);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            base.DriverDispose(this.TestContext.TestName);
        }
    }
}
