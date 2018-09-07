//=====================================================================================
//File:        Travel edge Air OneWay
//Created:      2017/05/12
//Last Changed: 
//FrameWork Designed by:  Pritam Samantaray
//Author:       Pritam Samantaray
//Jira ID or Test case name:  Air roundTrip search validation    
//Jira Link:   if available
//=====================================================================================

using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using ClassLibrary1.com.traveledge.common;
using ClassLibrary1.com.traveledge.keywords;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.testcases.Air
{
    [TestFixture]
    class Oneway : ExtentReport
    {
        IWebDriver driver;
        WebDriverCommonLib wLib;
        Login loginPage;
        AirFlow air;
        FlightSearchResult flightSearchResult;
        Quote quote;
        RepriceBook reprice;
        TSP tsp;
        AddTravelers addTravelers;
        Payment payment;
        Logout logout;
        ExcelLib eLib = new ExcelLib();


        [SetUp]
        public void configureBeforeClass()
        {
            driver = Browser.getBrowser("Chrome");
            loginPage = new Login();
            air = new AirFlow();
            flightSearchResult = new FlightSearchResult();
            quote = new Quote();
            reprice = new RepriceBook();
            tsp = new TSP();
            addTravelers = new AddTravelers();
            payment = new Payment();
            logout = new Logout();
         }

        public void navigateToApplication(String url, ExtentTest test)
        {
            
            loginPage.navigateToApp(url);
            test.Log(Status.Info, "Navigate to application");

        }

        public void login(String userName, String password, ExtentTest test)
        {
                      
            Thread.Sleep(10000);
            loginPage.loginToAPP(userName,password);
            Thread.Sleep(10000);
            test.Log(Status.Info, "logined toApplication");

        }
        /// <summary>
        /// Book Oneway trip with DJ
        /// </summary>
        [Test]
        public void bookOneWayTripDJ()
        {
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url,test);
             // read list of all air 

            String userName= eLib.getExcelData("Login", "C1");
            String passWord = eLib.getExcelData("Login", "B2");

            login(userName, passWord,test);      
            Actions act = new Actions(driver);

            String from = eLib.getExcelData("Air", "B1");
            String to = eLib.getExcelData("Air", "B2");
            String airLines = eLib.getExcelData("Air", "B4");
            String departDate = eLib.getExcelData("Air", "B3").Replace(" 12:00:00 AM", "");

            air.searchFlightOneWay(act,from,to, departDate, airLines, "2",test);
            flightSearchResult.selectFlighT(act,test);
            quote.quoteIt(test);
            tsp.ClickOnItenaryBook(test);
            reprice.rePriceBook(test);
           
            String travelerName = eLib.getExcelData("Client Traveler", "B1");
            String title = eLib.getExcelData("Add Traveller", "B1");
            String firstName = eLib.getExcelData("Add Traveller", "B2");
            String lastName = eLib.getExcelData("Add Traveller", "B3");
            String date = eLib.getExcelData("Add Traveller", "B4");
            String month = eLib.getExcelData("Add Traveller", "B5");
            String year = eLib.getExcelData("Add Traveller", "B6");
            String nationality = eLib.getExcelData("Add Traveller", "B7");
            
            addTravelers.addTravelers(act, travelerName, title, firstName, lastName,date, month, year, nationality,test);
            addTravelers.verifyTravelersLegalNames(test);
            tsp.ClickOnTicketFlight(test);
          
            String firstNameForPayment = eLib.getExcelData("Payment", "B1");
            String lastNameForPayment = eLib.getExcelData("Payment", "B2");
            String cardNumber = eLib.getExcelData("Payment", "B3");
            String expMonth = eLib.getExcelData("Payment", "B4");
            String expYear = eLib.getExcelData("Payment", "B5");
            String vcc = eLib.getExcelData("Payment", "B6");
            String address = eLib.getExcelData("Payment", "B7");
            String city = eLib.getExcelData("Payment", "B8");
            String country = eLib.getExcelData("Payment", "B9");
            String state = eLib.getExcelData("Payment", "B10");
            String zip = eLib.getExcelData("Payment", "B11");

            payment.makePayment(firstNameForPayment,lastNameForPayment,cardNumber,expMonth,expYear,vcc,address,city,country,state,zip,test);
            tsp.checkTicketed(test);
            
            logout.logout(test);
           
            
        }

        [Test]
        public void bookOneWayTripDJWithoutReprice()
        {
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url, test);
            // read list of all air 

            String userName = eLib.getExcelData("Login", "C1");
            String passWord = eLib.getExcelData("Login", "B2");

            login(userName, passWord, test);
            Actions act = new Actions(driver);

            String from = eLib.getExcelData("Air", "B1");
            String to = eLib.getExcelData("Air", "B2");
            String airLines = eLib.getExcelData("Air", "B4");
            String departDate = eLib.getExcelData("Air", "B3").Replace(" 12:00:00 AM", "");

            air.searchFlightOneWay(act, from, to, departDate, airLines, "2", test);
            flightSearchResult.selectFlighT(act, test);
            quote.bookIt(test);
            
            String travelerName = eLib.getExcelData("Client Traveler", "B1");
            String title = eLib.getExcelData("Add Traveller", "B1");
            String firstName = eLib.getExcelData("Add Traveller", "B2");
            String lastName = eLib.getExcelData("Add Traveller", "B3");
            String date = eLib.getExcelData("Add Traveller", "B4");
            String month = eLib.getExcelData("Add Traveller", "B5");
            String year = eLib.getExcelData("Add Traveller", "B6");
            String nationality = eLib.getExcelData("Add Traveller", "B7");

            addTravelers.addTravelers(act, travelerName, title, firstName, lastName, date, month, year, nationality, test);
            addTravelers.verifyTravelersLegalNames(test);
            tsp.ClickOnTicketFlight(test);

            String firstNameForPayment = eLib.getExcelData("Payment", "B1");
            String lastNameForPayment = eLib.getExcelData("Payment", "B2");
            String cardNumber = eLib.getExcelData("Payment", "B3");
            String expMonth = eLib.getExcelData("Payment", "B4");
            String expYear = eLib.getExcelData("Payment", "B5");
            String vcc = eLib.getExcelData("Payment", "B6");
            String address = eLib.getExcelData("Payment", "B7");
            String city = eLib.getExcelData("Payment", "B8");
            String country = eLib.getExcelData("Payment", "B9");
            String state = eLib.getExcelData("Payment", "B10");
            String zip = eLib.getExcelData("Payment", "B11");

            payment.makePayment(firstNameForPayment, lastNameForPayment, cardNumber, expMonth, expYear, vcc, address, city, country, state, zip, test);
            tsp.checkTicketed(test);

            logout.logout(test);


        }
        /// <summary>
        /// Book Oneway trip with KT
        /// </summary>
        [Test]
        public void bookOneWayTripKT()
        {
            String s = System.Reflection.MethodBase.GetCurrentMethod().Name;
            test = extent.CreateTest(s);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url,test);
            String userName = eLib.getExcelData("Login", "B1");
            String passWord = eLib.getExcelData("Login", "B2");

            login(userName, passWord,test);
            
            Thread.Sleep(10000);
            Actions act = new Actions(driver);

            String from = eLib.getExcelData("Air", "B1");
            String to = eLib.getExcelData("Air", "B2");
            String airLines = eLib.getExcelData("Air", "B4");
            String departDate = eLib.getExcelData("Air", "B3").Replace(" 12:00:00 AM","");

            air.searchFlightOneWay(act, from, to, departDate, airLines, "2",test);
          
            flightSearchResult.selectFlighT(act,test);
            quote.quoteIt(test);
            tsp.ClickOnItenaryBook(test);
            reprice.rePriceBook(test);
            String travelerName = eLib.getExcelData("Client Traveler", "B1");
            String title = eLib.getExcelData("Add Traveller", "B1");
            String firstName = eLib.getExcelData("Add Traveller", "B2");
            String lastName = eLib.getExcelData("Add Traveller", "B3");
            String date = eLib.getExcelData("Add Traveller", "B4");
            String month = eLib.getExcelData("Add Traveller", "B5");
            String year = eLib.getExcelData("Add Traveller", "B6");
            String nationality = eLib.getExcelData("Add Traveller", "B7");

            addTravelers.addTravelers(act, travelerName, title, firstName, lastName, date, month, year, nationality,test);
            addTravelers.verifyTravelersLegalNames(test);
            tsp.ClickOnTicketFlight(test);

            String firstNameForPayment = eLib.getExcelData("Payment", "B1");
            String lastNameForPayment = eLib.getExcelData("Payment", "B2");
            String cardNumber = eLib.getExcelData("Payment", "B3");
            String expMonth = eLib.getExcelData("Payment", "B4");
            String expYear = eLib.getExcelData("Payment", "B5");
            String vcc = eLib.getExcelData("Payment", "B6");
            String address = eLib.getExcelData("Payment", "B7");
            String city = eLib.getExcelData("Payment", "B8");
            String country = eLib.getExcelData("Payment", "B9");
            String state = eLib.getExcelData("Payment", "B10");
            String zip = eLib.getExcelData("Payment", "B11");

            payment.makePayment(firstNameForPayment, lastNameForPayment, cardNumber, expMonth, expYear, vcc, address, city, country, state, zip,test);
            tsp.checkTicketed(test);
            
            Thread.Sleep(5000);
            logout.logout(test);
           
        }
       
       
        [TearDown]
        public void flushReport()
        {

            getResult();
            driver.Close();



        }


    }
}
