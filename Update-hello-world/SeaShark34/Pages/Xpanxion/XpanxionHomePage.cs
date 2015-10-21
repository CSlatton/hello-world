using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;

namespace SimpleCSharpSelenium.Pages
{
   public class XpanxionHomePage
    {
       public XpanxionHomePage()
       {
       }
          #region Actions

       //find the element 
       public void ClickLinks()
       {
           ClickAboutLink();
           VerifyThisPageLoaded();
           ClickApproach();
           VerifyThisPageLoaded();
           ClickServices();
           VerifyThisPageLoaded();
           ClickCareers();
           VerifyThisPageLoaded();
           ClickContact(); 
           
       }

       public void ClickFooterLinks()
       {
           ClickFooterAbout();
           Wait();
           ClickFooterLocation();
           Wait();
           ClickFooterMission();
           Wait();
           ClickFooterNews();
           Wait();
           ClickFooterOurStory();
          
       }

       // set up button click
       public void ButtonClick()
       {
           SubmitButton().Click();
       }

        #endregion

        #region Verifications

       // use assertions to test page is not null
        public void VerifyThisPageLoaded()
        {
            Assert.IsNotNull(AboutLink());
            Assert.IsNotNull(ApproachLink());
            Assert.IsNotNull(ServicesLink());
            Assert.IsNotNull(CareersLink());
            Assert.IsNotNull(ContactLink());
        }

        public void VerifyFooterLoaded()
        {
            Assert.IsNotNull(FooterAbout());
            Assert.IsNotNull(FooterOurStory());
            Assert.IsNotNull(FooterLocations());
            Assert.IsNotNull(FooterMission());
            Assert.IsNotNull(FooterNews());
        }

        public void VerifyError()
        {
            // make sure this is not empty 
            Assert.IsNotNull(ErrorClassTest());
        }

       public void AboutVerify()
        {
            Assert.IsTrue(AboutTest());
        }

       public void ApproachVerify()
       {
           Assert.IsTrue(approachLinkTest());
       }

       public void ServicesVerify()
       {
           Assert.IsTrue(servicesLinkTest());
       }

       public void CareersVerify()
       {
           Assert.IsTrue(careersLinkTest());
       }

       public void ContactVerify()
       {
           Assert.IsTrue(contactLinkTest());
       }

       public void LocationsVerify()
       {
           Assert.IsTrue(locationsLinkTest());
       }

       public void missionVerify()
       {
           Assert.IsTrue(missionLinkTest());
       }

       public void newsVerify()
       {
           Assert.IsTrue(newsLinkTest());
       }

        #endregion

        #region Controls

       // Find the location of the element 
        public IWebElement ThinkRuralLogo()
        {
            return TestRunner.Driver.FindElement(By.Id("u3097-6"));
        }

       public IWebElement AboutLink()
        {
            return TestRunner.Driver.FindElement(By.Id("u115"));
        }

       public IWebElement ApproachLink()
       {
           return TestRunner.Driver.FindElement(By.Id("u127"));
       }

       public IWebElement ServicesLink()
       {
           return TestRunner.Driver.FindElement(By.Id("u120"));
       }

       public IWebElement CareersLink()
       {
           return TestRunner.Driver.FindElement(By.Id("u15732"));
       }

       public IWebElement ContactLink()
       {
           return TestRunner.Driver.FindElement(By.Id("u144-4"));
       }

       // footer 
       public IWebElement FooterAbout()
       {
           return TestRunner.Driver.FindElement(By.Id("u10570-4_img"));
       }

       public IWebElement FooterOurStory()
       {
           return TestRunner.Driver.FindElement(By.Id("u10578-4"));
       }

       public IWebElement FooterLocations()
       {
           return TestRunner.Driver.FindElement(By.Id("u10577-4"));
       }

       public IWebElement FooterMission()
       {
           return TestRunner.Driver.FindElement(By.Id("u10576-4"));
       }

       public IWebElement FooterNews()
       {
           return TestRunner.Driver.FindElement(By.Id("u10575-4"));
       }

       // should be in its own class I am lazy 
       public IWebElement SubmitButton()
       {
           return TestRunner.Driver.FindElement(By.Id("u1679-17"));
       }

       public IWebElement ErrorClassTest()
       {
           return TestRunner.Driver.FindElement(By.ClassName("fld-err-st"));
           
          
       }

        #endregion

        #region Methods

       public void Wait()
       {
           TestRunner.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(6));
       }

       public bool AboutTest()
       {
           if (TestRunner.Driver.Url.ToString().Equals("http://xpanxion.com/about.html"))
               
               return true;
           else
               return false;
       }

       public bool approachLinkTest()
       {
           if (TestRunner.Driver.Url.ToString().Equals("http://xpanxion.com/approach.html"))

               return true;
           else
               return false;
       }

       public bool servicesLinkTest()
       {
           if (TestRunner.Driver.Url.ToString().Equals("http://xpanxion.com/services.html"))

               return true;
           else
               return false;
       }

       public bool careersLinkTest()
       {
           if (TestRunner.Driver.Url.ToString().Equals("http://xpanxion.com/careers.html"))

               return true;
           else
               return false;
       }

       public bool contactLinkTest()
       {
           if (TestRunner.Driver.Url.ToString().Equals("http://xpanxion.com/contact.html"))

               return true;
           else
               return false;
       }

       public bool locationsLinkTest()
       {
           if (TestRunner.Driver.Url.ToString().Equals("http://xpanxion.com/locations.html"))

               return true;
           else
               return false;
       }

       public bool missionLinkTest()
       {
           if (TestRunner.Driver.Url.ToString().Equals("http://xpanxion.com/mission.html"))

               return true;
           else
               return false;
       }

       public bool newsLinkTest()
       {
           if (TestRunner.Driver.Url.ToString().Equals("http://xpanxion.com/news.html"))

               return true;
           else
               return false;
       }

       public void ClickAboutLink()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(AboutLink()).Build().Perform();
           AboutTest();
       }

       public void ClickApproach()
       {
         //  AboutVerify();
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(ApproachLink()).Build().Perform();
           ApproachVerify();
       }

       public void ClickServices()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(ServicesLink()).Build().Perform();
           ServicesVerify();
       }

       public void ClickCareers()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(CareersLink()).Build().Perform();
           CareersVerify();
       }

       public void ClickContact()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(ContactLink()).Build().Perform();
           ContactVerify();
       }

       public void ClickFooterAbout()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterAbout()).Build().Perform();
           AboutVerify();
       }

       public void ClickFooterOurStory()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterOurStory()).Build().Perform();
       }

       public void ClickFooterLocation()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterLocations()).Build().Perform();
           LocationsVerify();
       }

       public void ClickFooterMission()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterMission()).Build().Perform();
           missionVerify();
       }

       public void ClickFooterNews()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterNews()).Build().Perform();
           newsVerify();
       }


        #endregion

    }
}
  
