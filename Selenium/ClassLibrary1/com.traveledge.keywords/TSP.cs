using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
    class TSP : WebDriverCommonLib
    {

        public TSP()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//a[text()='Book' and contains(@class,'update-price') ]")]
        private IWebElement itenaryBook { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Ticket Flight']")]
        private IWebElement ticketFlight { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Back to Trip Services']")]
        private IWebElement tsp { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='label-status label-ticketed' and text()='ticketed']")]
        private IWebElement ticketed { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Book' and contains(@class,'insurance-book')]")]
        private IWebElement insuranceBook { get; set; }

        public void InsuranceBook(ExtentTest test)
        {
            test.Log(Status.Info, "Offered");
            insuranceBook.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Going for booking");

        }
        public void ClickOnItenaryBook(ExtentTest test)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            presenceOfElement(Browser.driver, "//a[text()='Book' and contains(@class,'update-price') ]");
            itenaryBook.Click();
            waitForPageToLoad();
            Thread.Sleep(10000);

            test.Log(Status.Info, "Navigating to reprice flow");
        }

        public void ClickOnTicketFlight(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//a[text()='Ticket Flight']");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");

            presenceOfElement(Browser.driver, "//a[text()='Ticket Flight']");
            Thread.Sleep(2000);
            ticketFlight.Click();
            waitForPageToLoad();
            Thread.Sleep(10000);
            test.Log(Status.Info, "Going for ticketing");

        }

        public void backToTsp()
        {
            presenceOfElement(Browser.driver, "//a[text()='Back to Trip Services']");

            tsp.Click();
            waitForPageToLoad();

        }

        public void checkTicketed(ExtentTest test)
        {

            Thread.Sleep(1000);
            presenceOfElement(Browser.driver, "//span[@class='label-status label-ticketed' and text()='ticketed']");
            Thread.Sleep(1000);
            Assert.IsTrue(ticketed.Displayed, "staus is not ticketed");
            if (ticketed.Displayed)
            {
                test.Pass("Flight is ticketed");
                test.Log(Status.Info, "Payment is done / Status is ticketed");
            }
            else
            {
                test.Fail("ticketed failed");
                test.Log(Status.Info, "ticketed failed");

            }

        }

        [FindsBy(How = How.XPath, Using = "//span[@class='label-status label-booked' and text()='booked']")]
        private IWebElement booked { get; set; }

       
        public void checkBookStatus(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//span[@class='label-status label-booked' and text()='booked']");

            Assert.IsTrue(booked.Displayed, "staus is not booked");
            if (booked.Displayed)
            {
                test.Pass("itineraries is booked");
                test.Log(Status.Info, "Status is booked");
            }
            else
            {
                test.Fail("booking failed");
                test.Log(Status.Info, "booking failed");

            }

        }

        //TSP for Cruise 
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'View Trip Services Page')]")]
        private IWebElement tspCruise { get; set; }

        public void ClickOnTripServicesPageButtonCruise(ExtentTest test)
        {
            tspCruise.Click();
            test.Log(Status.Info, "Land on TSP for cruise");
        }

        //TSP for  planning fee

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'traveling') and @type = 'checkbox']")]
        private IWebElement isTravelingCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Save Traveler Changes')]")]
        private IWebElement saveTravelerChanges { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Payment')]")]
        private IWebElement payment { get; set; }    

        public void saveTraveler(ExtentTest test)
        {

            presenceOfElement(Browser.driver, "//input[contains(@id,'traveling') and @type = 'checkbox']");

            isTravelingCheckBox.Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,500)", "");
          
            presenceOfElement(Browser.driver, "//input[contains(@id,'traveling') and @type = 'checkbox']");
            presenceOfElement(Browser.driver, "//button[contains(text(),'Save Traveler Changes')]");
            saveTravelerChanges.Click();
            test.Log(Status.Info, "traveler changes saved and going for payment");
            presenceOfElement(Browser.driver, "//button[contains(text(),'Payment')]");

            payment.Click();
            waitForPageToLoad();
        }

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'label-paid') and text()='paid']")]
        private IWebElement paid { get; set; }

        public void checkPaidStatusPlanningFee(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//span[contains(@class,'label-paid') and text()='paid']");

            Assert.IsTrue(paid.Displayed, "staus is not ticketed");
            if (paid.Displayed)
            {
                test.Pass("planning fee is paid");
                test.Log(Status.Info, "Payment is done / Status is paid");
            }
            else
            {
                test.Fail("payment failed");
                test.Log(Status.Info, "planning fee payment failed");

            }

        }
    }
}
