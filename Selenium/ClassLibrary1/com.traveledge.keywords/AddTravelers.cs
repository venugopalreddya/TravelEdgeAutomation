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
  public class AddTravelers : WebDriverCommonLib
  {

        public AddTravelers()
        {
            PageFactory.InitElements(Browser.driver, this);
        }


        [FindsBy(How = How.Id, Using = "clientSearch")]
        private IWebElement addTraveler { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-select-client']")]
        private IWebElement selectTraveler { get; set; }

        [FindsBy(How = How.Id, Using = "view21_traveling")]
        private IWebElement isTravelling { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Close']")]
        private IWebElement closeExp { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='Title']")]
        private IWebElement title { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='FirstName']")]
        private IWebElement firstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='LastName']")]
        private IWebElement lastName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='day form-control de-form-control'])[1]")]
        private IWebElement date { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='month form-control de-form-control'])[1]")]
        private IWebElement month { get; set; }

        [FindsBy(How = How.XPath, Using = "(//select[@class='year form-control de-form-control'])[1]")]
        private IWebElement year { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@class='de-label']/input[@value='M']")]
        private IWebElement male { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='Nationality']")]
        private IWebElement nationality { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Book Only']")]
        private IWebElement bookOnly { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/div[5]/div/div/div[1]/div/div")]
        private IWebElement clientSearchResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//html/body/div[5]/div/div/div[1]/div/button")]
        private IWebElement cancelAddTravelerPopUp { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@id='mainContent']/div[2]/div/div/div[2]/div[1]/div/div/div/div/div/form/div[3]/button")]
        private IWebElement searchClient { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[text()='Book' and contains(@class,'save-and-book')]")]
        private IWebElement book { get; set; }

        public void addTravelers(Actions act,String travellerName, String Title, String firstname, String lastname, String dT, String mN, String yR, String nationaliTy,ExtentTest test)
        {

            presenceOfElementUsingId(Browser.driver, "clientSearch");
            //Thread.Sleep(5000);
            addTraveler.SendKeys(travellerName);
            // Thread.Sleep(5000); 
            presenceOfElement(Browser.driver, ".//*[@id='mainContent']/div[2]/div/div/div[2]/div[1]/div/div/div/div/div/form/div[3]/button");

            searchClient.Click();
            selectTraveler.Click();

            presenceOfElement(Browser.driver, "//select[@name='Title']");

            selectFromDropdown(title, Title);
            firstName.SendKeys(firstname);
            lastName.SendKeys(lastname);
            selectFromDropdown(date, dT);
            selectFromDropdown(month, mN);
            selectFromDropdown(year, yR);
            selectFromDropdown(nationality, nationaliTy);

            try
            {
                presenceOfElement(Browser.driver, "//button[text()='Book Only']");

                act.MoveToElement(bookOnly).Click().Build().Perform();
            }
            catch(Exception e)
            {
                presenceOfElement(Browser.driver, "//button[text()='Book' and contains(@class,'save-and-book')]");

                act.MoveToElement(book).Click().Build().Perform();
            }
          

            Thread.Sleep(5000);
            test.Log(Status.Info, "Traveler Name is added ,Going for Verification");
        }

       

        [FindsBy(How = How.XPath, Using = "//input[@name='TripValue']")]
        private IWebElement tripCost { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='Email']")]
        private IWebElement email { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='Country']")]
        private IWebElement country { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='Subdivision']")]
        private IWebElement state { get; set; }

        public void fillInsuranceDetails(Actions act)
        {
            tripCost.Clear();
            tripCost.SendKeys("500");
            email.SendKeys("abc@gmail.com");
            country.Clear();
            country.SendKeys("Canada");
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();
            state.SendKeys("Ontario");
            Thread.Sleep(4000);
            act.SendKeys(Keys.ArrowDown);
            act.SendKeys(Keys.Enter).Perform();

        }
        [FindsBy(How = How.XPath, Using = ".//*[@id='mainContent']/div[3]/div/div/div[2]/div[1]/div/div/div/div/div/form/div[3]/button")]
        private IWebElement searchClientInsurance { get; set; }
        

        

        public void addTravelersForInsurance(Actions act, String travellerName, String Title, String firstname, String lastname, String dT, String mN, String yR, String nationaliTy, ExtentTest test)
        {

            presenceOfElementUsingId(Browser.driver, "clientSearch");
            //Thread.Sleep(5000);
            addTraveler.SendKeys(travellerName);
            // Thread.Sleep(5000); 
            presenceOfElement(Browser.driver, ".//*[@id='mainContent']/div[3]/div/div/div[2]/div[1]/div/div/div/div/div/form/div[3]/button");

            searchClientInsurance.Click();
            selectTraveler.Click();

            presenceOfElement(Browser.driver, "//select[@name='Title']");

            selectFromDropdown(title, Title);
            firstName.SendKeys(firstname);
            lastName.SendKeys(lastname);
            selectFromDropdown(date, dT);
            selectFromDropdown(month, mN);
            selectFromDropdown(year, yR);
            selectFromDropdown(nationality, nationaliTy);

            fillInsuranceDetails(act);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,500)", "");

           }

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'clientsearch')]")]
        private IWebElement clientSearchButtonPF { get; set; }

        // add Traveler Planning Fee
        public void addTravellerPlanningFee(String travellerName, ExtentTest test)
        {
            presenceOfElementUsingId(Browser.driver, "clientSearch");
            addTraveler.SendKeys(travellerName);
            presenceOfElement(Browser.driver, "//button[contains(@class,'clientsearch')]");
            clientSearchButtonPF.Click();
            selectTraveler.Click();
            test.Log(Status.Info, "Traveler Name is selected for planning fee");
        }

        [FindsBy(How = How.XPath, Using = "//input[@class='traveler-verified']")]
        private IWebElement verified { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Continue']")]
        private IWebElement Continue { get; set; }

        public void verifyTravelersLegalNames(ExtentTest test)
        {

            presenceOfElement(Browser.driver, "//input[@class='traveler-verified']");
            verified.Click();

            presenceOfElement(Browser.driver, "//button[text()='Continue']");

            Continue.Click();
            test.Log(Status.Info, "traveler name verified");
            test.Log(Status.Info, "Booking is done");

        }
  }
}
