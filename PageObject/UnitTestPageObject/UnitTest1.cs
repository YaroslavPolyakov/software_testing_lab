using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestPageObject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver Driver;

        [TestInitialize]
        public void TestMethod()
        {
            Driver = new ChromeDriver();
        }

        [TestCleanup]
        public void SetupTest()
        {
            Driver.Quit();
        }

        [TestMethod]
        public void SearchTicketWithoutAgreement()
        {
            Search search = new Search(Driver);
            bool actual = search.SearchAndClick();
            search.ValidateResult(actual);
        }
    }
}
