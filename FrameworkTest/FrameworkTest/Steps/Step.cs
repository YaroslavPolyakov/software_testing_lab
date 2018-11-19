using OpenQA.Selenium;

namespace FrameworkTest.Steps
{
    class Step
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void EnterCities(string cityOfDeparture, string cityOfArrival)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.EnterCityOfDeparture(cityOfDeparture);
            mainPage.EnterCityOfArrival(cityOfArrival);
        }
    }
}
