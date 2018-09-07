using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.com.traveledge.common
{
   
    public class ExtentReport
    {
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentReports extent;
        public static ExtentTest test;

        //  [OneTimeSetUp]
        /// <summary>
        /// Ectent report starts
        /// </summary>
        /// 

        private static bool  _isExecutedFirst = false;

        //[TestFixtureSetUp]

        [OneTimeSetUp]

        public void StartReport()
        {
            
                if (!_isExecutedFirst)
                {

                    string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                    string actualPath = path.Substring(0, path.LastIndexOf("bin"));
                    string projectPath = new Uri(actualPath).LocalPath;
                    string reportPath = projectPath + "Reports\\" + getDateTime() + "ADX.html";
                    htmlReporter = new ExtentHtmlReporter(@reportPath);
                    htmlReporter.Configuration().Theme = Theme.Dark;
                    htmlReporter.Configuration().DocumentTitle = "ADXDocument";
                    htmlReporter.Configuration().ReportName = "ADX_Report_Pritam";
                    extent = new ExtentReports();
                    extent.AttachReporter(htmlReporter);
                    extent.AddSystemInfo("OS", "Windows");
                    extent.AddSystemInfo("Host Name", "CI");
                    extent.AddSystemInfo("Environment", "QA");
                    extent.AddSystemInfo("User Name", "Pritam");

                    _isExecutedFirst = true;
                }
                        
            
            
        }


        public String getDateTime()
        {

            // Create object of SimpleDateFormat class and decide the format
            String dateFormat = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
            String currentDate = dateFormat.Replace(':', '_');

            return currentDate;

        }

        
        public void getResult()
        {
            TestStatus s = TestContext.CurrentContext.Result.Outcome.Status;

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
                // Take screen shot of the curent page

                string screenShotPath = GetScreenShot.Capture(Browser.driver, getDateTime());

                // GetScreenShot.GetEntereScreenshot(Browser.driver, "screenShotName");
                test.Log(Status.Fail, MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test case FAILED due to below issues:", ExtentColor.Red));
                test.Fail(TestContext.CurrentContext.Result.Message);

                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotPath));

               
            }
            else if (status == TestStatus.Passed)
            {
                test.Log(Status.Pass, MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test Case PASSED", ExtentColor.Green));
            }
            else
            {
                test.Log(Status.Skip, MarkupHelper.CreateLabel(TestContext.CurrentContext.Test.Name + " Test Case SKIPPED", ExtentColor.Orange));
                test.Skip(TestContext.CurrentContext.Test.FullName);
            }

            //Flush all status into Report
            extent.Flush();
        }

    }
}
