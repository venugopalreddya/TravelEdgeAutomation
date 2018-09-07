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
    class ExternalServiceVendor : WebDriverCommonLib
    {


        public ExternalServiceVendor()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.Id, Using = "externalServiceVendor")]
        private IWebElement serviceVendor { get; set; }

        [FindsBy(How = How.Id, Using = "externalServiceCurrency")]
        private IWebElement currency { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='sameAsVendor']")]
        private IWebElement sameAsServiceVendor { get; set; }
    
        [FindsBy(How = How.Id, Using = "externalServiceBaseAmount")]
        private IWebElement baseAmount { get; set; }

        [FindsBy(How = How.Id, Using = "externalServiceStartDate")]
        private IWebElement startDate { get; set; }

        [FindsBy(How = How.Id, Using = "externalServiceEndDate")]
        private IWebElement endDate { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[text()='Create' and contains(@class,'external-service')]")]
        private IWebElement create { get; set; }


        public void fillService(String serviceVendorName, String currencyCode, String amount, String startDateVal, String endDateVal, Actions act, ExtentTest test, AddTravelers addTravelers, ExcelLib eLib)
        {


            presenceOfElementUsingId(Browser.driver, "externalServiceVendor");

            serviceVendor.SendKeys(serviceVendorName);
            Thread.Sleep(3000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            currency.SendKeys(currencyCode);
            Thread.Sleep(3000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            baseAmount.SendKeys(amount);

            presenceOfElement(Browser.driver, "//input[@name='sameAsVendor']");
            sameAsServiceVendor.Click();

            calanderPopup(startDateVal, startDate);
            calanderPopup(endDateVal, endDate);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,1000)", "");

            //Adding Traveller

            //String travelerName = eLib.getExcelData("Client Traveler", "B1");
            //String title = eLib.getExcelData("Add Traveller", "B1");
            //String firstName = eLib.getExcelData("Add Traveller", "B2");
            //String lastName = eLib.getExcelData("Add Traveller", "B3");
            //String date = eLib.getExcelData("Add Traveller", "B4");
            //String month = eLib.getExcelData("Add Traveller", "B5");
            //String year = eLib.getExcelData("Add Traveller", "B6");
            //String nationality = eLib.getExcelData("Add Traveller", "B7");

            //addTravelers.addTravelers(act, travelerName, title, firstName, lastName, date, month, year, nationality, test);
            presenceOfElement(Browser.driver, "//button[text()='Create' and contains(@class,'external-service')]");
            create.Click();
            test.Log(Status.Info, "External Service Created");
        }

    }

  
}
