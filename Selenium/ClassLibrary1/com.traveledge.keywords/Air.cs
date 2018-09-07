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
    public class AirFlow : WebDriverCommonLib
    {


        public AirFlow()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[text()='Air']")]
        private IWebElement newAirQuote { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@class='btn btn-default label-normal one-way-label']")]
        private IWebElement oneWay { get; set; }

        [FindsBy(How = How.Id, Using = "airport-from-1")]
        private IWebElement from { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='airport-to-1']")]
        private IWebElement to { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='date-1'])[1]")]
        private IWebElement depart { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='date-2'])[1]")]
        private IWebElement Return { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-search-airfare']")]
        private IWebElement flightsearch { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Enter Airline Code or Airline Name']")]
        private IWebElement airlinesAndAlliances { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='inventory-source']")]
        private IWebElement inventorySourceGDS { get; set; }


        public void searchFlightOneWay(Actions act, String fromAir, String toAir, String departDate,String airLine, String gds, ExtentTest test)
        {
            Thread.Sleep(7000);
            newAirQuote.Click();
            presenceOfElement(Browser.driver, "//label[@class='btn btn-default label-normal one-way-label']");

            oneWay.Click();
            from.SendKeys(fromAir);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();

            to.SendKeys(toAir);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            calanderPopup(departDate, depart);
           

            airlinesAndAlliances.Click();
            airlinesAndAlliances.SendKeys(airLine);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            selectFromDropdown(inventorySourceGDS, gds);
            flightsearch.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Got the oneWay flight result");
            

        }


        [FindsBy(How = How.XPath, Using = "//label[@class='btn btn-default label-normal round-trip-label active']")]
        private IWebElement roundTrip { get; set; }


        public void searchFlightRoundTrip(Actions act, String fromAir, String toAir,String departDate,String ReturnDate, String airLine, String gds, ExtentTest test)
        {
            Thread.Sleep(7000);
            newAirQuote.Click();
            roundTrip.Click();
            from.SendKeys(fromAir);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            to.SendKeys(toAir);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();


            calanderPopup(departDate, depart);
            calanderPopup(ReturnDate, Return);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");
            airlinesAndAlliances.Click();
            airlinesAndAlliances.SendKeys(airLine);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            selectFromDropdown(inventorySourceGDS, gds);
            flightsearch.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Got the round trip flight result");

        }

        [FindsBy(How = How.XPath, Using = "//td[@class='day' and text()='16']")]
        private IWebElement date { get; set; }

        [FindsBy(How = How.XPath, Using = "//th[@class='next']")]
        private IWebElement nextMonth { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/div[3]/div[1]/table/thead/tr[1]/th[2]")]
        private IWebElement mnYr { get; set; }


        //MutiCity
        [FindsBy(How = How.XPath, Using = "//label[@class='btn btn-default label-normal one-way-label']/following-sibling::label")]
        private IWebElement multiCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='airport-from-1']")]
        private IWebElement from1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='airport-to-1']")]
        private IWebElement to1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='airport-from-2']")]
        private IWebElement from2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='airport-to-2']")]
        private IWebElement to2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='airport-from-3']")]
        private IWebElement from3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='airport-to-3']")]
        private IWebElement to3 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='date-1'])[1]")]
        private IWebElement depart1 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='date-2'])[1]")]
        private IWebElement depart2 { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@name='date-3'])[1]")]
        private IWebElement depart3 { get; set; }

        public void searchFlightMultiCity(Actions act, String destination1,String departDate1, String destination2,String departDate2, String destination3, String departDate3, String airLine, String gds, ExtentTest test)
        {
            presenceOfElement(Browser.driver, "//div[text()='New Air ']");
            newAirQuote.Click();
            presenceOfElement(Browser.driver, "//label[@class='btn btn-default label-normal one-way-label']/following-sibling::label");

            multiCity.Click();

            //segment 1
            from1.SendKeys(destination1);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            to1.SendKeys(destination2);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
           
            calanderPopup(departDate1, depart1);

            //segment 2
            //from2.SendKeys(destination2);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            to2.SendKeys(destination3);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            calanderPopup(departDate2, depart2);

            //segment 3
            //from3.SendKeys(destination3);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            to3.SendKeys(destination1);
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            calanderPopup(departDate3, depart3);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,250)", "");

           airlinesAndAlliances.Click();
            airlinesAndAlliances.SendKeys(airLine);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            selectFromDropdown(inventorySourceGDS, gds);
            flightsearch.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "Got the MultiCity trip flight result");

        }
        


       





    }
}
