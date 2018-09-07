using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
using Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
    class InvoiceTool : WebDriverCommonLib
    {


        public InvoiceTool()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//b[contains(text(),'Invoice')]")]
        private IWebElement invoiceTool { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Planning Fee')]")]
        private IWebElement planningFee { get; set; }

        //externalService

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Externally Invoiced Service')]")]
        private IWebElement externalService { get; set; }

        [FindsBy(How = How.Id, Using = "serviceType")]
        private IWebElement selectServiceType { get; set; }

        //
        [FindsBy(How = How.XPath, Using = "//select[@name='external-service-quote-owner']")]
        private IWebElement quoteOwner { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Add']")]
        private IWebElement add { get; set; }

       
        

        public void searchPlanningFee(String quoteOwnerName,ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//b[contains(text(),'Invoice')]");
            Thread.Sleep(1000);
            invoiceTool.Click();
            //presenceOfElement(Browser.driver, "//label[@class='btn btn-default label-normal one-way-label']");

            planningFee.Click();
            

            selectFromDropdown(quoteOwner, quoteOwnerName);
            add.Click();
            test.Log(Status.Info, "seraching planning fee");
        }
        public void searchExternalService( String serviceType, String quoteOwnerName, ExtentTest test)
        {
            

            presenceOfElement(Browser.driver, "//b[contains(text(),'Invoice')]");
            Thread.Sleep(1000);
            invoiceTool.Click();
            //presenceOfElement(Browser.driver, "//label[@class='btn btn-default label-normal one-way-label']");

            externalService.Click();
            selectFromDropdownByText(selectServiceType, serviceType);


            selectFromDropdownByText(quoteOwner, "Darjit Dhillon");
            add.Click();
            test.Log(Status.Info, "searching external service");
        }

       
    }
}
