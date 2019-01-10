using System;
using OpenQA.Selenium;

namespace FrameworkTestStep2.Step
{
    class Step
    {
        IWebDriver _driver;
        public void InitBrowser()
        {
            _driver = Driver.Driver.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.Driver.CloseBrowser();
        }

        public bool SelectFirstTrip(string departureName, string destinationName)
        {
            Page.MainPage mainPage = new Page.MainPage(_driver);
            mainPage.InsertFirstTrip(departureName, destinationName);

            return true;
        }

        public bool SelectFirstTripDate()
        {
            Page.MainPage mainPage = new Page.MainPage(_driver);
            mainPage.ChooseFirstTripDate();
            return true;
        }

        public bool SelectPastDatesForBothSides()
        {
            Page.MainPage selectPage = new Page.MainPage(_driver);
            return selectPage.SelectPastDatesForBothSides();
        }

        public void SelectDatesForBothSides()
        {
            Page.MainPage selectPage = new Page.MainPage(_driver);
            selectPage.SelectDatesForBothSides();
        }

        public bool StartSearchTickets()
        {
            Page.MainPage mainPage = new Page.MainPage(_driver);
            try
            {
                mainPage.ClickOnSearchTickets();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void SelectPage()
        {
            Page.MainPage selectPage = new Page.MainPage(_driver);
            selectPage.OpenPage();
        }

        public bool SelectPassengers()
        {
            Page.MainPage mainPage = new Page.MainPage(_driver);
            mainPage.ClickPassengersMenu();
            mainPage.SelectPassengerAdult();
            for (int i = 0; i < 2; i++)
                mainPage.SelectPassengerBaby();
            if (Int32.Parse(mainPage.GetCountBaby()) <= Int32.Parse(mainPage.GetCountAdult()))
            {
                return true;
            }
            else
                return false;
        }


        public bool SelectPassengersWithoutAdults()
        {
            Page.MainPage mainPage = new Page.MainPage(_driver);
            mainPage.ClickPassengersMenu();
            mainPage.SelectPassengerBaby();
            if (Int32.Parse(mainPage.GetCountAdult()) == 0)
                return true;
            else return false;
        }

        public bool SelectDepartureDateInThePast()
        {
            Page.MainPage selectPage = new Page.MainPage(_driver);
            return selectPage.SelectDateInThePast();
        }
        public bool CheckEqualNames()
        {
            Page.MainPage selectPage = new Page.MainPage(_driver);
            if (selectPage.GetFirstCity() == selectPage.GetSecondCity())
                return true;
            else
                return false;
        }

        public bool SelectMorePassengers()
        {
            Page.MainPage selectPage = new Page.MainPage(_driver);
            selectPage.ClickPassengersMenu();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    selectPage.SelectPassengerAdult();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckSortByAmount()
        {
            Page.ResultPage selectPage = new Page.ResultPage(_driver);

            var first = selectPage.GetFirstAmount().Split(new char[] { ' ' });
            var second = selectPage.GetSecondAmount().Split(new char[] { ' ' });
            var third = selectPage.GetThirdAmount().Split(new char[] { ' ' });
            double amountFirst = Double.Parse(first[0] + first[1]);
            double amountSecond = Double.Parse(second[0] + second[1]);
            double amountThird = Double.Parse(third[0] + third[1]);
            if (amountFirst <= amountSecond && amountSecond <= amountThird)
                return true;
            return false;
        }

        public bool CheckSortByTime()
        {
            Page.ResultPage selectPage = new Page.ResultPage(_driver);

            string[] first = selectPage.GetFirstTime().Split(new char[] { ' ' });
            string[] second = selectPage.GetSecondTime().Split(new char[] { ' ' });
            string[] third = selectPage.GetThirdTime().Split(new char[] { ' ' });
            double firstTimeMinutes = Double.Parse(first[3].Replace("ч", "")) * 60 + Double.Parse(first[4].Replace("м", ""));
            double secondTimeMinutes = Double.Parse(second[3].Replace("ч", "")) * 60 + Double.Parse(second[4].Replace("м", ""));
            double thirdTimeMinutes = Double.Parse(third[3].Replace("ч", "")) * 60 + Double.Parse(third[4].Replace("м", ""));
            if (firstTimeMinutes <= secondTimeMinutes && secondTimeMinutes <= thirdTimeMinutes)
                return true;
            else
                return false;
        }
        public void SelectSortByTime()
        {
            Page.ResultPage selectPage = new Page.ResultPage(_driver);
            selectPage.StartSort();
        }
        public void SelectTicket()
        {
            Page.ResultPage selectPage = new Page.ResultPage(_driver);
            selectPage.ClickTicket();
        }

        public void SelectHistory()
        {
            Page.MainPage selectPage = new Page.MainPage(_driver);
            selectPage.SelectHistory();
        }
    }
}
