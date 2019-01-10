using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FrameworkTestStep2.Page
{
    class MainPage
    {
        private const string Url = "https://go2see.ru/";
        private readonly IWebDriver _driver;

        #region Passengers
        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[5]/div/div[1]/div/div/div/div")]
        private IWebElement _passengerButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div[2]/div/div[2]/div[2]/button[2]")]
        private IWebElement _passengerAdult;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[2]/div/div[2]/div[2]/button[1]")]
        private IWebElement _unPassengerAdult;

        [FindsBy(How = How.XPath, Using = "//*[@id='app']/div[2]/div/div[3]/div[2]/button[2]")]
        private IWebElement _passengerChild;

        [FindsBy(How = How.XPath, Using = "//*[@id='flightSearchInfantsPlus']")]
        private IWebElement passengerBaby;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[2]/div/div[2]/div[2]/span")]
        private IWebElement countAdult;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[2]/div/div[4]/div[2]/span")]
        private IWebElement countBaby;

        #endregion

        #region Cities

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[1]/div/div/div/div[1]/div[1]/input")]
        private IWebElement from_name_click;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[1]/div/div/div/div[1]/div[1]/input")]
        private IWebElement from_name;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[2]/div/div/div/div[1]/div/input")]
        private IWebElement to_name_click;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[2]/div/div/div/div[1]/div/input")]
        private IWebElement to_name;

        #endregion

        #region Dates
        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[3]/div/div[1]/div/div/div/div/input")]
        private IWebElement open_calendar_to;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[1]/div/div/div/div[2]/table/tbody/tr[3]/td[4]/button")]
        private IWebElement date_to;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[13]/main/div/div/div[1]/div/div/div[1]/div[1]/div/div[4]/div/div/div/div/div/div[1]/input")]
        private IWebElement open_calendar_back;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[1]/div[2]/div/div/div[2]/table/tbody/tr[4]/td[4]/button")]
        private IWebElement date_back;


        //for both sides flight mode
        [FindsBy(How = How.PartialLinkText, Using = "История поисков")]
        private IWebElement history;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[1]/div/div/div/div[2]/table/tbody/tr[2]/td[3]/button")]
        private IWebElement date_to_past;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[1]/div[2]/div/div/div[2]/table/tbody/tr[1]/td[4]/button")]
        private IWebElement date_back_past;

        #endregion

        [FindsBy(How = How.XPath, Using = "//*[@id=\"app\"]/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[2]/button")]
        private IWebElement searchButton;

        public MainPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this._driver, this);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(Url);
        }

        public void ClickOnSearchTickets()
        {
            searchButton.Click();
            Thread.Sleep(10000);
        }

        public void InsertFirstTrip(string departure, string destination)
        {
            from_name_click.Click();
            from_name.SendKeys(departure);
            Thread.Sleep(1500);
            from_name.SendKeys(Keys.ArrowDown);
            from_name.SendKeys(Keys.Enter);
            to_name_click.Click();
            to_name.SendKeys(destination);
            Thread.Sleep(1500);
            to_name.SendKeys(Keys.ArrowDown);
            to_name.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }

        public void ChooseFirstTripDate()
        {
            open_calendar_to.Click();
            Thread.Sleep(1000);
            date_to.Click();
        }

        public void ClickPassengersMenu()
        {
            _passengerButton.Click();
        }
        public void SelectPassengerAdult()
        {
            _passengerAdult.Click();
        }

        public void SelectHistory()
        {
            history.Click();
            Thread.Sleep(2000);
        }

        public void SelectPassengerBaby()
        {
            Thread.Sleep(1000);
            passengerBaby.Click();
        }

        public bool UnSelectPassengerAdult()
        {
            try
            {
                _unPassengerAdult.Click();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public string GetCountAdult()
        {
            string count = countAdult.Text;
            return count;
        }

        public string GetCountBaby()
        {
            string count = countBaby.Text;
            return count;
        }


        public bool SelectPastDatesForBothSides()
        {
            open_calendar_to.Click();
            Thread.Sleep(1000);
            try
            {
                date_to_past.Click();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void SelectDatesForBothSides()
        {
            open_calendar_to.Click();
            Thread.Sleep(1000);
            date_to.Click();
            open_calendar_back.Click();
            Thread.Sleep(1000);
            date_back.Click();
        }

        public bool SelectDateInThePast()
        {
            open_calendar_to.Click();
            Thread.Sleep(1000);
            date_to.Click();
            try
            {
                Thread.Sleep(3000);
                open_calendar_back.Click();
                Thread.Sleep(1000);
                date_back_past.Click();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public string GetFirstCity()
        {
            return from_name.GetAttribute("value");
        }

        public string GetSecondCity()
        {
            return to_name.GetAttribute("value");
        }
    }
}
