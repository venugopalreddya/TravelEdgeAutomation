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
    class Logout : WebDriverCommonLib
    {

        public Logout()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//span[@class='action-text dashboard-username']")]
        private IWebElement dashboardUserName { get; set; }


        [FindsBy(How = How.XPath, Using = "(//a[@id='logout'])[2]")]
        private IWebElement logOut { get; set; }


        public void logout(ExtentTest test)
        {

            presenceOfElement(Browser.driver, "//span[@class='action-text dashboard-username']");
            dashboardUserName.Click();
            waitForPageToLoad();
            Thread.Sleep(5000);
            presenceOfElement(Browser.driver, "(//a[@id='logout'])[2]");

            logOut.Click();
            Thread.Sleep(5000);
            test.Log(Status.Info, "logged out from application");

        }
    }
}
