using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
    class PlanningFeeFillDetails : WebDriverCommonLib
    {


        public PlanningFeeFillDetails()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        //Specify Fee Amount

        [FindsBy(How = How.XPath, Using = "//select[@name='CurrencyCode']")]
        private IWebElement currency { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='Amount']")]
        private IWebElement amount { get; set; }

        public void specifyFeeAmount(String currencyCode,String planningfeeAmount, ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//select[@name='CurrencyCode']");
            selectFromDropdown(currency, currencyCode);
            amount.Clear();
            amount.SendKeys(planningfeeAmount);
            test.Log(Status.Info, "Fee is specified");

        }
        //Specify Trip Information

        [FindsBy(How = How.XPath, Using = "//textarea[@name='TripDescription']")]
        private IWebElement tripDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='TripStartDate']")]
        private IWebElement tripStartDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='TripEndDate']")]
        private IWebElement tripEndDate { get; set; }

        public void specifyTripInformation(String description,String stratDate,String endDate, ExtentTest test)
        {
            tripDescription.SendKeys(description);
            calanderPopup(stratDate, tripStartDate);
            calanderPopup(endDate, tripEndDate);
            test.Log(Status.Info, "trip info is specified");
        }

        //Describe the services you will provide this client

        [FindsBy(How = How.XPath, Using = "//textarea[@name='ServiceDescription']")]
        private IWebElement serviceDescription { get; set; }

        public void describeTheService(String description, ExtentTest test)
        {
            serviceDescription.SendKeys(description);
            saveToQuote.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Service is described");
        }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Save to Quote')]")]
        private IWebElement saveToQuote { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Continue to Send Agreement')]")]
        private IWebElement continueToSendAgreement { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cancel')]")]
        private IWebElement cancel { get; set; }
    }
}
