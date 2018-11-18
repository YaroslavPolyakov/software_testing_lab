using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
                to.SendKeys("Минск");
                Thread.Sleep(1000);
                to.SendKeys(Keys.ArrowDown);
                Thread.Sleep(1000);
                to.SendKeys(Keys.Enter);

                driver.FindElement(By.XPath(@"//*[@id='app']/div[12]/main/div[1]/div/div/div[1]/div/div[1]/div[2]/button")).Click();

                actual = true;
            }

            catch (Exception)
            {
                actual = false;
            }

            Assert.AreEqual(true, actual);
        }
    }
}
