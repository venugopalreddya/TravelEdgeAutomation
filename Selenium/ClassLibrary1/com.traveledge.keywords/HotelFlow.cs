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
    class HotelFlow : WebDriverCommonLib
    {
        public HotelFlow()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//b[text()='New Hotel Quote']")]
        private IWebElement newHotelQuote { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='DestinationCode' and contains(@placeholder,'Search for hotel')]")]
        private IWebElement searchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='CheckInDate' ])[1]")]
        private IWebElement checkIn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='CheckOutDate' ])[1]")]
        private IWebElement checkOut { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='masterContainer']")]
        private IWebElement plainarea { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-search-hotelfare']")]
        private IWebElement searchButton { get; set; }


        public void searchHotel(Actions act, String searchLoc,String checkInDate,String CheckOutDate, ExtentTest test)
        {
            Thread.Sleep(7000);
            newHotelQuote.Click();
            searchBox.SendKeys(searchLoc);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();

            
            calanderPopup(checkInDate, checkIn);
            calanderPopup(CheckOutDate, checkOut);
            searchButton.Click();
            test.Log(Status.Info, "Got the hotelSearch result");





        }
    }
}
