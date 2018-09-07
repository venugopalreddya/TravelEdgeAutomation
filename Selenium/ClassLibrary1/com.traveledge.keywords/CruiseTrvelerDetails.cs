using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
    class CruiseTrvelerDetails : WebDriverCommonLib
    {

        public CruiseTrvelerDetails()
        {
            PageFactory.InitElements(Browser.driver, this);
        }
       
        [FindsBy(How = How.Id, Using = "clientSearch")]
        private IWebElement addTraveler { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='fa fa-search']")]
        private IWebElement searchClient { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[contains(@class,'num-travelers')]")]
        private IWebElement numOfTraveler { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-select-client']")]
        private IWebElement selectTraveler { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@name='Title'])[1]")]
        private IWebElement title { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='FirstName'])[1]")]
        private IWebElement firstName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='LastName'])[1]")]
        private IWebElement lastName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='day form-control de-form-control'])[1]")]
        private IWebElement date { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='month form-control de-form-control'])[1]")]
        private IWebElement month { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='year form-control de-form-control'])[1]")]
        private IWebElement year { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[@class='de-label']/input[@value='M'])[1]")]
        private IWebElement male { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@name='Nationality'])[1]")]
        private IWebElement nationality { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Save Travelers and Select Fare Codes']")]
        private IWebElement saveTravelerSelectFareCode { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/div[5]/div/div/div[1]/div/div")]
        private IWebElement clientSearchResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/div[5]/div/div/div[1]/div/button")]
        private IWebElement cancelAddTravelerPopUp { get; set; }

        //
        [FindsBy(How = How.XPath, Using = "(//input[@class='fare-code'])[1]")]
        private IWebElement selectFare { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Save Fare Codes and Select Cabin Category']")]
        private IWebElement saveFareCodesAndSelectCabinCategory { get; set; }

       [FindsBy(How = How.XPath, Using = "(//button[contains(@class,'add-cabin-category')])[1]")]
        private IWebElement bookPlus { get; set; }



        public void addTravelers(Actions act, String travellerName, String Title, String firstname, String lastname, String dT, String mN, String yR, String nationaliTy, ExtentTest test)
        {
            presenceOfElementUsingId(Browser.driver, "clientSearch");
            selectFromDropdown(numOfTraveler, "1");
            //Thread.Sleep(5000);
            addTraveler.SendKeys(travellerName);
            //Thread.Sleep(5000); 
            presenceOfElement(Browser.driver, "//i[@class='fa fa-search']");
            searchClient.Click();
            presenceOfElement(Browser.driver, "//button[@class='btn btn-primary btn-select-client']");
            selectTraveler.Click();
            
            presenceOfElement(Browser.driver, "//select[@name='Title']");
            selectFromDropdown(title, Title);
            firstName.SendKeys(firstname);
            lastName.SendKeys(lastname);
            selectFromDropdown(date, dT);
            selectFromDropdown(month, mN);
            selectFromDropdown(year, yR);
            selectFromDropdown(nationality, nationaliTy);
            act.MoveToElement(saveTravelerSelectFareCode).Click().Build().Perform();
            waitForPageToLoad();
            test.Log(Status.Info, "Traveler Name is added");
            presenceOfElement(Browser.driver, "(//input[@class='fare-code'])[1]");
            
            //Select Fare Codes 
            selectFare.Click();
            saveFareCodesAndSelectCabinCategory.Click();

            //select cabin category
            presenceOfElement(Browser.driver, "(//button[contains(@class,'add-cabin-category')])[1]");
            bookPlus.Click();
            waitForPageToLoad();
           



        }
    }
}
