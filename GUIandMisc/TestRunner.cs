/* Date: 3/6/12
 * Author: Michael Schultz
 * Description: Parent class to drive the test automation
 * Purpose: This is the parent class for test automation 
 * To Do: --Add loading of test set values and definitions--
 *        --Add in Reporting to Textbox and Output file--
 *        Done as of 5/15/2012- MS
 *        Need Object recycling to fix GC calls over extended run.
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
using System.Windows.Forms;
using System.Drawing;
using Selenium;
#endregion

namespace SeleniumRegression
{
    public enum fonttype { Browserfont, TestFont, ScriptFont, RegularFont, ErrorFont }

    class TestRunner
    {

        #region Variables
        public RichTextBox reporterBox; //passing along the textbox from the GUI for reporting
        public List<string> browsers, scriptset; //base lists for use by child class
        protected WebDriverBackedSelenium webdriver; //for selenium
        protected StringBuilder verificationErrors; //ditto
        protected string baseURL; //url for child project
        public int testcount, errorcount, passedcount, warningcount;//For GUI reporting boxes
        public FirefoxProfile ffprofile;//FF needed this for interal firewall config
        public Proxy prxsettings;//ditto^^
        protected Font browsertext, testtext, scripttext, regulartext, errortext;//Types of fonts for reporting
        public List<List<ParentTest>> scriptlist;//Group of scripts to grab test names
        public List<ParentTest> objectpool;
        #endregion

        #region Constructor
        public TestRunner()
        {
            testcount = 0;
            errorcount = 0;
            passedcount = 0;
            warningcount = 0;
            ffprofile = new FirefoxProfile();//For internal firewal
            prxsettings = new Proxy();//Ditto^^
            prxsettings.IsAutoDetect = true;//Ditto x2
            ffprofile.SetProxyPreferences(prxsettings);//ditto x3
            browsertext = new Font(FontFamily.GenericSansSerif, 14f, FontStyle.Bold); //These were picked
            testtext = new Font(FontFamily.GenericSansSerif, 10f, FontStyle.Regular); //to give better emphasis
            scripttext = new Font(FontFamily.GenericSansSerif, 10.5f, FontStyle.Bold);//for reporting
            regulartext = new Font(FontFamily.GenericSansSerif, 8f, FontStyle.Regular);//can be changed
            errortext = new Font(FontFamily.GenericSerif, 9.5f, FontStyle.Regular);//if better combo is found
            scriptlist = new List<List<ParentTest>>();//For grabbing the individual tests.  The order they are added matters for index purposes.
            objectpool = new List<ParentTest>(); //list to hold old tests for recycling.
            //Thread.Sleep(1000);
            
        }
        #endregion

        #region SendTests
        /// <summary>
        /// This is used for grabbing the individual test names for the GUI
        /// </summary>
        /// <returns>Returns a list of a list of test names to the GUI.  Could send a reference to the tests to show the descriptions in a future version</returns>
        public virtual List<List<string>> SendTests()
        {
            List<List<string>> tests = new List<List<string>>();

            for (int i = 0; i < scriptlist.Count; i++)
            {
                tests.Add(new List<string>());
                for (int j = 0; j < scriptlist[i].Count; j++)
                {
                    tests[i].Add(scriptlist[i][j].id);
                }
            }

            return tests;
        }
        #endregion

        #region AddText

        /// <summary>
        /// Picks the appropriate font and color and writes to the the GUI
        /// </summary>
        /// <param name="newtext">The text to add</param>
        /// <param name="font">Enum defining what type of message it is.  The properties for each font are assigned in the constructor</param>
        public virtual void AddText(string newtext, fonttype font)
        {        

            switch (font)
            {
                case fonttype.Browserfont:
                    reporterBox.SelectionColor = Color.Black;
                    reporterBox.SelectionFont = browsertext;
                    break;
                case fonttype.ErrorFont:
                    reporterBox.SelectionColor = Color.Red;
                    reporterBox.SelectionFont = errortext;
                    break;
                case fonttype.RegularFont:
                    reporterBox.SelectionColor = Color.Black;
                    reporterBox.SelectionFont = regulartext;
                    break;
                case fonttype.ScriptFont:

                    reporterBox.SelectionColor = Color.Black;
                    reporterBox.SelectionFont = scripttext;
                    break;
                case fonttype.TestFont:
                    reporterBox.SelectionColor = Color.DarkBlue;
                    reporterBox.SelectionFont = testtext;
                    break;
            }
            if (newtext != null)
            {
                reporterBox.AppendText("\n" + newtext);
            }

            //reporterBox.Text += "\n" + newtext;
            reporterBox.Refresh();            
        }
        #endregion

        #region Setup and Teardown test
        /// <summary>
        /// Here's where the webdriver's being instanced. Based on the browser, the arguements change. 
        /// </summary>
        /// <param name="browser">The browser version tells us what argument to pass to the driver.</param>
        [SetUp]
        public virtual void SetupTest(string browser)
        {
            //AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            AddText("\nBrowser " + browser + " initialized.", fonttype.Browserfont);
            reporterBox.SelectionFont = regulartext;
            switch (browser)
            {
                case "Internet Explorer":
                    webdriver = new WebDriverBackedSelenium(new InternetExplorerDriver(),baseURL);                    
                    webdriver.Start();                    
                    break;
                case "Chrome":
                    webdriver = new WebDriverBackedSelenium(new ChromeDriver(), baseURL);
                    webdriver.Start();
                    break;
                case "FireFox":
                    webdriver = new WebDriverBackedSelenium(new FirefoxDriver(ffprofile), baseURL);
                    webdriver.Start();
                    break;
            }

        }

        [TearDown]
        public virtual void TeardownTest()
        {
            try
            {
                webdriver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            //Assert.AreEqual("", verificationErrors.ToString());
        }
        #endregion

        #region Recycling

        /// <summary>
        /// As a matter of good practice it's better to grab instanced objects and hold and reuse rather than 
        /// relying on GC calls as they can impact performance.
        /// </summary>
        /// <param name="group">The group you want to clear of tests</param>
        public virtual void RecyclingObjects(List<ParentTest> group)
        {
            for (int i = 0; i < group.Count ; i++)
            {
                objectpool.Add(group[i]);
            }
            group.Clear();
        }
        /// <summary>
        /// Check to see if there are any instanced objects that can be recycled.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="test"></param>
        public virtual void AddTest(List<ParentTest> group, ParentTest test)
        {
            int index = objectpool.Count;

        }

        #endregion

        #region Virtual Methods to be overridden
        /// <summary>
        /// These are just being made visible to the GUI for each project.
        /// </summary>
        public virtual void PopulateLists()
        {

        }
        public virtual void RunTests(int index, int testnumber)
        {
        }
        public virtual void RunTests()
        {

        }

        public virtual void CycleScripts()
        {
            reporterBox.SaveFile(@"C:\SeleniumTempFile");
        }
        #endregion

        #region TestActions
        /// <summary>
        /// Parent method.  Can be overridden for an individual project and still be compatible (IE separate reporting method).
        /// </summary>
        /// <param name="test">The individual test</param>
        public virtual void TestActions(ParentTest test)
        {
            test.ResetCounters();

            AddText("Test " + test.id + " started", fonttype.TestFont);
            
            
                test.RunTest();
            
       

            passedcount += test.passedcheck;
            errorcount += test.failedcheck;
            warningcount += test.warningcheck;
            reporterBox.SelectionFont = errortext;
            TimeSpan timenow = DateTime.Now - test.time;
            
            AddText(test.error, fonttype.ErrorFont);
            if (test.failedcheck > 0)
            {
                if (test.description != null)
                {
                    AddText(test.description, fonttype.ErrorFont);
                }
                AddText("               Test failed with " +
                    test.failedcheck.ToString() + " errors, " +
                    test.passedcheck.ToString() + " passed, and " +
                    test.warningcheck.ToString() + " warning(s). Execution time: " + timenow.ToString(), fonttype.ErrorFont);
            }
            else
            {
                AddText("               Test passed with " +
                    test.passedcheck.ToString() + " passed, and " +
                    test.warningcheck.ToString() + " warning(s). Execution time: " + timenow.ToString(), fonttype.RegularFont);
            }
            reporterBox.Refresh();
        }
        #endregion
    }
}
