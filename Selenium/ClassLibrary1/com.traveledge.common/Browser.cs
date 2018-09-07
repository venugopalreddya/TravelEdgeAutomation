using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.common
{
    public class Browser 
    {
        public static IWebDriver driver;
       
        /// <summary>
        /// Selecting Browser
        /// </summary>
        /// <param name="browserName"></param>
        /// <returns></returns>
        public static IWebDriver getBrowser(string browserName)
        {
            if (browserName.Equals("Chrome")) {

                ChromeOptions options = new ChromeOptions();
                options.AddArgument("no-sandbox");
                options.AddArgument("disable-infobars");
                options.AddArgument("--disable-extensions");
                options.AddArgument("test-type");
                options.AddArgument("start-maximized");
                options.AddArgument("--js-flags=--expose-gc");
                options.AddArgument("--enable-precise-memory-info");
                options.AddArgument("--disable-popup-blocking");
                options.AddArgument("--disable-default-apps");
                options.AddArgument("test-type=browser");
                options.AddArgument("disable-infobars");
                options.AddUserProfilePreference("credentials_enable_service", false);
                options.AddUserProfilePreference("profile.password_manager_enabled", false);
                options.AddArgument("no-sandbox");

                WebDriverCommonLib wlb = new WebDriverCommonLib();
                driver = new ChromeDriver(options);
                wlb.waitForPageToLoad();
            }
           else if (browserName.Equals("Firefox"))
            {
                FirefoxProfile profile = new FirefoxProfile();
                profile.AddExtension(@"D:\firebug-3.0.0-beta.3.xpi");
                //profile.AddExtension(@"C:\path\to\extension.xpi");
                //driver = new FirefoxDriver(profile);
            }
           else if (browserName.Equals("IE"))
            {
                driver = new InternetExplorerDriver();
            }
           return driver;
        }
        

    }


}
