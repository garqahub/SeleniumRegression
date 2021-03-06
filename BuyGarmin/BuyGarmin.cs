﻿#region Using Statements
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
#endregion

namespace SeleniumRegression
{
    class BuyGarmin : TestRunner
    {

        public List<ParentTest> SignIn, AccountCreation, Registration, SoftwareUpdates, Navigation, MapUpdates;

        #region Constructor
        public BuyGarmin(StringBuilder verrors, List<string> browser, List<string> scripts, ref RichTextBox reporting, string url)
        {

            base.verificationErrors = verrors;
            base.reporterBox = reporting;
            base.baseURL = url;
            base.browsers = browser;
            base.scriptset = scripts;
            SignIn = new List<ParentTest>();
            AccountCreation = new List<ParentTest>();
            Registration = new List<ParentTest>();
            SoftwareUpdates = new List<ParentTest>();
            Navigation = new List<ParentTest>();
            MapUpdates = new List<ParentTest>();
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            RunTests();
        }

        public BuyGarmin(List<string> browser, List<string> scripts, ref RichTextBox reporting, string url)
        {


            base.reporterBox = reporting;
            base.baseURL = url;
            base.browsers = browser;
            base.scriptset = scripts;
            SignIn = new List<ParentTest>();
            AccountCreation = new List<ParentTest>();
            Registration = new List<ParentTest>();
            SoftwareUpdates = new List<ParentTest>();
            Navigation = new List<ParentTest>();
            MapUpdates = new List<ParentTest>();
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            PopulateLists();

            scriptlist.Add(AccountCreation);
            scriptlist.Add(SignIn);
            scriptlist.Add(Navigation);
        }
        #endregion

        //Populate the script lists here.  Follow the example on how to add to a list
        #region Populate Tests
        /// <summary>
        /// Use this method to populate the lists.  They are already set to be selected from the 
        /// CycleScripts method and no other work is required.
        /// </summary>
        public override void PopulateLists()
        {
            SignIn.Clear();
            AccountCreation.Clear();
            Registration.Clear();
            SoftwareUpdates.Clear();
            Navigation.Clear();
            MapUpdates.Clear();
            base.PopulateLists();
            //**below is a sample of how to add in a test.  Simply add in the name of the test in replace of Connect_SignIn
            //SignIn.Add(new Connect_SignIn(base.baseURL, base.webdriver, base.verificationErrors));
           // SignIn.Add(new prototype(base.baseURL, base.webdriver, base.verificationErrors));  //This Test was to investigate Selenium RC - Webdriver opted for due to usability/port setting issues/future support.
            Navigation.Add(new Buy_PurchaseTest(base.baseURL, base.webdriver, base.verificationErrors));
        }
        #endregion

        #region Run Tests

        public override void RunTests(int index, int testnumber)
        {
            base.RunTests();
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            for (int i = 0; i < base.browsers.Count; i++)
            {
                base.SetupTest(browsers[i]);
                PopulateLists();
                AddText("   Script Set: " + scriptlist[index][testnumber].id + " started.", fonttype.ScriptFont);
                scriptlist[index][testnumber].selenium = webdriver;
                TestActions(scriptlist[index][testnumber]);
            }
        }
        public override void RunTests()
        {
            base.RunTests();

            for (int i = 0; i < browsers.Count; i++)
            {
                base.SetupTest(browsers[i]);
                PopulateLists();
                CycleScripts();
            }
        }
        #endregion

        #region Cycle Scripts
        public override void CycleScripts()
        {
            for (int i = 0; i < scriptset.Count; i++)
            {
                base.CycleScripts();
                AddText("   Script Set: " + scriptset[i] + " started.", fonttype.ScriptFont);
                switch (scriptset[i])
                {
                    case "Account Creation":
                        base.testcount += AccountCreation.Count;
                        for (int j = 0; j < AccountCreation.Count; j++)
                        {
                            base.TestActions(AccountCreation[j]);
                        }
                        break;

                    case "Sign In":
                        base.testcount += SignIn.Count;
                        for (int j = 0; j < SignIn.Count; j++)
                        {
                            base.TestActions(SignIn[j]);
                        }
                        break;

                    case "Registration":
                        base.testcount += Registration.Count;
                        for (int j = 0; j < Registration.Count; j++)
                        {
                            base.TestActions(Registration[j]);
                        }
                        break;
                    case "Software updates":
                        base.testcount += SoftwareUpdates.Count;
                        for (int j = 0; j < SoftwareUpdates.Count; j++)
                        {
                            base.TestActions(SoftwareUpdates[j]);
                        }
                        break;
                    case "Navigation":
                        base.testcount += Navigation.Count;
                        for (int j = 0; j < Navigation.Count; j++)
                        {
                            base.TestActions(Navigation[j]);
                        }
                        break;
                    case "Map updates":
                        base.testcount += MapUpdates.Count;
                        for (int j = 0; j < MapUpdates.Count; j++)
                        {
                            base.TestActions(MapUpdates[j]);
                        }
                        break;
                    case "All Scripts":
                        scriptset.Clear();
                        scriptset.Add("Account Creation");
                        scriptset.Add("Sign In");
                        scriptset.Add("Registration");
                        scriptset.Add("Software updates");
                        scriptset.Add("Navigation");
                        scriptset.Add("Map updates");
                        CycleScripts();
                        scriptset.Clear();
                        break;
                }
            }
            base.TeardownTest();
        }
        #endregion
    }
}
