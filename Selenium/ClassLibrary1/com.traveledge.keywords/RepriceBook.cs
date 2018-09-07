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
    class RepriceBook : WebDriverCommonLib
    {

        public RepriceBook()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[text()='Book' and @title='Book']")]
        private IWebElement repriceBook { get; set; }

        public void rePriceBook(ExtentTest test)
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,1000)", "");
            Thread.Sleep(5000);
            jse.ExecuteScript("window.scrollBy(0,1000)", "");
            presenceOfElement(Browser.driver, "//button[text()='Book' and @title='Book']");
           

            



            repriceBook.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Reprice is done , navigating to add travelers");

        }

        [FindsBy(How = How.XPath, Using = "//button[text()='Book' and contains(@class,'hotel-reprice')]")]
        private IWebElement repriceBookHotel { get; set; }

        public void rePriceBookHotel(ExtentTest test)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            presenceOfElement(Browser.driver, "//button[text()='Book' and contains(@class,'hotel-reprice')]");
            repriceBookHotel.Click();
            waitForPageToLoad();
            rePriceBook(test);
            test.Log(Status.Info, "Reprice is done , navigating to add travelers");

        }
    }
}
