using System.Threading;
using NUnit.Framework;

namespace FrameworkTestStep2.Test
{
    [TestFixture]
    class Test
    {
        private readonly Step.Step _steps = new Step.Step();
        private const string CityMoscow = "Москва";
        private const string CityBarselona = "Барселона";
        private const string CityParis = "Париж";
        private const string CityPiter = "Санкт-Петербург";
        private bool _status;


        [SetUp]
        public void Init()
        {
            _steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            _steps.CloseBrowser();
        }


        //Test #1
        [Test]
        public void WhenNotInputData()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityMoscow, CityBarselona);
            //steps.SelectDatesForBothSides();
            Thread.Sleep(1000);
            _steps.StartSearchTickets();
            _steps.SelectTicket();

            Assert.AreEqual(false, _status);
        }

        //Test #2
        [Test]
        public void WhenSecondFlightEarlierThenFirst()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityMoscow, CityBarselona);
            _status = _steps.SelectPastDatesForBothSides();

            //if set the date for second flight is impossible 
            Assert.AreEqual(false, _status);
        }

        //Test #3
        [Test]
        public void WhenBabyMoreThenAdult()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityBarselona, CityMoscow);
            _status = _steps.SelectPassengers();
            //if count of adults more or equal count if babies
            Assert.AreEqual(true, _status);
        }

        //Test #4
        [Test]
        public void CheckSortOfSearchResult()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityMoscow, CityBarselona);
            //steps.SelectFirstTripDate();
            _status = _steps.StartSearchTickets();
            //System.Threading.Thread.Sleep(5000);
            _steps.SelectSortByTime();
            //Thread.Sleep(8000);
            _status = _steps.CheckSortByTime();

            Assert.AreEqual(_status, true);
        }

        //Test #5
        [Test]
        public void WhenBabyWithoutAnyAdult()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityBarselona, CityMoscow);
            _status = _steps.SelectPassengersWithoutAdults();
            //if count of babies equal count of adults
            Assert.AreEqual(false, _status);
        }

        //Test #6
        [Test]
        public void WhenFlightDateYesterday()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityBarselona, CityMoscow);
            _status = _steps.SelectDepartureDateInThePast();
            _status = _steps.StartSearchTickets();
            Assert.AreNotEqual(true, _status);
        }

        //Test #7
        [Test]
        public void DistinationEqualOrigin()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityMoscow, CityMoscow);
            _status = _steps.CheckEqualNames();
            _steps.StartSearchTickets();
            Assert.AreEqual(true, _status);
        }

        //Test #8
        [Test]
        public void CheckHistory()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityMoscow, CityBarselona);
            //steps.SelectDatesForBothSides();
            Thread.Sleep(1000);
            _steps.StartSearchTickets();

            _steps.SelectPage();
            _steps.SelectFirstTrip(CityParis, CityPiter);
            //steps.SelectDatesForBothSides();
            Thread.Sleep(1000);
            _steps.StartSearchTickets();
            Thread.Sleep(2000);
            _steps.SelectHistory();

            Assert.AreEqual(false, _status);
        }

        [Test]
        public void CheckSortAmountOfSearchResult()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityPiter, CityParis);
            _status = _steps.StartSearchTickets();
            //Thread.Sleep(8000);
            _status = _steps.CheckSortByAmount();

            Assert.AreEqual(_status, true);
        }

        //Test #10
        [Test]
        public void WhenPassageersMoreThenSits()
        {
            _steps.SelectPage();
            _steps.SelectFirstTrip(CityMoscow, CityBarselona);
            _status = _steps.SelectMorePassengers();
            Assert.AreEqual(false, _status);
        }
    }
}
