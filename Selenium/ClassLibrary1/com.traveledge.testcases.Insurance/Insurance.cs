

using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using ClassLibrary1.com.traveledge.keywords;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;

namespace ClassLibrary1.com.traveledge.testcases.Insurance
{
    [TestFixture]
    class Insurance : ExtentReport
    {
        IWebDriver driver;
        WebDriverCommonLib wLib;
        Login loginPage;
        InsuranceSearch insuranceSearch;
        AddTravelers addTravelers;
        TSP tsp;
        Payment payment;
        Logout logout;
        ExcelLib eLib = new ExcelLib();


        [SetUp]
        public void configureBeforeClass()
        {
            driver = Browser.getBrowser("Chrome");
            loginPage = new Login();
            insuranceSearch = new InsuranceSearch();
            addTravelers = new AddTravelers();
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
        [Test]
        public void bookInsurance()
        {
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url, test);
            // read list of all air 

            String userName = eLib.getExcelData("Login", "C1");
            String passWord = eLib.getExcelData("Login", "B2");
            login(userName, passWord, test);
            Actions act = new Actions(driver);
            String startDT = eLib.getExcelData("Insurance", "B1").Replace(" 12:00:00 AM", "");
            String endDT = eLib.getExcelData("Insurance", "B2").Replace(" 12:00:00 AM", "");
            String age = eLib.getExcelData("Insurance", "B3");
            String tripCost = eLib.getExcelData("Insurance", "B4");


            //String startDT,String endDT, String Age1,String tripcost1
            insuranceSearch.searchInsurace(startDT, endDT, age, tripCost, test);
            tsp.InsuranceBook(test);

            String travelerName = eLib.getExcelData("Client Traveler", "B1");
            String title = eLib.getExcelData("Add Traveller", "B1");
            String firstName = eLib.getExcelData("Add Traveller", "B2");
            String lastName = eLib.getExcelData("Add Traveller", "B3");
            String date = eLib.getExcelData("Add Traveller", "B4");
            String month = eLib.getExcelData("Add Traveller", "B5");
            String year = eLib.getExcelData("Add Traveller", "B6");
            String nationality = eLib.getExcelData("Add Traveller", "B7");

            addTravelers.addTravelersForInsurance(act, travelerName, title, firstName, lastName, date, month, year, nationality, test);
            insuranceSearch.travellerDestination(act,test);
            addTravelers.verifyTravelersLegalNames(test);
            //try
            //{
            //    new WebDriverCommonLib().presenceOfElement(Browser.driver, "//input[@name='LastName']");
            //}catch(Exception e)
            //{
            //    driver.FindElement(By.XPath("//button[text()='Continue']")).Click();
            //}
           



            //
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
           // tsp.checkPaidStatusPlanningFee(test);

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
