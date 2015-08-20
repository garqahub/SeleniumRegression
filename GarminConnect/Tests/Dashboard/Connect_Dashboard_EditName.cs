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
    class Connect_Dashboard_EditName : ParentTest
    {
        ConnectUtility utility;
        public Connect_Dashboard_EditName(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "Connect_Dashboard_EditName";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Log on and edit the activity name on the Dashboard, and test the 75 character validation**";
            utility = new ConnectUtility(this);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {

            selenium.Open(base.baseURL);
            utility.SignIn("gctestuser010", "test1!");
            quality.Click("link=Quick Edit");
            quality.Type("id=activityNameInput1", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam diam neque posuere.");
            //Script is not done.  See jira Connect-10209 for more details.
        }
        #endregion


    }


}
