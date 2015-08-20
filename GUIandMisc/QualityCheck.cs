#region Using Statements
using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Web;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;
using System.Drawing;
using Selenium;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
#endregion

namespace SeleniumRegression
{
    public enum CheckType { Link, Text, Element, Window, Equal, Warning }

    class QualityCheck
    {

        WebDriverBackedSelenium selenium;
        ParentTest test;
        int counter;


        public QualityCheck(ParentTest testtocheck)
        {
            selenium = testtocheck.selenium;
            test = testtocheck;
            counter = 0;
        }

        public bool ElementVisible(string fieldname)
        {

            try
            {
                if (selenium.IsVisible(fieldname))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                
            }
        }

        /// <summary>
        /// Check to see if a link is present and click it
        /// </summary>
        /// <param name="linkname">Id of the link</param>
        public void Click(string linkname)
        {
            counter++;

            try
            {
                if (IsElementPresent(linkname))
                {
                    if (ElementVisible(linkname))
                    {
                        selenium.Click(linkname);
                        test.passedcheck++;
                    }
                    else
                    {
                        test.failedcheck++;
                        ErrorReport(linkname, CheckType.Link);
                    }
                }
                else
                {
                    test.failedcheck++;
                    ErrorReport(linkname, CheckType.Link);
                }
            }
            catch (SeleniumException)
            {
                test.failedcheck++;
               ErrorReport(linkname, CheckType.Link); 
            }

            catch// (Exception e)
            {  
                test.failedcheck++;
                ErrorReport(linkname, CheckType.Link);                
            }
        }

        public void ErrorReport(string idname, CheckType type)
        {
            switch(type)
            {
                case CheckType.Link:
                    test.error += "\n                   Check #" + counter.ToString() + ": Link Check: " + idname + ": not present.\n      URL:" + selenium.UnderlyingWebDriver.Url + "\n";
                    break;
                case CheckType.Text:
                    test.error += "\n                   Check #" + counter.ToString() + ": Text Check: " + idname + ": not present.\n      URL:" + selenium.UnderlyingWebDriver.Url + "\n";
                    break;
                case CheckType.Element:
                    test.error += "\n                   Check #" + counter.ToString() + ": WebElement Check: " + idname + ": not present.\n      URL:" + selenium.UnderlyingWebDriver.Url + "\n";
                    break;
                case CheckType.Window:
                    test.error += "\n                   Check #" + counter.ToString() + ": Select Window or Popup: " + idname + ": not present.\n      URL:" + selenium.UnderlyingWebDriver.Url + "\n";
                    break;
                case CheckType.Equal:
                    test.error += "\n                   Check #" + counter.ToString() + ": Equals Check: " + idname + ": Text not equal.\n      URL:" + selenium.UnderlyingWebDriver.Url + "\n";
                    break;
                case CheckType.Warning:
                    test.error += "\n                   Check #" + counter.ToString() + ": Warning: Field ID " + idname + " not found";
                    break;
            }                        
        }

        /// <summary>
        /// Replaces the Assert.IsTrue method
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public bool IsTrue(bool check)
        {
            counter++;

            if (check == true)
            {
                test.passedcheck++;
                return true;
            }
            else
            {
                ErrorReport("General IsTrue check", CheckType.Equal);
                test.failedcheck++;
                return false;
            }
        }

        /// <summary>
        /// Check to see if an element is present on the screen
        /// </summary>
        /// <param name="fieldID"></param>
        /// <returns></returns>
        public bool IsElementPresent(string fieldID)
        {
            counter++;
            try
            {          
                    selenium.IsElementPresent(fieldID);
                    test.passedcheck++;
                    return true;                
            }
            catch// (Exception)
            {
                ErrorReport(fieldID, CheckType.Element);
                test.failedcheck++;
                
                return false;
            }
        }

        public string GetTable(string fieldID)
        {
            string text;
            try
            {
                text = selenium.GetTable(fieldID);
                return text;
            }
            catch// (Exception)
            {
                ErrorReport(fieldID, CheckType.Warning);
                return "";
            }
        }

        public void WaitForPageToLoad(string count)
        {
            try
            {
                selenium.WaitForPageToLoad(count);
            }
            catch (Exception)
            {
                   
            }
        }

        /// <summary>
        /// Get the title of the page
        /// Will throw a warning but not an error
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            string text;
            try
            {
                text = selenium.GetTitle();
                return text;
            }
            catch// (Exception)
            {
                ErrorReport("Title Of the Page", CheckType.Warning);
                return null;
            }
        }

        /// <summary>
        /// Get the value of a field, such as a text box
        /// Will throw a warning but not an error if unsuccessful
        /// </summary>
        /// <param name="fieldID"></param>
        /// <returns></returns>
        public string GetValue(string fieldID)
        {
            string text;
            try
            {
                text = selenium.GetValue(fieldID);
                return text;
            }
            catch// (Exception)
            {
                ErrorReport(fieldID, CheckType.Warning);
                test.warningcheck++;
                return null;
            }
        }

        /// <summary>
        /// Get the text from the provided field ID
        /// </summary>
        /// <param name="fieldID"></param>
        /// <returns></returns>
        public string GetText(string fieldID)
        {
            string text;
            try
            {
                text = selenium.GetText(fieldID);              
                return text;
            }
            catch// (Exception)
            {
                ErrorReport(fieldID, CheckType.Warning);
                return null;
            }

        }

        /// <summary>
        /// Check to see if the two texts are equal
        /// </summary>
        /// <param name="text">The expected text</param>
        /// <param name="field">The text that actually shows</param>
        public void AreEqual(string text, string fieldtext)
        {
            counter++;
            if (text == fieldtext)
            {
                test.passedcheck++;       
            }
            else
            {
                test.failedcheck++;
                ErrorReport(text, CheckType.Text);
                
            }
        }


        /// <summary>
        /// Checks the main HTML body to see if the text appears at least once
        /// </summary>
        /// <param name="expectedtext">The text to check for</param>
        public void CheckBodyForText(string expectedtext)
        {
            counter++;
            try
            {
                if (selenium.GetBodyText().Contains(expectedtext))
                {
                    test.passedcheck++;
                }
                else
                {
                    test.failedcheck++;
                    ErrorReport(expectedtext, CheckType.Text);
                    //test.error += "\n                 Test: " + test.id + ": Text: " + expectedtext + " not found.";
                }
            }
            catch// (Exception)
            {
                test.error += "\n*** Body unidentified.  Test unable to determine inner text.***";
                test.warningcheck++;
 
            }
        }

        /// <summary>
        /// Check a specific HTML area IE: "body", to see if the text appears
        /// </summary>
        /// <param name="areaname">The area of the page to check. Use Firebug for examples</param>
        /// <param name="expectedtext">The text to check for</param>
        public void CheckAreaForText(string areaname, string expectedtext)
        {
            counter++;
            try
            {
                if (selenium.GetText(areaname).Contains(expectedtext))
                {
                    test.passedcheck++;
                }
                else
                {
                    test.failedcheck++;
                    ErrorReport(expectedtext, CheckType.Text);
                    //test.error += "\n                  Test: " + test.id + ": Text: " + expectedtext + " not found.";
                }
            }
            catch// (Exception)
            {
                test.error += "\n*** " + areaname + " unidentified.  Test unable to determine inner text.***";
                test.warningcheck++;
   
            }
        }

        /// <summary>
        /// This selects a frame on a page such as the SSO widget to access the inner elements
        /// </summary>
        /// <param name="frameid">the frame string such as "gauth-widget-frame"</param>
        public void SelectFrame(string frameid)
        {
            counter++;
            try
            {
                selenium.SelectFrame(frameid);
                test.passedcheck++;
            }
            catch// (Exception)
            {
                test.failedcheck++;
                ErrorReport(frameid, CheckType.Window);
           
                
            }
        }

        /// <summary>
        /// Try closing the window with exception handling
        /// </summary>
        public void Close()
        {
            try
            {
                selenium.Close();
            }
            catch// (Exception)
            {
                ErrorReport("Window could not be closed", CheckType.Warning);
         
            }
        }

        /// <summary>
        /// Selects a different window.  Best results are found by using the window title
        /// </summary>
        /// <param name="windowid"></param>
        public void SelectWindow(string windowid)
        {
            counter++;
            try
            {
                selenium.SelectWindow(windowid);
                test.passedcheck++;
            }
            catch// (Exception)
            {
                test.failedcheck++;
                ErrorReport(windowid, CheckType.Window);
         
            }
        }

        /// <summary>
        /// Check to see how many times a text appears in the HTML body
        /// </summary>
        /// <param name="expectedtext">The text to check for</param>
        /// <returns>returns how many times the text appears</returns>
        public int TextRepetitionInBody(string expectedtext)
        {
            counter++;
            int count = 0;
            string bodytext = selenium.GetBodyText();
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    if (bodytext.Contains(expectedtext))
                    {
                        bodytext.Replace(expectedtext, "");
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch// (Exception)
            {
                test.error += "\n*** Body unidentified.  Test unable to determine inner text.***";
                test.warningcheck++;
                return counter;
            }

            return count;
        }

        /// <summary>
        /// Checks if an element is present.  This will not throw an error message or up the pass/fail cout
        /// </summary>
        /// <param name="elementname">The element to check</param>
        /// <returns>Returns true if the element can be highlighted</returns>
        public static bool ElementPresent(string elementname, WebDriverBackedSelenium selenium)
        {
            
            try
            {
                selenium.IsElementPresent(elementname);
                return true;
            }
            catch// (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Use this over the selenium Type command to send keys to a field, if you want to do a quality check
        /// </summary>
        /// <param name="fieldname"></param>
        /// <param name="input"></param>
        public void Type(string fieldname, string input)
        {
            counter++;
            try
            {
                if (IsElementPresent(fieldname))
                {
                    if (ElementVisible(fieldname))
                    {
                        selenium.Type(fieldname, input);
                        test.passedcheck++;
                    }
                    else
                    {
                        test.failedcheck++;
                        ErrorReport(fieldname, CheckType.Link);
                    }
                }
                else
                {
                    test.failedcheck++;
                    ErrorReport(fieldname, CheckType.Link);
                }
            }
            catch// (Exception)
            {
                test.failedcheck++;
                ErrorReport(fieldname, CheckType.Element);
            }

        }

        /// <summary>
        /// Check to see if the text is present on the page.  This does a quality check to record the results.
        /// </summary>
        /// <param name="text">The text to be found.</param>
        /// <returns></returns>
        public bool IsTextPresent(string text)
        {
            counter++;
            try
            {
                if (selenium.IsTextPresent(text))
                {
                    test.passedcheck++;
                    return true;
                }
                else
                {
                    ErrorReport(text, CheckType.Text);
                    //test.error += "\n               Test: " + test.id + ": Text: " + text + " not found.";
                    test.failedcheck++;
                    return false;
                }
            }
            catch// (Exception)
            {
                test.warningcheck++;
                test.error += "\n*** Body unidentified.  Test unable to determine inner text.***";
                return false;
            }
        }

        /// <summary>
        /// Use this to select a menu option from a field like a drop down.  See Selenium for advanced tips
        /// </summary>
        /// <param name="fieldID">The web element</param>
        /// <param name="option">The menu option</param>
        public void Select(string fieldID, string option)
        {
            counter++;

            try
            {
                if (IsElementPresent(fieldID))
                {
                    if (ElementVisible(fieldID))
                    {
                        selenium.Select(fieldID, option);
                        test.passedcheck++;
                    }
                    else
                    {
                        ErrorReport(fieldID, CheckType.Element);
                        test.failedcheck++;   
                    }
                }
                else
                {
                    ErrorReport(fieldID, CheckType.Element);
                    test.failedcheck++;   
                }

            }
            catch// (Exception)
            {
                ErrorReport(fieldID, CheckType.Element);               
                test.failedcheck++;              
            }
        }

        /// <summary>
        /// Check to make sure that text is NOT present.  Finding text will increase the fail number
        /// </summary>
        /// <param name="text">The text to ensure is not present</param>
        /// <returns></returns>
        public bool IsTextNotPresent(string text)
        {
            counter++;
            try
            {
                if (selenium.IsTextPresent(text))
                {
                    test.failedcheck++;
                    test.error += "\n              Test: " + test.id + ": Text: " + text + " found, but shouldn't be present.";
                    return false;
                }
                else
                {
                    test.passedcheck++;
                    return true;
                }
            }
            catch// (Exception)
            {
                test.warningcheck++;
                test.error += "\n*Exception thrown. Text not found. May not indicate a problem, as this was to determine text was not present.*";
                return true;
            }
        }

        /// <summary>
        /// Check to make sure the element is NOT present
        /// </summary>
        /// <param name="fieldID">Element to ensure is not present on the page</param>
        /// <returns></returns>
        public bool ElementNotPresent(string fieldID)
        {
            counter++;
            try
            {
                selenium.IsElementPresent(fieldID);
                test.failedcheck++;
                test.error += "\n             Test: " + test.id + ": Element: " + fieldID + " found, but shouldn't be present.";
                return false;
            }
            catch// (Exception)
            {
                test.passedcheck++;
                return true;
            }
        }

        public void Highlight(string fieldID)
        {
            counter++;
            try
            {
                selenium.Highlight(fieldID);
                test.passedcheck++;
            }
            catch// (Exception)
            {
                ErrorReport(fieldID, CheckType.Element);
                test.failedcheck++;            
            }
        }
        
    }
   
}
