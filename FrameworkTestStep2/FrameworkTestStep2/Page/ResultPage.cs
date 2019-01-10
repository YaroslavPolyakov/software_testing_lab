using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkTestStep2.Page
{
    class ResultPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[13]/main/div/div/div[2]/div/div/div/div[2]/div[2]/div[1]/div[2]")]
        private IWebElement _sortByTime;

        [FindsBy(How = How.ClassName, Using = "flight-leg__duration")]
        private IWebElement _firstFlightTime;

        [FindsBy(How = How.ClassName, Using = "flight-leg__duration")]
        private IWebElement _secondFlightTime;

        [FindsBy(How = How.ClassName, Using = "flight-leg__duration")]
        private IWebElement _thirdFlightTime;

        [FindsBy(How = How.ClassName, Using = "price-compare__good")]
        private IWebElement _firstFlightAmount;

        [FindsBy(How = How.ClassName, Using = "price-compare__good")]
        private IWebElement _secondFlightAmount;

        [FindsBy(How = How.ClassName, Using = "price-compare__good")]
        private IWebElement _thirdFlightAmount;

        [FindsBy(How = How.PartialLinkText, Using = "Выбрать")]
        private IWebElement _selectTicket;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[13]/main/div/div/div[3]/div/div[2]/div[2]/div/div[4]/div/div[2]/button")]
        private IWebElement _reservation;

        public ResultPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            Thread.Sleep(8000);
            //IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"app\"]/div[17]/main/div/div/div[2]/div/div/div/div[2]/div[2]/div[1]/div[1]")));
        }

        public void StartSort()
        {
            _sortByTime.Click();
        }

        public string GetFirstTime()
        {
            return _firstFlightTime.Text;
        }

        public string GetSecondTime()
        {
            return _secondFlightTime.Text;
        }

        public string GetThirdTime()
        {
            return _thirdFlightTime.Text;
        }

        public string GetFirstAmount()
        {
            return _firstFlightAmount.Text;
        }

        public string GetSecondAmount()
        {
            return _secondFlightAmount.Text;
        }

        public string GetThirdAmount()
        {
            return _thirdFlightAmount.Text;
        }

        public void ClickTicket()
        {
            _selectTicket.Click();
            Thread.Sleep(10000);
            _reservation.Click();
        }

    }
}
