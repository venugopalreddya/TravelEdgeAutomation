using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
    public class FlightSearchResult : WebDriverCommonLib
    {

        public FlightSearchResult()
        {
            PageFactory.InitElements(Browser.driver, this);
        }



        [FindsBy(How = How.XPath, Using = "(//button[@class='btn btn-primary add-flight'])[1]")]
        private IWebElement selectFlight { get; set; }

        public void selectOneWayFlight()
        {
            presenceOfElement(Browser.driver, "(//button[@class='btn btn-primary add-flight'])[1]");
            selectFlight.Click();
            waitForPageToLoad();
        }

        [FindsBy(How = How.XPath, Using = "(//button[@class='btn btn-primary add-flight'])[1]")]
        private IWebElement selectFlightRoumdTrip { get; set; }

        public void selectFlighT(Actions act, ExtentTest test)
        {
            Thread.Sleep(3000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            Thread.Sleep(2000);
            waitForXpathPresent("(//button[@class='btn btn-primary add-flight'])[1]");
            presenceOfElement(Browser.driver, "(//button[@class='btn btn-primary add-flight'])[1]");
            selectFlightRoumdTrip.Click();
            waitForPageToLoad();
            act.SendKeys(Keys.ArrowDown).Perform();
            test.Log(Status.Info, "Flight selected");

        }
    }
}
