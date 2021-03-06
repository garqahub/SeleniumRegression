﻿#region Test Information
/*
* Test Name:
* Author:
* Purpose/Description:
* Creation Date:
* Version: 
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
    class Connect_ManualActivity_PaceCalc : ParentTest
    {
        ConnectUtility utility;

        public Connect_ManualActivity_PaceCalc(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "Connect_ManualActivity_PaceCalc";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Make sure that the pace calculation is correct for Manual Activity**";
            utility = new ConnectUtility(this);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {
            string pace;
            selenium.Open(base.baseURL);
            utility.SignIn("gctestuser020", "test1!");
            quality.Click("id=navBarTabAnalyze");
            quality.WaitForPageToLoad("30000");
            quality.Click("link=Manual Activity");
            quality.WaitForPageToLoad("30000");
            quality.Type("id=activityNameDecoration:activityName", "I have");
            quality.Select("id=activityTypeDecoration:activityType", "label=Running");
            Thread.Sleep(1000);
            quality.Type("id=speedPaceContainer:activitySummarySumDuration", "1");
            quality.Type("id=speedPaceContainer:activitySummarySumDistanceDecoration:activitySummarySumDistance", "10");
            Thread.Sleep(5000);
            pace = selenium.GetValue("name=speedPaceContainer:activitySummaryWeightedMeanPaceDecoration:activitySummaryWeightedMeanPace");

            if (pace == "06:00")
            {
                passedcheck++;
            }
            else
            {
                failedcheck++;
                quality.ErrorReport("Pace Value Incorrect!", CheckType.Equal);
            }
            utility.SignOut();


        }
        #endregion


    }


}
