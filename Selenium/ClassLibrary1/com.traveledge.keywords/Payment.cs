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
    class Payment : WebDriverCommonLib
    {
        public Payment()
        {
            PageFactory.InitElements(Browser.driver, this);
        }

        [FindsBy(How = How.Id, Using = "firstName")]
        private IWebElement cardHolderFirstName { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@name='LastName']")]
        private IWebElement cardHolderLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='CreditCardNumber']")]
        private IWebElement cardNumber { get; set; }

        [FindsBy(How = How.Id, Using = "month")]
        private IWebElement expiryMonth { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='Year']")]
        private IWebElement expiryYear { get; set; }

        [FindsBy(How = How.Id, Using = "verificationCode")]
        private IWebElement verificationNumber { get; set; }

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement address { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
         private IWebElement city { get; set; }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country { get; set; }

        [FindsBy(How = How.Id, Using = "stateProvince")]
        private IWebElement state { get; set; }

        [FindsBy(How = How.Id, Using = "zipPostalCode")]
         private IWebElement zip { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='UseAddressForInvoice' and @value='Yes']")]
         private IWebElement noInvoiceAddressUseAddressEnteredHere { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='accept-toc-checkbox']")]
        private IWebElement acceptCondition { get; set; } 

        [FindsBy(How = How.Id, Using = "payAndTicket")]
        private IWebElement payAndTicket { get; set; }

        [FindsBy(How = How.Id, Using = "pay")]
        private IWebElement pay { get; set; }

        public void makePayment(String firstName,String lastName,String CardNumber,String expMonth,String expYear,String verificationCode,String Address,String City,String Country,String State,String Zip,ExtentTest test)
        {

            presenceOfElement(Browser.driver, "//input[@name='LastName']");

            cardHolderFirstName.SendKeys(firstName);
            cardHolderLastName.SendKeys(lastName);
            cardNumber.SendKeys(CardNumber);
            selectFromDropdown(expiryMonth, expMonth);
            selectFromDropdown(expiryYear, expYear);
            verificationNumber.SendKeys(verificationCode);
            address.SendKeys(Address);
            city.SendKeys(City);
            selectFromDropdown(country, Country);
            selectFromDropdown(state, State);
            zip.SendKeys(Zip);

            IJavaScriptExecutor jse = (IJavaScriptExecutor)Browser.driver;
            jse.ExecuteScript("window.scrollBy(0,500)", "");
            acceptCondition.Click();
            if (!payAndTicket.Enabled)
            {
                noInvoiceAddressUseAddressEnteredHere.Click();
            }
            try
            {
                payAndTicket.Click();
            }
            catch(Exception e)
            {
                presenceOfElementUsingId(Browser.driver, "pay");


                pay.Click();

            }
           
           
            
            waitForPageToLoad();
           // Thread.Sleep(120000);
            test.Log(Status.Info, "Payment is processing");
        }

    }
}
