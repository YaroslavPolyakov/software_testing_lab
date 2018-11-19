using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkTest.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://go2see.ru/";

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[2]/button")]
        private IWebElement buttonSearchTicket;

        [FindsBy(How = How.Id, Using = "//*[@id='app']/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[1]/div/div/div/div[1]/div[1]")]
        private IWebElement city_from;

        [FindsBy(How = How.Id, Using = "//*[@id='app']/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[2]/div/div/div/div[1]/div")]
        private IWebElement city_to;

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void EnterCityOfDeparture(string departureCity)
        {
            city_from.SendKeys(departureCity);
        }

        public void EnterCityOfArrival(string arrivalCity)
        {
            city_to.SendKeys(arrivalCity);
        }

        public void ClickSearchTicket()
        {
            buttonSearchTicket.Click();
        }
    }
}