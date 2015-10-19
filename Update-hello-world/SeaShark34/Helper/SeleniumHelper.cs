using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Drawing;
using System.Runtime.InteropServices;


namespace SimpleCSharpSelenium.Helper
{
    public static class SeleniumHelper
    {

        public static void WaitTemplate(IWebElement element, By by = null, int timeoutSeconds = 20, int pollingIntervalMilliseconds = 1000)
        {
            if (by == null)
            {
                by = By.Id("garbage");
            }

            int i = 0;

            try
            {
                //sets the implicit wait to zero for the element parameter
                TestRunner.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
                WebDriverWait Wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(timeoutSeconds));
                Wait.PollingInterval = TimeSpan.FromMilliseconds(pollingIntervalMilliseconds);
                //Using the below statement you can have the wait itself ignore one or many thrown exception types
                //Doing this would keep the wait until running even if those exceptions are  
                //Wait.IgnoreExceptionTypes(typeof(NoSuchFrameException),typeof(NoSuchElementException),
                //    typeof(NoSuchWindowException),typeof(StaleElementReferenceException));

                // d below is the webdriver we have created to use the polling mechanism and time out
                // we may use d if we need to using the By in the parameters.  Remember d's implicit wait will be 0
                Wait.Until<bool>((d) =>
                {
                    i++;
                    System.Diagnostics.Debug.WriteLine("Starting the Logic");
                    System.Diagnostics.Debug.WriteLine("i =  " + i + " time is " + DateTime.Now.ToString("h:mm:ss.fff tt"));
                    try
                    {
                        if (i > 10)
                        {
                            //cause an exception by navigating away from google but still looking for Google element
                            TestRunner.Driver.Navigate().GoToUrl(Constants.YAHOO_URL);
                            System.Diagnostics.Debug.WriteLine("Now on yahoo find starts at " + DateTime.Now.ToString("h:mm:ss.fff tt"));
                            element.GetAttribute("value");
                            return true; //would kill the wait.until - this is what you would return when your condition is met - we never get here becaue previous line throws error
                        }
                        else
                        {
                            if (i <= 10)
                            {
                                System.Diagnostics.Debug.WriteLine("element value " + element.GetAttribute("value") + " time is " + DateTime.Now.ToString("h:mm:ss.fff tt"));
                                // Throw exception with d by looking for garbage
                                System.Diagnostics.Debug.WriteLine("try to use d.FindElemnt " + d.FindElement(by).Text + " time is " + DateTime.Now.ToString("h:mm:ss.fff tt"));
                            }
                            return false; // wait.until keeps going
                        }
                    }
                    catch (NoSuchElementException e)
                    {
                        System.Diagnostics.Debug.WriteLine("When NSE exception caught " + DateTime.Now.ToString("h:mm:ss.fff tt"));
                        System.Diagnostics.Debug.WriteLine(e);
                        return false; // wait.until keeps going
                    }
                    catch (StaleElementReferenceException e)
                    {
                        System.Diagnostics.Debug.WriteLine("When SERE exception caught " + DateTime.Now.ToString("h:mm:ss.fff tt"));
                        System.Diagnostics.Debug.WriteLine(e);
                        return false; // wait.until keeps going
                    }
                });
            }
            catch (Exception e)
            {
                //this means the wait threw an exception and is done trying
                System.Diagnostics.Debug.WriteLine("Wait Until Exception at " + DateTime.Now.ToString("h:mm:ss.fff tt"));
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                //Must reset implicit wait for the TestRunner.Driver to or it will remain 0
                TestRunner.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Constants.IMPLICIT_WAIT_DEFAULT));
                System.Diagnostics.Debug.WriteLine("In finally: WebDriver reset to Default implicit wait default = " + Constants.IMPLICIT_WAIT_DEFAULT);
            }

        }        
        
        
        
        
        /// <summary>
        /// Waits for an element's .displayed attribute to be false.  Sometimes unreliable 
        /// </summary>
        /// <param name="id">HTML element id</param>
        public static void WaitForElementInvisible(By by, int waitSecs = 60)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(waitSecs));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(by);
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an element's .displayed attribute to be false.  Sometimes unreliable
        /// </summary>
        /// <param name="className"> Class name from HTML</param>
        public static void WaitForElementInvisibleByClassName(string className)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(10));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.ClassName(className));
                    return !element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an element's .displayed attribute to be true.  Sometimes unreliable
        /// </summary>
        /// <param name="id">HTML id of the element</param>
        /// <param name="waitSecs">seconds to wait before timeout</param>
        public static void WaitForElementVisible(By by, int waitSecs)
        {
            WebDriverWait Wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(waitSecs));
            Wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(by);
                    return element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an elements test to change form the passed in intial state.
        /// </summary>
        /// <param name="id">HTML id of the element</param>
        /// <param name="initialText">starting text of the element</param>
        public static void WaitForTextChanged(By by, string initialText)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(25));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(by);
                    if (String.Compare(element.Text, "", true) != 0)
                    {
                        if (String.Compare(element.Text, initialText, true) != 0)
                        {
                            return true;
                        }
                        else { return false; }
                    }
                    else { return false; }
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }


        /// <summary>
        /// Waits for an element to have no child image.  
        /// Good for use when spinners are employed
        /// </summary>
        /// <param name="id">HTML id of element</param>
        public static void WaitForElementHaveNoChildImg(By by)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(25));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(by);
                    element.FindElement(By.TagName("img"));
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }

        /// <summary>
        /// Waits for an image to be not found on the page using 
        /// the source path to identify the image
        /// </summary>
        /// <param name="src">source path</param>
        public static void WaitForImageBySourceInvisible(string src)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(25));
            wait.Until<bool>((d) =>
            {
                try
                {
                    IWebElement element = d.FindElement(By.XPath("//img[contains(@src,'" + src + "')]"));
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }


        /// <summary>
        /// Uses javascript execute to click an element
        /// Useful when DOM thinks an element is invisible and it is not
        /// Also helpful when scrolling to an element in a list doesn't work
        /// </summary>
        /// <param name="element">the element to click</param>
        public static void ClickWithJs(IWebElement element)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public static void ClickWithMouseEvent(IWebElement element)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].dispatchEvent(new MouseEvent('click', {view: window, bubbles:true, cancelable: true}))", element);
        }


        /// <summary>
        /// Highlight an element for a time 
        /// Useful in debugging
        /// </summary>
        /// <param name="element">the eleement to highlight</param>
        /// <param name="time">time to highlight before returning to normal</param>
        public static void HighlightElement(IWebElement element, int time = 20000)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            String oldStyle = element.GetAttribute("style");
            String args = "arguments[0].setAttribute('style', arguments[1]);";
            js.ExecuteScript(args, element, "border: 4px solid yellow;display:block;");
            Thread.Sleep(time);
            js.ExecuteScript(args, element, oldStyle);

        }

        /// <summary>
        /// Checks if a string is null or empty
        /// </summary>
        /// <param name="toCheck">string to check</param>
        /// <returns></returns>
        public static bool CheckNull(string toCheck)
        {
            if (string.IsNullOrEmpty(toCheck)) { return true; }
            else { return false; }
        }
       
        /// <summary>
        /// Clear and then fill a textbox
        /// Great to ensure textbox filled as desired
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="text"></param>
        public static void ClearAndFillTextBox(IWebElement elem, string text)
        {
            elem.Clear();
            if (!CheckNull(text))
            {
                elem.SendKeys(text.Trim());
            }
        }

        /// <summary>
        /// Selects an item in a dropdown. if you pass an empty text prameter it will select the passed default
        /// </summary>
        /// <param name="elem">DD element</param>
        /// <param name="text">text to select or empty if you want th edefault</param>
        /// <param name="defaultSelection">the default to use</param>
        public static void SelectDropDownByTextWithEmptyDefault(SelectElement element, string text, string defaultSelection)
        {
            if (!CheckNull(text))
            {
                element.SelectByText(text.Trim());
            }
            else { element.SelectByText(defaultSelection); }
        }


        /// <summary>
        /// When interacting with more than one window, wait until the count of windows equals what you want
        /// </summary>
        /// <param name="numberOfWindows">number of windows</param>
        /// <param name="timeoutSecs">seconds to wait before timeout</param>
        public static void WaitForNumberOfWindowsToEqual(int numberOfWindows, int timeoutSecs)
        {
            WebDriverWait wait = new WebDriverWait(TestRunner.Driver, TimeSpan.FromSeconds(timeoutSecs));
            wait.Until(drv => drv.WindowHandles.Count == numberOfWindows);
        }

        /// <summary>
        /// Returns windows title text by given handle number.
        /// </summary>
        /// <param name="WindowHandle"></param>
        /// <returns></returns>
        public static string GetWindowTitleByWindowHandleByIndex(int WindowHandle = 0)
        {
            string winTitle = String.Empty;
            string currentWindowHandle = TestRunner.Driver.WindowHandles[0];
            if (TestRunner.Driver.WindowHandles.Count > 1)
            {
                TestRunner.Driver.SwitchTo().Window(TestRunner.Driver.WindowHandles[WindowHandle]);
                winTitle = TestRunner.Driver.Title;
                // Reset back to calling window as active window.
                TestRunner.Driver.SwitchTo().Window(currentWindowHandle);
            }
            return winTitle;
        }

        /// <summary>
        /// Returns the inner HTML for input element.
        /// </summary>
        /// <param name="webElement"></param>
        /// <returns></returns>
        public static string GetInnerHTMLThroughJS(IWebElement webElement)
        {
            //In case of hidden element "Text" property do not return value even it is present. 
            //In such case this method is useful
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            var innerHTML = js.ExecuteScript("return arguments[0].innerHTML", webElement);
            return innerHTML.ToString();
        }

        /// <summary>
        /// Run javascript
        /// </summary>
        /// <param name="jscriptToRun"></param>
        /// <param name="currentWindowHandle"></param>
        /// <returns></returns>
        public static string RunJavaScript(string jscriptToRun, string currentWindowHandle)
        {
            IJavaScriptExecutor js = TestRunner.Driver as IJavaScriptExecutor;
            return js.ExecuteScript("return " + jscriptToRun, currentWindowHandle).ToString();
        }
    }
}
