using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace UnitTestPageObject
{
    public class Search
    {
        IWebDriver driver;

        public Search(IWebDriver webDriver)
        {
            driver = webDriver;
            driver.Manage().Window.Maximize();
            PageFactory.InitElements(driver,this);
        }

        public bool SearchAndClick()
        {
            bool actual;

            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "https://go2see.ru/";

                driver.FindElement(By.XPath(@"//*[@id='app']/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[1]/div/div/div/div[1]/div[1]")).Click();
                IWebElement from = driver.SwitchTo().ActiveElement();
                from.SendKeys("Москва");
                Thread.Sleep(1000);
                from.SendKeys(Keys.ArrowDown);
                Thread.Sleep(1000);
                from.SendKeys(Keys.Enter);

                driver.FindElement(By.XPath(@"//*[@id='app']/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[1]/div/div[2]/div/div/div/div[1]/div")).Click();
                IWebElement to = driver.SwitchTo().ActiveElement();
                to.SendKeys("Барселона");
                Thread.Sleep(1000);
                to.SendKeys(Keys.ArrowDown);
                Thread.Sleep(1000);
                to.SendKeys(Keys.Enter);

                driver.FindElement(By.XPath(@"//*[@id='app']/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[2]/button")).Click();

                actual = true;
            }
            catch (Exception e)
            {
                actual = false;
            }

            return actual;
        }

        public void ValidateResult(bool actual)
        {
            Assert.AreEqual(true, actual);
        }
    }
}
