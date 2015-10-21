using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Dynamic;
using System.Linq;

namespace SimpleCSharpSelenium.Tests
{
    [TestClass]
    public class XpanxionTest
    {
        //Excessive commenting to help those just getting started
        //Thanks for using - Josh

        [TestMethod(), TestCategory(Constants.BUILD_VERIFICATION)]
        public void VerifyBuild()
        {
            //Start a firefox driver (browser)
            TestRunner.StartDriver(Constants.FIREFOX);
            //Navigate to google search page
            TestRunner.Driver.Navigate().GoToUrl(Constants.XPANXION);
            //Verify search page is where we are at!
            TestRunner.XpanxionHomePage.VerifyThisPageLoaded();
            //Test cleanup will run and kill the driver
        }

        //
        [TestMethod(), TestCategory(Constants.XPANXION_TEST)]
        public void TC1()
        {
            //Before running this test please set the Constants that are used!!!!!!!!
            //Setup the parameters, constructing the location of the file through constants
            TestRunner.ParametersSetup<Data.DataObjects.TC1>(Constants.DATADIRECTORY + MethodBase.GetCurrentMethod().Name + Constants.DATAFILEEXT);
            Data.DataObjects.TC1 testData = (Data.DataObjects.TC1)TestRunner.Parameters;
            //Setup the Environment and user data - default files used
            TestRunner.EnvironmentSetup();
            TestRunner.UserSetup();
            //Run tests through multiple browsers if applicable
            foreach (string browser in TestRunner.ActiveEnvironment.Browsers)
            {
                //Tell TestRunner to start a browser
                TestRunner.StartDriver(browser);
                //We have designed our test steps and the data to allow
             
                    //Navigate to the url being tested
                    TestRunner.Driver.Navigate().GoToUrl(TestRunner.ActiveEnvironment.Url);
                    TestRunner.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));

                    //Verify the page we expected loaded                 
                    TestRunner.XpanxionHomePage.VerifyThisPageLoaded();
                    TestRunner.XpanxionHomePage.ClickLinks();

                   
            }
        
        }

        [TestMethod(), TestCategory("Test all the things!")]
        public void TC2()
        {
            //Setup the Environment and user data - default files used
            TestRunner.EnvironmentSetup();
            TestRunner.UserSetup();
            //Run tests through multiple browsers if applicable
            foreach (string browser in TestRunner.ActiveEnvironment.Browsers)
            {
                //Tell TestRunner to start a browser
                TestRunner.StartDriver(browser);
               
                //Navigate to the url being tested
                TestRunner.Driver.Navigate().GoToUrl(TestRunner.ActiveEnvironment.Url);
                TestRunner.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(6));
                                                
                TestRunner.XpanxionHomePage.VerifyFooterLoaded();
                TestRunner.XpanxionHomePage.ClickFooterLinks();
            }
            
        }

        [TestMethod(), TestCategory("Test all the things!")]
        public void TC3()
        {
            
            //Setup the Environment and user data - default files used
            TestRunner.EnvironmentSetup();
            TestRunner.UserSetup();
            //Run tests through multiple browsers if applicable
            foreach (string browser in TestRunner.ActiveEnvironment.Browsers)
            {
                //Tell TestRunner to start a browser
                TestRunner.StartDriver(browser);
             
                //Navigate to the url being tested
                TestRunner.Driver.Navigate().GoToUrl(TestRunner.ActiveEnvironment.Url);
                TestRunner.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(4));

                //Verify the page we expected loaded
               
                TestRunner.XpanxionHomePage.ClickContact();
               
                TestRunner.XpanxionHomePage.ButtonClick();
                
                TestRunner.XpanxionHomePage.ErrorClassTest();
               
               
            }
            //remember that the [TestCleanup] method will run here.
        }

        #region TestInitialize, TestCleanup & Supporting methods

        /// <summary>
        /// Compare 2 Lists in order
        /// Will fail is count is different or text at each index is different.
        /// </summary>
        /// <param name="expected">Expected list</param>
        /// <param name="actual">Actual List</param>
        /// <returns>True if lists are the same</returns>
        public bool ListSame(List<string> expected, List<string> actual)
        {
            List<string> results = actual.Except(expected).ToList();
            if (results.Count == 0) { return true; }
            else { return false; }
        }


        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void InsightTestInitialize()
        {
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void InsightTestCleanup()
        {
            TestRunner.CleanupDriver();
        }
        #endregion
    }
}
