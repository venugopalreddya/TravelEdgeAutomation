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
    class HotelSearchResult : WebDriverCommonLib
    {
        public HotelSearchResult()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//select[contains(@class,'per-page')])[1]")]
        private IWebElement pagination { get; set; }


        [FindsBy(How = How.XPath, Using = "(//button[contains(@class,'select-hotel')])[1]")]
        private IWebElement selectAnyHotel { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='col-xs-1 col-md-1 text-center' and not(a)]/following-sibling::div/div/div/button[text()='Select'])[1]")]
        private IWebElement selectSabreHotel { get; set; }

       

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class,'on-select-room')])[1]")]
        private IWebElement selRoom { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class,'alert-info') and text()='Ok'])[3]")]
        private IWebElement dynamicRoompopup { get; set; }


        public void selectAnyProviderHotel(Actions act, ExtentTest test)
        {
            Thread.Sleep(5000);
            presenceOfElement(Browser.driver, "(//button[contains(@class,'select-hotel')])[1]");
            selectAnyHotel.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "hotel selected");
            Thread.Sleep(10000);
            presenceOfElement(Browser.driver, "(//button[contains(@class,'on-select-room')])[1]");
            try
            {
                selRoom.Click();
            }
            catch (Exception e)
            {
                presenceOfElement(Browser.driver, "(//button[contains(@class,'alert-info') and text()='Ok'])[3]");
                dynamicRoompopup.Click();

            }
            test.Log(Status.Info, "room is selected");
        }
        public void selectSabreProviderHotel(Actions act, ExtentTest test)
        {

            Thread.Sleep(5000);
            presenceOfElement(Browser.driver, "(//select[contains(@class,'per-page')])[1]");
            selectFromDropdownByText(pagination, "100");
            waitForPageToLoad();
            Thread.Sleep(2000);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,1000)", "");
            presenceOfElement(Browser.driver, "(//div[@class='col-xs-1 col-md-1 text-center' and not(a)]/following-sibling::div/div/div/button[text()='Select'])[1]");
            selectSabreHotel.Click();
            waitForPageToLoad();
            test.Log(Status.Info, "sabre hotel selected");
            Thread.Sleep(10000);
            presenceOfElement(Browser.driver, "(//button[contains(@class,'on-select-room')])[1]");

            try
            {
                selRoom.Click();
            }
            catch(Exception e)
            {
                presenceOfElement(Browser.driver, "(//button[contains(@class,'alert-info') and text()='Ok'])[3]");
                dynamicRoompopup.Click();
            }
           
            test.Log(Status.Info, "room is selected");
        }

    }
}
