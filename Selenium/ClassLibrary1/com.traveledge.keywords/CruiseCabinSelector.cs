using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
    class CruiseCabinSelector  : WebDriverCommonLib
    {

        public CruiseCabinSelector()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "(//button[contains(@class,'btn-select-cabin')])[1]")]
        private IWebElement selectCabin { get; set; }


        [FindsBy(How = How.Id, Using = "on-book-cruise")]
        private IWebElement bookCruise { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'seating')]")]
        private IWebElement selectSeating { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@name,'table')]")]
        private IWebElement selectTableSize { get; set; }
        

        public void SelectCabinAndBook(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "(//button[contains(@class,'btn-select-cabin')])[1]");
            selectCabin.Click();
            presenceOfElementUsingId(Browser.driver, "on-book-cruise");

            selectFromDropdown(selectSeating, "OPEN");
            selectFromDropdown(selectTableSize, "2");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,1000)", "");
            presenceOfElementUsingId(Browser.driver, "on-book-cruise");
            bookCruise.Click();
            new AddTravelers().verifyTravelersLegalNames(test);

        }
        


        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'This cruise itinerary has been successfully booked')]")]
        private IWebElement bookingMessage { get; set; }


        public void checkSuccessMessage(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//p[contains(text(),'This cruise itinerary has been successfully booked')]");

            Assert.IsTrue(bookingMessage.Displayed, "staus is not booked");

        

            if (bookingMessage.Displayed)
            {
                test.Pass("itinerarie is booked");
                test.Log(Status.Info, "itineraries is booked");
            }
            else
            {
                test.Fail("booking failed");
                test.Log(Status.Info, "booking failed");

            }

        }


    }
}
