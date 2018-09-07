using ClassLibrary1.com.traveledge.common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.keywords
{
   public class Login : WebDriverCommonLib
    {

        public Login()
        {
        PageFactory.InitElements(Browser.driver, this);
        }

    
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement userNameEdt { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement passwordEdt { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-login']")]
        private IWebElement signIn { get; set; }
       // public static object Class { get; internal set; }

        public void navigateToApp(String url)
        {

           
            Browser.driver.Url = (url);
            waitForPageToLoad();
            waitForPageLoadTimeOut();
            presenceOfElement(Browser.driver, "//button[@class='btn btn-primary btn-login']");


        }

        public void loginToAPP(String userName, String passWord)
        {
            userNameEdt.SendKeys(userName);
            passwordEdt.SendKeys(passWord);

            
            try
            {
                signIn.Click();
            }
            catch (Exception e)
            {
                signIn.Click();
            }

            waitForPageToLoad();
        }
    }
}
