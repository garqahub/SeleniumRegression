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
#endregion
namespace SeleniumRegression
{
    class ElasticPath : TestRunner
    {

        public List<ParentTest> BrowserState, Locale, Purchase, Register, SingleSignOnLocale, SingleSignOn;

        #region Constructor
        public ElasticPath(StringBuilder verrors, List<string> browser, List<string> scripts, ref RichTextBox reporting, string url)
        {

            base.verificationErrors = verrors;
            base.reporterBox = reporting;
            base.baseURL = url;
            base.browsers = browser;
            base.scriptset = scripts;
            BrowserState = new List<ParentTest>();
            Locale = new List<ParentTest>();
            Purchase = new List<ParentTest>();
            Register = new List<ParentTest>();
            SingleSignOnLocale = new List<ParentTest>();
            SingleSignOn = new List<ParentTest>();
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            RunTests();
        }
        public ElasticPath(List<string> browser, List<string> scripts, ref RichTextBox reporting, string url)
        {

            base.reporterBox = reporting;
            base.baseURL = url;
            base.browsers = browser;
            base.scriptset = scripts;
            BrowserState = new List<ParentTest>();
            Locale = new List<ParentTest>();
            Purchase = new List<ParentTest>();
            Register = new List<ParentTest>();
            SingleSignOnLocale = new List<ParentTest>();
            SingleSignOn = new List<ParentTest>();
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            PopulateLists();

            scriptlist.Add(BrowserState);
            scriptlist.Add(Locale);
            scriptlist.Add(Purchase);
            scriptlist.Add(Register);
            scriptlist.Add(SingleSignOnLocale);
            scriptlist.Add(SingleSignOn);
        }
        #endregion

        //Populate the script lists here.  Follow the example on how to add to a list
        #region Populate Lists
        /// <summary>
        /// Use this method to populate the lists.  They are already set to be selected from the 
        /// CycleScripts method and no other work is required.
        /// </summary>
        public override void PopulateLists()
        {
            BrowserState.Clear();
            Locale.Clear();
            Purchase.Clear();
            Register.Clear();
            SingleSignOn.Clear();
            SingleSignOnLocale.Clear();
            base.PopulateLists();
            //SignIn.Add(new Connect_SignIn(base.baseURL, base.webdriver, base.verificationErrors));
            BrowserState.Add(new BrowserStateTest(base.baseURL, base.webdriver, base.verificationErrors));
            Locale.Add(new LocaleTest(base.baseURL, base.webdriver, base.verificationErrors));
            Purchase.Add(new PurchaseTest(base.baseURL, base.webdriver, base.verificationErrors));
            Register.Add(new RegisterUserTest(base.baseURL, base.webdriver, base.verificationErrors));
            SingleSignOnLocale.Add(new SingleSignOnLocaleTest(base.baseURL, base.webdriver, base.verificationErrors));
            SingleSignOn.Add(new SingleSignOnTest(base.baseURL, base.webdriver, base.verificationErrors));

        }
        #endregion

        #region Run Test

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

        #region CycleScripts
        public override void CycleScripts()
        {
            for (int i = 0; i < scriptset.Count; i++)
            {
                base.CycleScripts();
                AddText("   Script Set: " + scriptset[i] + " started.", fonttype.ScriptFont);
                
                switch (scriptset[i])
                {
                    case "BrowserState":
                        base.testcount += BrowserState.Count;
                        for (int j = 0; j < BrowserState.Count; j++)
                        {
                            base.TestActions(BrowserState[j]);
                        }
                        break;

                    case "Locale":
                        base.testcount += Locale.Count;
                        for (int j = 0; j < Locale.Count; j++)
                        {
                            base.TestActions(Locale[j]);
                        }
                        break;
                    case "Purchase":
                        base.testcount += Purchase.Count;
                        for (int j = 0; j < Purchase.Count; j++)
                        {
                            base.TestActions(Purchase[j]);
                        }
                        break;
                    case "Register":
                        base.testcount += Register.Count;
                        for (int j = 0; j < Register.Count; j++)
                        {
                            base.TestActions(Register[j]);
                        }
                        break;
                    case "SingleSignOnLocale":
                        base.testcount += SingleSignOnLocale.Count;
                        for (int j = 0; j < SingleSignOnLocale.Count; j++)
                        {
                            base.TestActions(SingleSignOnLocale[j]);
                        }
                        break;
                    case "SingleSignOn":
                        base.testcount += SingleSignOn.Count;
                        for (int j = 0; j < SingleSignOn.Count; j++)
                        {
                            base.TestActions(SingleSignOn[j]);
                        }
                        break;
                 
                    case "All Scripts":
                        scriptset.Clear();
                        scriptset.Add("BrowserState");
                        scriptset.Add("Locale");
                        scriptset.Add("Purchase");
                        scriptset.Add("Register");
                        scriptset.Add("SingleSignOnLocale");
                        scriptset.Add("SingleSignOn");
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