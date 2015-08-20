/*  Date: 3/6/12
 *  Original Author: Michael Schultz
 *  Purpose: Winforms class to launch tests
 *  Description: Methods for winform items.  Goal is to keep logic out of the GUI as much as possible
 *  
 */

 #region UsingStatements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
#endregion

namespace SeleniumRegression
{
    public partial class RegressionGUI : Form
    {
        
        
        #region Variables
        public bool ieflag, chromeflag, firefoxflag, testready;//flags for browser and if the test selections are ready.
        TestRunner controller;  //parent class for child project classes
        public List<string> connectscripts, myscripts, buyscripts, elasticscripts, oemscripts, browser, scriptlist; //string lists
        public StringBuilder sBuilder; // for selenium
        public List<List<string>> testlist;//List of tests for individual selection.  This list must match GUI list for index purposes.
        Thread runthread;
        #endregion

        #region Constructor and Loading
        public RegressionGUI()
        {
            InitializeComponent();
            browser = new List<string>();  //List of browsers
            scriptlist = new List<string>();  //List of Script Sets chosen
            PopulateBuyGarmin(ref buyscripts);  //populates just the list of buy garmin script sets 
            PopulateConnect(ref connectscripts); //populates just the list of connect script sets
            PopulateMyGarmin(ref myscripts);  //populates just the list of my script sets
            PopulateElastic(ref elasticscripts);//populates the list for elastic path
            PopulateOEM(ref oemscripts); //populates the list for oem
            sBuilder = new StringBuilder();  //string builder for selenium
            string time = System.DateTime.Now.ToLongDateString();
            SaveFileBox.Text = @"C:\Regression" + time + ".doc";
            testlist = new List<List<string>>();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void RegressionGUI_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region CheckBoxes
        //Check boxes to included or exclude a browser in a test run
        //Not much more going on for these 3 methods.
        private void IEBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ieflag == false)
            {
                ieflag = true;
            }
            else
            {
                ieflag = false;
            }

        }

        private void FFBox_CheckedChanged(object sender, EventArgs e)
        {
            if (firefoxflag == false)
            {
                firefoxflag = true;
            }
            else
            {
                firefoxflag = false;
            }

        }

        private void Cromebox_CheckedChanged(object sender, EventArgs e)
        {
            if (chromeflag == false)
            {
                chromeflag = true;
            }
            else
            {
                chromeflag = false;
            }

        }
        #endregion

        #region Radio Buttons
        //Mark the clicked button
        //Populate Script box just loads up the box for script selection
        private void radioButtonmyGarmin_Click(object sender, EventArgs e)
        {
            radioButtonmyGarmin.Checked = true;
            radioButtonConnect.Checked = false;
            radioButtonBuyGarmin.Checked = false;
            radioButtonElastic.Checked = false;
            radioButtonAutoOEM.Checked = false;
            PopulateScriptBox();
            URLBox.Text = "http://mygarminstg.garmin.com";
        }
        private void radioButtonBuyGarmin_Click(object sender, EventArgs e)
        {
            radioButtonmyGarmin.Checked = false;
            radioButtonConnect.Checked = false;
            radioButtonBuyGarmin.Checked = true;
            radioButtonElastic.Checked = false;
            radioButtonAutoOEM.Checked = false;
            PopulateScriptBox();
            URLBox.Text = "http://buygarminstg.garmin.com";
        }

        private void radioButtonConnect_Click(object sender, EventArgs e)
        {
            radioButtonmyGarmin.Checked = false;
            radioButtonBuyGarmin.Checked = false;
            radioButtonConnect.Checked = true;
            radioButtonElastic.Checked = false;
            radioButtonAutoOEM.Checked = false;
            PopulateScriptBox();
            URLBox.Text = "http://connecttest.garmin.com";
        }
        private void radioButtonElastic_Click(object sender, EventArgs e)
        {
            radioButtonmyGarmin.Checked = false;
            radioButtonBuyGarmin.Checked = false;
            radioButtonConnect.Checked = false;
            radioButtonElastic.Checked = true;
            radioButtonAutoOEM.Checked = false;
            PopulateScriptBox();
            URLBox.Text = "http://buygarminstg.garmin.com/shop";
        }
        private void radioButtonAutoOEM_Click(object sender, EventArgs e)
        {
            radioButtonmyGarmin.Checked = false;
            radioButtonBuyGarmin.Checked = false;
            radioButtonConnect.Checked = false;
            radioButtonElastic.Checked = false;
            radioButtonAutoOEM.Checked = true;
            PopulateScriptBox();
            URLBox.Text = "https://autoem-qa.garmin.com/kenwood/";
        }
        #endregion
                
         #region Buttons
        private void startbutton_Click(object sender, EventArgs e)
        {
            CheckSelections(); //Check to make sure the test is ready
            #region Start Test Validation
            if (testready == true) //test is ready
            {
                ReportingBox.Clear();
                
                PopulateBrowserList(); //grab all selected browsers
                PopulateScriptList();  //grap all selected scripts
                runthread = new Thread(ThreadRun);
                runthread.Start();
                //ThreadRun();
        
            }
            else  // If something was forgotten.
            {
                MessageBox.Show("Please choose a project, browser(s) and script(s)");
                              

            }
            #endregion
        }
        private void getTestBtn_Click(object sender, EventArgs e)
        {
            #region Start Test Validation
            CheckSelections(); //Check to make sure the test is ready
            if (testready == true) //test is ready
            {
                if (ScriptBox.SelectedItems.Count == 1)
                {
                    ReportingBox.Clear();

                    PopulateBrowserList(); //grab all selected browsers
                    PopulateScriptList();  //grap all selected scripts

                    if (radioButtonConnect.Checked == true) //Send off to the Connect class to run the test
                    {
                        controller = new GarminConnect(browser, scriptlist,
                            ref ReportingBox, URLBox.Text);

                    }
                    
                    else if (radioButtonBuyGarmin.Checked == true)  //Send off to the BuyClass to run the test.
                    {
                        controller = new BuyGarmin(browser, scriptlist,
                            ref ReportingBox, URLBox.Text);
                    }
                    else if (radioButtonmyGarmin.Checked == true)  //Send off to my class to run test.
                    {
                        controller = new MyGarmin(browser, scriptlist,
                            ref ReportingBox, URLBox.Text);
                    }
                    else if (radioButtonElastic.Checked == true)
                    {
                        controller = new ElasticPath(browser, scriptlist,
                            ref ReportingBox, URLBox.Text);
                    }
                    else if (radioButtonAutoOEM.Checked == true)
                    {
                        controller = new AutoOEM(browser, scriptlist,
                            ref ReportingBox, URLBox.Text);
                    }
                   

                    testlist = controller.SendTests();
                    listBoxTests.Items.Clear();
                    for (int i = 0; i < testlist[ScriptBox.SelectedIndex].Count; i++)
                    {
                        listBoxTests.Items.Add(testlist[ScriptBox.SelectedIndex][i]);
                    }
                }
                else
                {
                    MessageBox.Show("Please only select one Script");
                }

            }
            else  // If something was forgotten.
            {
                MessageBox.Show("Please choose a project, browser(s) and script(s)");
            }
            #endregion
        }

        private void startIndBtn_Click(object sender, EventArgs e)
        {
            
            #region Start Test Validation
            if (testready == true) //test is ready
            {
                if (listBoxTests.SelectedItems.Count == 1)
                {
                    ReportingBox.Clear();


                    int index, test;
                    index = ScriptBox.SelectedIndex;
                    test = listBoxTests.SelectedIndex;

                    controller.RunTests(index, test);
                    //PopulateBrowserList(); //grab all selected browsers
                    //PopulateScriptList();  //grap all selected scripts

                    //ThreadRun();
                    BoxTotalTests.Text = controller.testcount.ToString();
                    BoxTotalPassed.Text = controller.passedcount.ToString();
                    BoxTotalFailed.Text = controller.errorcount.ToString();
                    BoxTotalWarning.Text = controller.warningcount.ToString();
                    string time = System.DateTime.Now.ToLongDateString();
                    ReportingBox.SaveFile(@SaveFileBox.Text);
                }
                else
                {
                    MessageBox.Show("Please only choose one test for this action");
                }
            }
            else  // If something was forgotten.
            {
                MessageBox.Show("Please choose a project, browser(s) and script(s)");


            }
            #endregion
        }
        #endregion
        
        #region populate scriptbox
        //Here we just check to make sure which is checked and populate the appropriate
        //script options
        private void PopulateScriptBox()
        {
            if (radioButtonBuyGarmin.Checked == true)
            {
                ScriptBox.ClearSelected();
                ScriptBox.Items.Clear();
                for (int i = 0; i < buyscripts.Count; i++)
                {
                    ScriptBox.Items.Add(buyscripts[i]);
                }
            }
            else if (radioButtonConnect.Checked == true)
            {
                ScriptBox.ClearSelected();
                ScriptBox.Items.Clear();
                for (int i = 0; i < connectscripts.Count; i++)
                {
                    ScriptBox.Items.Add(connectscripts[i]);
                }

            }
            else if (radioButtonmyGarmin.Checked == true)
            {
                ScriptBox.ClearSelected();
                ScriptBox.Items.Clear();
                for (int i = 0; i < myscripts.Count; i++)
                {
                    ScriptBox.Items.Add(myscripts[i]);
                }
            }
            else if (radioButtonElastic.Checked == true)
            {
                ScriptBox.ClearSelected();
                ScriptBox.Items.Clear();
                for (int i = 0; i < elasticscripts.Count; i++)
                {
                    ScriptBox.Items.Add(elasticscripts[i]);
                }
            }
            else if (radioButtonAutoOEM.Checked == true)
            {
                ScriptBox.ClearSelected();
                ScriptBox.Items.Clear();
                for (int i = 0; i < oemscripts.Count; i++)
                {
                    ScriptBox.Items.Add(oemscripts[i]);
                }
            }
        }

        #endregion

        //Ideally this would be populated via a loaded file
        //***New script categories are added here***
        //
        //*New projects must be added in the GUI first, with their own radio boxes
        //then create another method to populate the box*
        //*New projects are class children of TestRunner.  See GarminConnect.cs for example.
        #region Populate Lists

        /// <summary>
        /// Populate the script sets for Connect
        /// </summary>
        /// <param name="scripts">The connect index</param>
        private void PopulateConnect(ref List<string> scripts)
        {
            scripts = new List<string>();
            //scripts.Add("All Scripts");
            scripts.Add("Account Creation");
            scripts.Add("Sign In");
            scripts.Add("Activities");
            scripts.Add("Activity Detail");
            scripts.Add("Workouts");
            scripts.Add("Courses");
            scripts.Add("Dashboard");
            scripts.Add("Navigation");
            scripts.Add("Explore");
            scripts.Add("Reports");
            scripts.Add("Health");
            scripts.Add("Goals");
            scripts.Add("Upload");
            scripts.Add("Settings");
            scripts.Add("Check Firmware");
            scripts.Add("Manual Activity");
            scripts.Add("TroubleShoot");
        }

        /// <summary>
        /// Populate the script sets for myGarmin
        /// </summary>
        /// <param name="scripts">The my index</param>
        private void PopulateMyGarmin(ref List<string> scripts)
        {
            scripts = new List<string>();
            scripts.Add("Account Creation");
            scripts.Add("Sign In");
            scripts.Add("Navigation");
            scripts.Add("Tracker");
            scripts.Add("Registration");
            scripts.Add("Software updates");
            scripts.Add("Blackberry");
            scripts.Add("Map updates");
        }

        /// <summary>
        /// Populate the script sets for buyGarmin
        /// </summary>
        /// <param name="scripts">The buy index</param>
        private void PopulateBuyGarmin(ref List<string> scripts)
        {
            scripts = new List<string>();
  
            scripts.Add("Account Creation");
            scripts.Add("Sign In");
            scripts.Add("Navigation");
        }

        /// <summary>
        /// Populate the script sets for ElasticPath
        /// </summary>
        /// <param name="scripts">The buy index</param>
        private void PopulateElastic(ref List<string> scripts)
        {
            scripts = new List<string>();
            scripts.Add("BrowserState");
            scripts.Add("Locale");
            scripts.Add("Purchase");
            scripts.Add("Register");
            scripts.Add("SingleSignOnLocale");
            scripts.Add("SingleSignOn");
        }
        private void PopulateOEM(ref List<string> scripts)
        {
            scripts = new List<string>();

            scripts.Add("Account Creation");
            scripts.Add("Sign In");
            scripts.Add("Navigation");
            scripts.Add("Dashboard");
            scripts.Add("Forgot Username");
            scripts.Add("Account");
            scripts.Add("ScanSDcard");
            scripts.Add("NoScanSDcard");
            scripts.Add("TroubleShoot");
        }
        #endregion

        #region Check Selections
        /// <summary>
        /// Run through the projects, browsers and scripts to ensure everything is selected
        /// if not then mark the flag as unready
        /// </summary>
        private void CheckSelections()
        {
            if (radioButtonBuyGarmin.Checked == true || radioButtonConnect.Checked == true || 
                radioButtonmyGarmin.Checked == true||radioButtonElastic.Checked||radioButtonAutoOEM.Checked==true)
            {
                if (ieflag == true || firefoxflag == true || chromeflag == true)
                {
                    if (ScriptBox.SelectedItems.Count > 0)
                    {
                        testready = true;
                        browser.Clear();
                        scriptlist.Clear();
                    }
                    else
                    {
                        testready = false;
                    }
                }
                else
                {
                    testready = false;
                }
            }
            else
            {
                testready = false;
            }
        }
        #endregion

        #region Populate Test Lists
        /// <summary>
        /// Run through the browsers and add the selected to the list
        /// </summary>
        private void PopulateBrowserList()
        {
            if (ieflag == true)
            {
                browser.Add("Internet Explorer");
                
            }
            if (firefoxflag == true)
            {
                browser.Add("FireFox");
            }
            if (chromeflag == true)
            {
                browser.Add("Chrome");
            }
        }

        /// <summary>
        /// Run through the selected scripts and add them to the list.
        /// </summary>
        private void PopulateScriptList()
        {
            if ("All Scripts" == (string)ScriptBox.SelectedItems[0])
            {
                ScriptBox.ClearSelected();
                ScriptBox.SelectedIndex = 0;
            }
               
            for (int i = 0; i < ScriptBox.SelectedItems.Count; i++)
            {
                scriptlist.Add(ScriptBox.SelectedItems[i].ToString());
            }
        }

        #endregion

        #region LaunchScriptSet
        /// <summary>
        /// Is not threaded yet.  Will need major logic overhaul to make that happen.
        /// This does pass along the GUI information to run a script set.  Individual tests are launched from the Individual test start button
        /// </summary>
        private void ThreadRun()
        {
            if (radioButtonBuyGarmin.Checked == true)  //Send off to the BuyClass to run the test.
            {
                controller = new BuyGarmin(sBuilder, browser, scriptlist,
                    ref ReportingBox, URLBox.Text);
            }
            else if (radioButtonConnect.Checked == true) //Send off to the Connect class to run the test
            {
                controller = new GarminConnect(sBuilder, browser, scriptlist,
                    ref ReportingBox, URLBox.Text);
            }
            else if (radioButtonmyGarmin.Checked == true)  //Send off to my class to run test.
            {
                controller = new MyGarmin(sBuilder, browser, scriptlist,
                    ref ReportingBox, URLBox.Text);
            }
            else if (radioButtonElastic.Checked == true)
            {
                controller = new ElasticPath(sBuilder, browser, scriptlist,
                    ref ReportingBox, URLBox.Text);
            }
            else if (radioButtonAutoOEM.Checked == true)
            {
                controller = new AutoOEM(sBuilder, browser, scriptlist,
                    ref ReportingBox, URLBox.Text);
            }
            BoxTotalTests.Text = controller.testcount.ToString();
            BoxTotalPassed.Text = controller.passedcount.ToString();
            BoxTotalFailed.Text = controller.errorcount.ToString();
            BoxTotalWarning.Text = controller.warningcount.ToString();
            string time = System.DateTime.Now.ToLongDateString();
            ReportingBox.SaveFile(@SaveFileBox.Text);
        }
        #endregion

        private void ReportingBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
