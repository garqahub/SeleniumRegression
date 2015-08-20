/* 3/7/12
 * Original Author: Michael Schultz
 * Description: This is the parent class from which all tests will inherit from.
 * Purpose: This is done for compatibility for tests to be included in the same collection 
 */

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
using Selenium;
#endregion

namespace SeleniumRegression
{
   
    class ParentTest
    {

        #region childstrings
        public string id;  //for Identification of script in reporting
        public string error; // for Identification of error in reporting
        public string expected;  //for Identification of expected text in reporting
        public string field;  //for ID of the data field that was incorrect
        public int passedcheck, failedcheck, warningcheck; //pass/fail counters
        public string username, password, fullname, unitId, unitIdNotRegistered, unitIdRegistered, validationCode, productKey;
        public QualityCheck quality;
        public WebDriverBackedSelenium selenium;  //for selenium
        protected StringBuilder verificationErrors; //for selenium
        public string baseURL; //for selenium
        public DateTime time;
        public string description;
       
        #endregion

        /// <summary>
        /// Constructor for the parent class of the tests
        /// </summary>
        public ParentTest()
        {
            passedcheck = 0;
            failedcheck = 0;
            warningcheck = 0;
            time = DateTime.Now;
        }

         public virtual void RunTest()
        {
        }

        /// <summary>
        /// Is not being used currently.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="webdriver"></param>
         public virtual void Initialize(string url, WebDriverBackedSelenium webdriver)
         {
             baseURL = url;  //Be sure to update the selenium.Open command with baseURL
             selenium = webdriver;
         }

        //The below methods are legacy.  Use the QualityCheck class for exception handled actions with reporting.
         #region Field ID Checkers
         /// <summary>
        /// Checks to see if a field is present by trying to click on it.  If not it will return false.
        /// </summary>
        /// <param name="instancedriver">The current web driver.</param>
        /// <param name="fieldID">The field ID to check for.</param>
        /// <returns></returns>
         public virtual bool IDPresent(string fieldID)
         {
             try
             {

                 selenium.Highlight(fieldID);
                 passedcheck++;
                 return true;

             }
             catch (Exception)
             {
                 field = fieldID;
                 failedcheck++;
                 error += "\n            Test: " + id + ": " + fieldID + " field not present.";
                 return false;
                 // throw;
             }
             finally
             {
                   
             }
                      
 
         }

         public virtual void ResetCounters()
         {
             warningcheck = 0;
             passedcheck = 0;
             failedcheck = 0;
         }

        /// <summary>
        /// Check to see if the value is correct within the field.  If not it will return false.
        /// </summary>
        /// <param name="instancedriver">The current web driver.</param>
        /// <param name="fieldID">The field ID to check.</param>
        /// <param name="expectedtext">The expected text in string value.  Must be exact.</param>
        /// <returns></returns>
         public virtual void ValuePresent(string fieldID, string expectedtext)
         {
             if (IDPresent(fieldID))
             {
                 if (selenium.GetText(fieldID).Contains(expectedtext))
                 {
                     passedcheck++;

                 }
                 else
                 {
                     expected = expectedtext;
                     error += "\n             Test: " + id + ": " + fieldID + " value check returned false.  " + expectedtext 
                         + " expected.  Actual is " + selenium.GetText(fieldID);
                     verificationErrors.Append("Test: " + id + " " + fieldID + " value check returned false.  " 
                         + expectedtext + " expected.  Actual is " + selenium.GetText(fieldID));
                     failedcheck++;

                 }
             }

         }
#endregion

         #region Link Checkers
         public virtual bool LinkPresent(string fieldID)
         {
             try
             {
                 selenium.Highlight(fieldID);
                 passedcheck++;
                 return true;

             }
             catch (Exception)
             {
                 field = fieldID;
                 failedcheck++;
                 error += "\n             Test: " + id + ": " + fieldID + " Link not present.";
                 return false;
                 // throw;
             }
         }

         public virtual void LinkValuePresent(string fieldID, string expectedtext)
         {
             if (LinkPresent(fieldID))
             {
                 if (selenium.GetText(fieldID).Contains(expectedtext))
                 {
                     passedcheck++;

                 }
                 else
                 {
                     expected = expectedtext;
                     error += "\n                 Test: " + id + ": " + fieldID + " Link check returned false.  " + expectedtext
                         + " expected.  Actual is " + selenium.GetText(fieldID);
                     verificationErrors.Append("\nTest: " + id + " " + fieldID + " value check returned false.  "
                         + expectedtext + " expected.  Actual is " + selenium.GetText(fieldID));
                     failedcheck++;

                 }
             }
          }
         #endregion

         #region Text Check
         /// <summary>
        /// Use this method to check the main body to see if the text is present
        /// </summary>
        /// <param name="instancedriver">The Web driver</param>
        /// <param name="expectedText">The expected text</param>
        /// <returns></returns>
         public virtual void IsTextPresent(string expectedText)
         {
             try
             {
                 if (selenium.GetText("body").Contains(expectedText))
                 {
                     passedcheck++;                                       
                 }
                 else
                 {
                     failedcheck++;
                     error += "\n           Test: " + id + ": Text: " + expectedText + " not found.";                    
                 }
             }
             catch (Exception)
             {
                 error += "\n*** Body unidentified.  Test unable to determine inner text.***";
                 warningcheck++;
             }

         }
        #endregion

         #region Partial Link text
         public virtual bool PartialLinkText(string partialtext)
         {
             try
             {
                 selenium.Highlight(partialtext);
                 passedcheck++;
                 return true;
             }
             catch (Exception)
             {
                 error += "\n           Test: " + id + ": Link Text: " + partialtext + " not found.";
                 failedcheck++;
                 return false;
             }
         }
#endregion
         public virtual bool IsNamePresent(string name)
         {
             try
             {
                 selenium.GetText(name);
                 passedcheck++;
                 return true;
             }
             catch (Exception)
             {
                 error += "\n           Test: " + id + ": Name: " + name + " not found.";
                 failedcheck++;
                 return false;
             }
         }

    }
}
