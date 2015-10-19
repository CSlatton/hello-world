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
    public class XpanxionAboutPage
    {
        public XpanxionAboutPage()
        {

        }

        #region Actions

        #endregion

        #region Verifications

        public void VerifyThisPageLoaded()
        {
            Assert.IsNotNull(ThinkRuralLogo());
        }

        #endregion

        #region Controls

        public IWebElement ThinkRuralLogo()
        {
            return TestRunner.Driver.FindElement(By.Id("u3097-6"));
        }

        #endregion

        #region Methods

        #endregion

    }
}
