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
    class CruiseFlow : WebDriverCommonLib
    {
        public CruiseFlow()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[text()='New Cruise Quote']")]
        private IWebElement newCruiseQuote { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='CruiseDestinationId']")]
        private IWebElement destination { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='cruise-search-widget-form']/div[2]/div[2]/div[1]/div/div/div/table/tbody/tr[1]/td[1]/label")]
        private IWebElement azamaraClubCruises { get; set; }

        [FindsBy(How = How.Id, Using = "cruise-date-from")]
        private IWebElement fromDate { get; set; }

        [FindsBy(How = How.Id, Using = "cruise-date-to")]
        private IWebElement toDate { get; set; }

        [FindsBy(How = How.Id, Using = "cruise-search-widget-form-find-cruises")]
        private IWebElement searchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='cruise-itins-found-text']")]
        private IWebElement searchButtonItins { get; set; }


        [FindsBy(How = How.XPath, Using = "(//table[@class='table table-default sailings-container'])[1]/tbody/tr/td/button[contains(text(),'Select')]")]
        private IWebElement selectCruise { get; set; }




        public void searchCruise(Actions act, String date, ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//div[text()='New Cruise Quote']");
            Thread.Sleep(1000);
            newCruiseQuote.Click();
            //presenceOfElement(Browser.driver, "//label[@class='btn btn-default label-normal one-way-label']");

            azamaraClubCruises.Click();
            calanderPopup(date, fromDate);
            if (searchButtonItins.Text.Contains("itineraries found"))
            {
                searchButton.Click();
            }
            else
            {
                searchButton.Click();
            }
            waitForPageToLoad();
            test.Log(Status.Info, "Got the cruise trip result");
        }

       
    }
}
