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
    class GarminConnect : TestRunner
    {

        public List<ParentTest> SignIn, AccountCreation, Activities, ActivityDetail, Workouts, Courses, Dashboard,
            Navigation, Explore, Reports, Health, Goals, Upload, Settings, CheckFirmware, Troubleshoot, ManualActivity;

        #region Constructor

        /// <summary>
        /// The Garmin Connect project.  This is set up for just Connect.  You can mimic the behavior to add a new project.
        /// </summary>
        /// <param name="verrors">Legacy, just pass the stringbuilder from the GUI</param>
        /// <param name="browser">The list of browsers to test</param>
        /// <param name="scripts">List of scenarios to test</param>
        /// <param name="reporting">Reference to the reporting box from the GUI</param>
        /// <param name="url">The URL to test.</param>
        public GarminConnect(StringBuilder verrors, List<string> browser, List<string> scripts, ref RichTextBox reporting, string url)
        {

            base.verificationErrors = verrors;
            base.reporterBox = reporting;
            base.baseURL = url;
            base.browsers = browser;
            base.scriptset = scripts;
            AddText("Testing URL:" + baseURL, fonttype.ScriptFont);
            SignIn = new List<ParentTest>();
            AccountCreation = new List<ParentTest>();
            Activities = new List<ParentTest>();
            ActivityDetail = new List<ParentTest>();
            Workouts = new List<ParentTest>();
            Courses = new List<ParentTest>();
            Dashboard = new List<ParentTest>();
            Navigation = new List<ParentTest>();
            Explore = new List<ParentTest>();
            Reports = new List<ParentTest>();
            Health = new List<ParentTest>();
            Goals = new List<ParentTest>();
            Upload = new List<ParentTest>();
            Settings = new List<ParentTest>();
            CheckFirmware = new List<ParentTest>();
            ManualActivity = new List<ParentTest>();
            Troubleshoot = new List<ParentTest>();
            RunTests();
        }
        /// <summary>
        /// Garmin Connect project.  This constructor is for running just one test and to instantiate the tests to grab their ID's
        /// </summary>
        /// <param name="browser">List of browsers to use</param>
        /// <param name="scripts">The scenarios to run.  In this case it's going to be null as the user hasn't picked a test</param>
        /// <param name="reporting">A reference to the reporting box to update it</param>
        /// <param name="url">the URL to test</param>
        public GarminConnect(List<string> browser, List<string> scripts, ref RichTextBox reporting, string url)
        {
            base.reporterBox = reporting;
            base.baseURL = url;
            base.browsers = browser;
            base.scriptset = scripts;
            SignIn = new List<ParentTest>();
            AccountCreation = new List<ParentTest>();
            Activities = new List<ParentTest>();
            ActivityDetail = new List<ParentTest>();
            Workouts = new List<ParentTest>();
            Courses = new List<ParentTest>();
            Dashboard = new List<ParentTest>();
            Navigation = new List<ParentTest>();
            Explore = new List<ParentTest>();
            Reports = new List<ParentTest>();
            Health = new List<ParentTest>();
            Goals = new List<ParentTest>();
            Upload = new List<ParentTest>();
            Settings = new List<ParentTest>();
            CheckFirmware = new List<ParentTest>();
            ManualActivity = new List<ParentTest>();
            Troubleshoot = new List<ParentTest>();
            PopulateLists();

            //This order matters.  It must match the GUI list exactly for the index to match.
            scriptlist.Add(AccountCreation);
            scriptlist.Add(SignIn);
            scriptlist.Add(Activities);
            scriptlist.Add(ActivityDetail);
            scriptlist.Add(Workouts);
            scriptlist.Add(Courses);
            scriptlist.Add(Dashboard);
            scriptlist.Add(Navigation);
            scriptlist.Add(Explore);
            scriptlist.Add(Reports);
            scriptlist.Add(Health);
            scriptlist.Add(Goals);
            scriptlist.Add(Upload);
            scriptlist.Add(Settings);
            scriptlist.Add(CheckFirmware);
            scriptlist.Add(ManualActivity);
            scriptlist.Add(Troubleshoot);
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
            SignIn.Clear();
            AccountCreation.Clear();
            Activities.Clear();
            ActivityDetail.Clear();
            Workouts.Clear();
            Courses.Clear();
            Dashboard.Clear();
            Navigation.Clear();
            Explore.Clear();
            Reports.Clear();
            Health.Clear();
            Goals.Clear();
            Upload.Clear();
            Settings.Clear();
            CheckFirmware.Clear();
            ManualActivity.Clear();
            Troubleshoot.Clear();
            base.PopulateLists();
            //MyCategory.Add(new TestCase(base.baseURL, base.webdriver, base.verificationErrors));
            SignIn.Add(new Connect_SignIn(base.baseURL, base.webdriver, base.verificationErrors));
            SignIn.Add(new Connect_SignInValidation(base.baseURL, base.webdriver, base.verificationErrors));
            
            Settings.Add(new Connect_MeasurementSettings(base.baseURL, base.webdriver, base.verificationErrors));
            Navigation.Add(new Connect_GeneralNavigation(base.baseURL, base.webdriver, base.verificationErrors));
            Navigation.Add(new Connect_Navigation_Unauthenticated(base.baseURL, base.webdriver, base.verificationErrors));
            Upload.Add(new Connect_UploadFile(base.baseURL, base.webdriver, base.verificationErrors));
            Activities.Add(new Connect_ActivitiesSort(base.baseURL, base.webdriver, base.verificationErrors));
            ActivityDetail.Add(new Connect_ActivityDetail_Validation(base.baseURL, base.webdriver, base.verificationErrors));
            //CheckFirmware.Add(new Connect_CheckFirmware_Edge800(base.baseURL, base.webdriver, base.verificationErrors));  // Jira opened
            CheckFirmware.Add(new Connect_CheckFirmware_Edge705(base.baseURL, base.webdriver, base.verificationErrors));
            CheckFirmware.Add(new Connect_CheckFirmware_Edge605(base.baseURL, base.webdriver, base.verificationErrors));
            CheckFirmware.Add(new Connect_CheckFirmware_FR60(base.baseURL, base.webdriver, base.verificationErrors));
            CheckFirmware.Add(new Connect_CheckFirmware_FR405CX(base.baseURL, base.webdriver, base.verificationErrors));
            CheckFirmware.Add(new Connect_CheckFirmware_Edge305(base.baseURL, base.webdriver, base.verificationErrors));
            CheckFirmware.Add(new Connect_CheckFirmware_FR201(base.baseURL, base.webdriver, base.verificationErrors));
            //CheckFirmware.Add(new Connect_CheckFirmware_FR210(base.baseURL, base.webdriver, base.verificationErrors)); //Test Failing
            CheckFirmware.Add(new Connect_CheckFirmware_Edge500(base.baseURL, base.webdriver, base.verificationErrors));
            //CheckFirmware.Add(new Connect_CheckFirmware_FR110(base.baseURL, base.webdriver, base.verificationErrors));  //Test Failing
            //CheckFirmware.Add(new Connect_CheckFirmware_FR910(base.baseURL, base.webdriver, base.verificationErrors));
            CheckFirmware.Add(new Connect_CheckFirmware_FR610(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Connect_Dashboard_CreateGoal(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Connect_Dashboard_NoGoal(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Connect_Dashboard_PercentComplete(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Connect_Dashboard_NoUploads(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Connect_Dashboard_FiveItems(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Connect_Dashboard_ActivityNameTabs(base.baseURL, base.webdriver, base.verificationErrors));
            Dashboard.Add(new Connect_Dashboard_ActivityType(base.baseURL, base.webdriver, base.verificationErrors));
            //Dashboard.Add(new Connect_Dashboard_FiveItems(base.baseURL, base.webdriver, base.verificationErrors)); //jira 10209
            ManualActivity.Add(new Connect_ManualActivity_NameCharLimit(base.baseURL, base.webdriver, base.verificationErrors));
            ManualActivity.Add(new Connect_ManualActivity_NoName(base.baseURL, base.webdriver, base.verificationErrors));
            ManualActivity.Add(new Connect_ManualActivity_ActivityType(base.baseURL, base.webdriver, base.verificationErrors));
            ManualActivity.Add(new Connect_ManualActivity_DescriptionLimit(base.baseURL, base.webdriver, base.verificationErrors)); //Related to Jira 10309
            ManualActivity.Add(new Connect_ManualActivity_PaceCalc(base.baseURL, base.webdriver, base.verificationErrors));

        }
        #endregion

        #region Run Test

        /// <summary>
        /// This method is for individual tests.  The order the scenarios are in for GUI and group lists must match
        /// </summary>
        /// <param name="index">The index for which scenario the test is in</param>
        /// <param name="testnumber">The index of the test number</param>
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
                webdriver.Close();
            }
        }
        /// <summary>
        /// Method for running a scenario of tests
        /// </summary>
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
        /// <summary>
        /// This is used to run through all of the scripts in a scenario.  Individual tests are run elsewhere
        /// </summary>
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
                    case "Activities":
                        base.testcount += Activities.Count;
                        for (int j = 0; j < Activities.Count; j++)
                        {
                            base.TestActions(Activities[j]);
                        }
                        break;
                    case "Activity Detail":
                        base.testcount += ActivityDetail.Count;
                        for (int j = 0; j < ActivityDetail.Count; j++)
                        {
                            base.TestActions(ActivityDetail[j]);
                        }
                        break;
                    case "Workouts":
                        base.testcount += Workouts.Count;
                        for (int j = 0; j < Workouts.Count; j++)
                        {
                            base.TestActions(Workouts[j]);
                        }
                        break;
                    case "Courses":
                        base.testcount += Courses.Count;
                        for (int j = 0; j < Courses.Count; j++)
                        {
                            base.TestActions(Courses[j]);
                        }
                        break;
                    case "Dashboard":
                        base.testcount += Dashboard.Count;
                        for (int j = 0; j < Dashboard.Count; j++)
                        {
                            base.TestActions(Dashboard[j]);
                        }
                        break;
                    case "Navigation":
                        base.testcount += Navigation.Count;
                        for (int j = 0; j < Navigation.Count; j++)
                        {
                            base.TestActions(Navigation[j]);
                        }
                        break;
                    case "Explore":
                        base.testcount += Explore.Count;
                        for (int j = 0; j < Explore.Count; j++)
                        {
                            base.TestActions(Explore[j]);
                        }
                        break;
                    case "Reports":
                        base.testcount += Reports.Count;
                        for (int j = 0; j < Reports.Count; j++)
                        {
                            base.TestActions(Reports[j]);
                        }
                        break;
                    case "Health":
                        base.testcount += Health.Count;
                        for (int j = 0; j < Health.Count; j++)
                        {
                            base.TestActions(Health[j]);
                        }
                        break;
                    case "Goals":
                        base.testcount += Goals.Count;
                        for (int j = 0; j < Goals.Count; j++)
                        {
                            base.TestActions(Goals[j]);
                        }
                        break;
                    case "Upload":
                        base.testcount += Upload.Count;
                        for (int j = 0; j < Upload.Count; j++)
                        {
                            base.TestActions(Upload[j]);
                        }
                        break;
                    case "Settings":
                        base.testcount += Settings.Count;
                        for (int j = 0; j < Settings.Count; j++)
                        {
                            base.TestActions(Settings[j]);
                        }
                        break;
                    case "Check Firmware":
                        base.testcount += CheckFirmware.Count;
                        for (int j = 0; j < CheckFirmware.Count; j++)
                        {
                            base.TestActions(CheckFirmware[j]);
                        }
                        break;
                    case "Manual Activity":
                        base.testcount += ManualActivity.Count;
                        for (int j = 0; j < ManualActivity.Count; j++)
                        {
                            base.TestActions(ManualActivity[j]);
                        }
                        break;
                    case "TroubleShoot":
                        base.testcount += Troubleshoot.Count;
                        for (int j = 0; j < Troubleshoot.Count; j++)
                        {
                            base.TestActions(Troubleshoot[j]);
                        }
                        break;

                    case "All Scripts":
                        scriptset.Clear();
                        scriptset.Add("Account Creation");
                        scriptset.Add("Sign In");
                        scriptset.Add("Activities");
                        scriptset.Add("Activity Detail");
                        scriptset.Add("Workouts");
                        scriptset.Add("Courses");
                        scriptset.Add("Dashboard");
                        scriptset.Add("Navigation");
                        scriptset.Add("Explore");
                        scriptset.Add("Reports");
                        scriptset.Add("Health");
                        scriptset.Add("Goals");
                        scriptset.Add("Upload");
                        scriptset.Add("Settings");
                        scriptset.Add("Check Firmware");
                        //scriptset.Add("TroubleShoot");
                        scriptset.Add("Manual Activity");
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
