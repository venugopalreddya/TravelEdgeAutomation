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

namespace ClassLibrary1.com.traveedge.testcases.Cruise
{
    [TestFixture]
    class Cruise : ExtentReport
    {
        IWebDriver driver;
        WebDriverCommonLib wLib;
        Login loginPage;
        CruiseFlow cruise;
        CruiseSearchResultPage cruiseSearchResultPage;
        CruiseTrvelerDetails cruiseTrvelerDetails;
        CruiseCabinSelector cruiseCabinSelector;
        TSP tsp;
        Payment payment;
        Logout logout;
        ExcelLib eLib = new ExcelLib();

        [SetUp]
        public void configureBeforeClass()
        {
            driver = Browser.getBrowser("Chrome");
            loginPage = new Login();
            cruise = new CruiseFlow();
            cruiseSearchResultPage = new CruiseSearchResultPage();
            cruiseTrvelerDetails = new CruiseTrvelerDetails();
            cruiseCabinSelector = new CruiseCabinSelector();


            tsp = new TSP();
           
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
            loginPage.loginToAPP(userName, password);
            Thread.Sleep(10000);
            test.Log(Status.Info, "logined toApplication");

        }
        /// <summary>
        /// Book Oneway trip with DJ
        /// </summary>
        /// 
        [Test]
        public void bookCruiseTripDJ()
        {
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url, test);
            // read list of all air 

            String userName = eLib.getExcelData("Login", "C1");
            String passWord = eLib.getExcelData("Login", "B2");

            login(userName, passWord, test);
            Actions act = new Actions(driver);
            cruise.searchCruise(act, "10/30/2017", test);
            cruiseSearchResultPage.selectCruise(test);
            String travelerName = eLib.getExcelData("Client Traveler", "B1");
            String title = eLib.getExcelData("Add Traveller", "B1");
            String firstName = eLib.getExcelData("Add Traveller", "B2");
            String lastName = eLib.getExcelData("Add Traveller", "B3");
            String date = eLib.getExcelData("Add Traveller", "B4");
            String month = eLib.getExcelData("Add Traveller", "B5");
            String year = eLib.getExcelData("Add Traveller", "B6");
            String nationality = eLib.getExcelData("Add Traveller", "B7");

            cruiseTrvelerDetails.addTravelers(act, travelerName, title, firstName, lastName, date, month, year, nationality, test);
            cruiseCabinSelector.SelectCabinAndBook(test);
            cruiseCabinSelector.checkSuccessMessage(test);
            tsp.ClickOnTripServicesPageButtonCruise(test);
            tsp.checkBookStatus(test);
            tsp.checkBookStatus(test);
        }

        [TearDown]
        public void flushReport()
        {

            getResult();
            driver.Close();



        }
    }
}
