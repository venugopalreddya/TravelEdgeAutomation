

using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using ClassLibrary1.com.traveledge.keywords;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.testcases.Air
{
    [TestFixture]
    class Multicity : ExtentReport
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
            test.Log(Status.Info, "Application is up");

        }

        public void login(String userName, String password, ExtentTest test)
        {

            Thread.Sleep(10000);
            loginPage.loginToAPP(userName, password);
            Thread.Sleep(10000);
            test.Log(Status.Info, "you are logged in");
        }
        [Test]
        public void bookMultiCityDJ()
        {
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url, test);

            // read list of all air 

            String userName = eLib.getExcelData("Login", "C1");
            String passWord = eLib.getExcelData("Login", "B2");

            login(userName, passWord, test);

            Actions act = new Actions(driver);

            String destination1 = eLib.getExcelData("AirMultiCity", "B2");
            String destination2 = eLib.getExcelData("AirMultiCity", "B3");
            String destination3 = eLib.getExcelData("AirMultiCity", "B4");

            String airLines = eLib.getExcelData("Air", "B4");
            String departDate1 = eLib.getExcelData("AirMultiCity", "B5").Replace(" 12:00:00 AM", "");
            String departDate2 = eLib.getExcelData("AirMultiCity", "B6").Replace(" 12:00:00 AM", "");
            String departDate3 = eLib.getExcelData("AirMultiCity", "B7").Replace(" 12:00:00 AM", "");


            air.searchFlightMultiCity(act, destination1, departDate1, destination2, departDate2, destination3, departDate3, airLines, "2", test);
            flightSearchResult.selectFlighT(act, test);
            flightSearchResult.selectFlighT(act, test);
            flightSearchResult.selectFlighT(act, test);
            //Thread.Sleep(5000);
            quote.quoteIt(test);
            //Thread.Sleep(10000);
            tsp.ClickOnItenaryBook(test);
            reprice.rePriceBook(test);
            //Thread.Sleep(10000);

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
            //Thread.Sleep(20000);
            tsp.ClickOnTicketFlight(test);
            //Thread.Sleep(20000);

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
            //Thread.Sleep(120000);
            tsp.checkTicketed(test);
            // Thread.Sleep(5000);
            logout.logout(test);
            Thread.Sleep(5000);
            //  test.Pass("Assertion passed");
        }

        [Test]
        public void bookMultiCityDJWithoutRepriceflow()
        {
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url, test);

            // read list of all air 

            String userName = eLib.getExcelData("Login", "C1");
            String passWord = eLib.getExcelData("Login", "B2");

            login(userName, passWord, test);

            Actions act = new Actions(driver);

            String destination1 = eLib.getExcelData("AirMultiCity", "B2");
            String destination2 = eLib.getExcelData("AirMultiCity", "B3");
            String destination3 = eLib.getExcelData("AirMultiCity", "B4");

            String airLines = eLib.getExcelData("Air", "B4");
            String departDate1 = eLib.getExcelData("AirMultiCity", "B5").Replace(" 12:00:00 AM", "");
            String departDate2 = eLib.getExcelData("AirMultiCity", "B6").Replace(" 12:00:00 AM", "");
            String departDate3 = eLib.getExcelData("AirMultiCity", "B7").Replace(" 12:00:00 AM", "");


            air.searchFlightMultiCity(act, destination1, departDate1, destination2, departDate2, destination3, departDate3, airLines, "2", test);
            flightSearchResult.selectFlighT(act, test);
            flightSearchResult.selectFlighT(act, test);
            flightSearchResult.selectFlighT(act, test);
            //Thread.Sleep(5000);
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
            //Thread.Sleep(20000);
            tsp.ClickOnTicketFlight(test);
            //Thread.Sleep(20000);

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
            //Thread.Sleep(120000);
            tsp.checkTicketed(test);
            // Thread.Sleep(5000);
            logout.logout(test);
            Thread.Sleep(5000);
            //  test.Pass("Assertion passed");
        }
        [Test]
        public void bookMultiCityKT()
        {
            String s = System.Reflection.MethodBase.GetCurrentMethod().Name;
            test = extent.CreateTest(s);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url, test);

            String userName = eLib.getExcelData("Login", "B1");
            String passWord = eLib.getExcelData("Login", "B2");

            login(userName, passWord, test);
            Thread.Sleep(10000);
            Actions act = new Actions(driver);

            String destination1 = eLib.getExcelData("AirMultiCity", "B2");
            String destination2 = eLib.getExcelData("AirMultiCity", "B3");
            String destination3 = eLib.getExcelData("AirMultiCity", "B4");

            String airLines = eLib.getExcelData("Air", "B4");
            String departDate1 = eLib.getExcelData("AirMultiCity", "B5").Replace(" 12:00:00 AM", "");
            String departDate2 = eLib.getExcelData("AirMultiCity", "B6").Replace(" 12:00:00 AM", "");
            String departDate3 = eLib.getExcelData("AirMultiCity", "B7").Replace(" 12:00:00 AM", "");


            air.searchFlightMultiCity(act, destination1, departDate1, destination2, departDate2, destination3, departDate3, airLines, "2", test);
            flightSearchResult.selectFlighT(act, test);
            flightSearchResult.selectFlighT(act, test);
            flightSearchResult.selectFlighT(act, test);

            //Thread.Sleep(5000);
            quote.quoteIt(test);
            //Thread.Sleep(10000);
            tsp.ClickOnItenaryBook(test);
            reprice.rePriceBook(test);
            //Thread.Sleep(10000);

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
            //Thread.Sleep(20000);
            tsp.ClickOnTicketFlight(test);
            //Thread.Sleep(20000);

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
            //Thread.Sleep(120000);
            tsp.checkTicketed(test);
            // Thread.Sleep(5000);
            logout.logout(test);
            Thread.Sleep(5000);
            //  test.Pass("Assertion passed");
        }


        [TearDown]
        public void flushReport()
        {

            getResult();
            driver.Close();


        }

      
    }
}
