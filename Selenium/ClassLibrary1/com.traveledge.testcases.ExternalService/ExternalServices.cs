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

namespace ClassLibrary1
{
    [TestFixture]
    class ExternalServices : ExtentReport
    {

        IWebDriver driver;
        WebDriverCommonLib wLib;
        Login loginPage;
        InvoiceTool invoiceTool;
        AddTravelers addTravelers;
        ExternalServiceVendor externalServiceVendor;
        TSP tsp;
        Payment payment;
        Logout logout;
        ExcelLib eLib = new ExcelLib();

        [SetUp]
        public void configureBeforeClass()
        {
            driver = Browser.getBrowser("Chrome");
            loginPage = new Login();
            invoiceTool = new InvoiceTool();
            addTravelers = new AddTravelers();
            externalServiceVendor = new ExternalServiceVendor();
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

        [Test]
        public void bookExternalService()
        {
            test = extent.CreateTest(System.Reflection.MethodBase.GetCurrentMethod().Name);
            String url = eLib.getExcelData("Login", "B3");
            navigateToApplication(url, test);
            // read list of all air 

            String userName = eLib.getExcelData("Login", "C1");
            String passWord = eLib.getExcelData("Login", "B2");
            login(userName, passWord, test);
            Actions act = new Actions(driver);
            //String serviceType, String quoteOwnerName 
            String serviceType = eLib.getExcelData("ExternalService", "B1");
            String quoteOwnerName = eLib.getExcelData("ExternalService", "B2");
            invoiceTool.searchExternalService(serviceType, quoteOwnerName, test);
            //String serviceVendorName, String currencyCode, String amount, String startDateVal, String endDateVal
            String serviceVendorName = eLib.getExcelData("ExternalService", "B3");
            String currencyCode = eLib.getExcelData("ExternalService", "B4");
            String amount = eLib.getExcelData("ExternalService", "B5");
            String startDateVal = eLib.getExcelData("ExternalService", "B6").Replace(" 12:00:00 AM", "");
            String endDateVal = eLib.getExcelData("ExternalService", "B7").Replace(" 12:00:00 AM", "");

            externalServiceVendor.fillService(serviceVendorName, currencyCode, amount, startDateVal, endDateVal, act, test, addTravelers,eLib);
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
