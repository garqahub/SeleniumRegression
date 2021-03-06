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
    class Connect_ManualActivity_NoName : ParentTest
    {
        ConnectUtility utility;
        public Connect_ManualActivity_NoName(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "Connect_ManualActivity_NoName";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Try to make a Manual Activity without a name and trigger validation**";
            utility = new ConnectUtility(this);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {
            selenium.Open(base.baseURL);
            utility.SignIn("gctestuser009", "test1!");
            quality.Click("id=navBarTabAnalyze");
            quality.WaitForPageToLoad("30000");
            quality.Click("link=Manual Activity");
            quality.WaitForPageToLoad("30000");
            
            quality.Select("id=activityTypeDecoration:activityType", "label=Running");
            quality.Type("id=speedPaceContainer:activitySummarySumDuration", "4");
            quality.Click("id=saveButton");
            Thread.Sleep(3000);
            quality.IsTextPresent("Required");
            quality.IsTextPresent("Missing request parameter: activityName");
            quality.Type("id=activityNameDecoration:activityName", "I have ");
            Thread.Sleep(2000);
            quality.Click("id=saveButton");
            Thread.Sleep(2000);
            quality.WaitForPageToLoad("30000");
            quality.IsElementPresent("id=detailsSummaryBox");
            utility.SignOut();
            
        }
        #endregion


    }


}
