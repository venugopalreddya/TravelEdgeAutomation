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
    class InsuranceSearch : WebDriverCommonLib
    {
        public InsuranceSearch()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//div[text()='New Insurance Quote']")]
        private IWebElement insuranceTab { get; set; }

        [FindsBy(How = How.Id, Using = "insurance-start-date")]
        private IWebElement startDate { get; set; }

        [FindsBy(How = How.Id, Using = "insurance-end-date")]
        private IWebElement endDate { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@name='AgentId' ])[1]")]
        private IWebElement quoteOwner { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='Age'])[1]")]
        private IWebElement age1 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='Age'])[2]")]
        private IWebElement age2 { get; set; }

        //[FindsBy(How = How.XPath, Using = "(//input[@name='Age'])[3]")]
        //private IWebElement age3 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'TripValue'])[1]")]
        private IWebElement tripCost1 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name = 'TripValue'])[2]")]
        private IWebElement tripCost2 { get; set; }

        //[FindsBy(How = How.XPath, Using = "(//input[@name = 'TripValue'])[3]")]
        //private IWebElement tripcost3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-default btn-add-insurance-traveler']")]
        private IWebElement addTraveler { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'search-insurance')]")]
        private IWebElement getQuote { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn-default btn-clear-insurance-form']")]
        private IWebElement reSet { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class = 'col-md-1 col-xs-1 insurance-age-col age-flow-field']")]
        private IWebElement clickIt { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id = 'add-on-2']")]
        private IWebElement carRentalDamage { get; set; }

        [FindsBy(How = How.Id, Using = "add-on-3")]
        private IWebElement adventurePack { get; set; }

        [FindsBy(How = How.Id, Using = "add-on-1")]
        private IWebElement cfar { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()= 'Quote']")]
        private IWebElement quote { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text() = 'quote']")]
        private IWebElement tspStatus { get; set; }
        
        [FindsBy(How = How.XPath, Using = "(//a[contains(@class, remove-insurance-traveler)]/span[text()='Remove'])[1]")]
        private IWebElement removeTraveler { get; set; }


        public void searchInsurace(String startDT,String endDT, String Age1,String tripcost1,ExtentTest test)
        {
            Thread.Sleep(7000);
            presenceOfElement(Browser.driver, "//div[text()='New Insurance Quote']");
            insuranceTab.Click();
            presenceOfElement(Browser.driver, "//button[contains(@class,'search-insurance')]");

            calanderPopup(startDT, startDate);
            calanderPopup(endDT, endDate);

            presenceOfElement(Browser.driver, "(//a[contains(@class, remove-insurance-traveler)]/span[text()='Remove'])[1]");
            removeTraveler.Click();

            age1.SendKeys(Age1);
            //age2.SendKeys(Age2);
            tripCost1.SendKeys(tripcost1);
           // tripCost2.SendKeys(tripcost2);
            getQuote.Click();
            waitForPageToLoad();
            presenceOfElement(Browser.driver, "//button[text()= 'Quote']");
            quote.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Successfully quoted");

        }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Does the trip involve travel to Cuba?')]/following-sibling::label/input[@value='true']")]
        private IWebElement doesTheTripInvolveTravelToCubaYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Does the trip involve travel to Cuba?')]/following-sibling::label/input[@value='false']")]
        private IWebElement doesTheTripInvolveTravelToCubaNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Ukraine, Iran, Libya, North Korea, Syria')]/following-sibling::label/input[@value='true']")]
        private IWebElement regionOfUkraineIranLibyaNorthKoreaSyriaYes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Ukraine, Iran, Libya, North Korea, Syria')]/following-sibling::label/input[@value='false']")]
        private IWebElement regionOfUkraineIranLibyaNorthKoreaSyriaNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Book Only']")]
        private IWebElement bookOnly { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Book' and contains(@class,'save-and-book')]")]
        private IWebElement book { get; set; }

        public void travellerDestination(Actions act, ExtentTest test)
        {

            presenceOfElement(Browser.driver, "//label[contains(text(),'Does the trip involve travel to Cuba?')]/following-sibling::label/input[@value='false']");
            doesTheTripInvolveTravelToCubaNo.Click();
            presenceOfElement(Browser.driver, "//label[contains(text(),'Ukraine, Iran, Libya, North Korea, Syria')]/following-sibling::label/input[@value='false']");
            regionOfUkraineIranLibyaNorthKoreaSyriaNo.Click();

            try
            {
                presenceOfElement(Browser.driver, "//button[text()='Book Only']");

                act.MoveToElement(bookOnly).Click().Build().Perform();
            }
            catch (Exception e)
            {
                presenceOfElement(Browser.driver, "//button[text()='Book' and contains(@class,'save-and-book')]");

                act.MoveToElement(book).Click().Build().Perform();
            }


            Thread.Sleep(5000);
            test.Log(Status.Info, "Traveler Name is added ,Going for Verification");

        }
    }
}
