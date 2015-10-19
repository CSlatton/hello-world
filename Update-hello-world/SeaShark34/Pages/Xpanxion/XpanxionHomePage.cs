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
         
           ClickApproach();
          
           ClickServices();
           
           ClickCareers();
           
           ClickContact();
           
       }

       public void ClickFooterLinks()
       {
           ClickFooterAbout();
          
           ClickFooterLocation();
         
           ClickFooterMission();
           
           ClickFooterNews();
           
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

      // end of lazy code

        #endregion

        #region Methods

       public void ClickAboutLink()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(AboutLink());
       }

       public void ClickApproach()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(ApproachLink());
       }

       public void ClickServices()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(ServicesLink());
       }

       public void ClickCareers()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(CareersLink());
       }

       public void ClickContact()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(ContactLink());
       }

       public void ClickFooterAbout()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterAbout());
       }

       public void ClickFooterOurStory()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterOurStory());
       }

       public void ClickFooterLocation()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterLocations());
       }

       public void ClickFooterMission()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterMission());
       }

       public void ClickFooterNews()
       {
           Actions action = new Actions(TestRunner.Driver);
           action.DoubleClick(FooterNews());
       }


        #endregion

    }
}
  
