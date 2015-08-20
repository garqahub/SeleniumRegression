﻿#region Test Information
/*
* Test Name: Activities- Column sort
* Author: Michael Schultz
* Purpose/Description: Validate that the column sorts work and in the proper order
* Creation Date: 3/29/12
* Version: 1.0
* Updated By:
* Updated Date:
*/
#endregion

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
using System.Drawing;
using Selenium;
#endregion


namespace SeleniumRegression
{
    //****Enter in desired test name in replace of EnterClassName****
    class Connect_ActivitiesSort : ParentTest
    {
        ConnectUtility utility;
        public Connect_ActivitiesSort(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "Activities-Sort";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**This test goes to the Activities page and sorts the activities by column.  FF does not click on the columns correctly and does not indicate a total browser failure**";
            base.username = "staticuser";
            base.password = "test1!";
            utility = new ConnectUtility(this);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {
            selenium.Open(base.baseURL);
            
            utility.SignIn(username, password);
            quality.Click("link=Analyze");
            ClickCategory("id=activitiesForm:activitiesGrid:activityNameColumn", "E Workout");
            ClickCategory("id=activitiesForm:activitiesGrid:activityNameColumn", "A Workout");

            ClickCategory("id=activitiesForm:activitiesGrid:activityTypeColumn", "A Workout");
            ClickCategory("id=activitiesForm:activitiesGrid:activityTypeColumn", "B Workout");

            ClickCategory("id=activitiesForm:activitiesGrid:courseNameColumn", "A Workout");

            ClickCategory("id=activitiesForm:activitiesGrid:activitySummaryBeginTimestampColumn", "E Workout");
            ClickCategory("id=activitiesForm:activitiesGrid:activitySummaryBeginTimestampColumn", "A Workout"); //

            ClickCategory("id=activitiesForm:activitiesGrid:activitySummarySumDurationColumn", "B Workout");
            ClickCategory("id=activitiesForm:activitiesGrid:activitySummarySumDurationColumn", "A Workout");

            ClickCategory("id=activitiesForm:activitiesGrid:activitySummarySumDistanceColumn", "B Workout");
            ClickCategory("id=activitiesForm:activitiesGrid:activitySummarySumDistanceColumn", "E Workout");

            ClickCategory("id=activitiesForm:activitiesGrid:activitySummaryGainElevationColumn", "D Workout");
            ClickCategory("id=activitiesForm:activitiesGrid:activitySummaryGainElevationColumn", "E Workout");

            ClickCategory("id=activitiesForm:activitiesGrid:activitySummaryWeightedMeanSpeedColumn", "B Workout");
            ClickCategory("id=activitiesForm:activitiesGrid:activitySummaryWeightedMeanSpeedColumn", "E Workout");

            ClickCategory("id=activitiesForm:activitiesGrid:activitySummaryMaxSpeedColumn", "B Workout");
            ClickCategory("id=activitiesForm:activitiesGrid:activitySummaryMaxSpeedColumn", "E Workout");
                        
            utility.SignOut();

        }
        #endregion

        private void ClickCategory(string CateogryName, string ActivityName)
        {
            quality.Click(CateogryName);
            Thread.Sleep(10000);
            quality.CheckAreaForText("id=activitiesForm:activitiesGrid:0:activityNameColumn", ActivityName);
        }

    }


}
