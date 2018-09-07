using AventStack.ExtentReports;
using ClassLibrary1.com.traveledge.common;
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
   public class Quote : WebDriverCommonLib
    {

        public Quote()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//button[@title='Quote' and text()='Quote']")]
        private IWebElement quote { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Book']")]
        private IWebElement book { get; set; }


        public void quoteIt(ExtentTest test)
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,1000)", "");
            Thread.Sleep(5000);
            jse.ExecuteScript("window.scrollBy(0,1000)", "");

            presenceOfElement(Browser.driver, "//button[@title='Quote' and text()='Quote']");
            quote.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Quote is done");
        }


        public void bookIt(ExtentTest test)
        {
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,1000)", "");
            Thread.Sleep(5000);
            jse.ExecuteScript("window.scrollBy(0,1000)", "");
            presenceOfElement(Browser.driver, "//button[text()='Book']");
            book.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "going without reprice");
        }
    }
}
