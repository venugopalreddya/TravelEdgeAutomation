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
    class CruiseSearchResultPage : WebDriverCommonLib
    {

        public CruiseSearchResultPage()
        {
            PageFactory.InitElements(Browser.driver, this);
        }



        [FindsBy(How = How.XPath, Using = "(//table[@class='table table-default sailings-container'])[1]/tbody/tr/td/button[contains(text(),'Select')]")]
        private IWebElement selectCruiseItem { get; set; }
        
        public void selectCruise(ExtentTest test)
        {
            presenceOfElement(Browser.driver, "(//table[@class='table table-default sailings-container'])[1]/tbody/tr/td/button[contains(text(),'Select')]");
            selectCruiseItem.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "cruise selected");

        }
    }
}
