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
    class Connect_CheckFirmware_Edge605 : ParentTest
    {
        ConnectUtility utility;
        public Connect_CheckFirmware_Edge605(string url, WebDriverBackedSelenium webdriver, StringBuilder verrors)
        {
            //****Enter in Script Name here****  
            base.id = "CheckFirmware_Edge605";  //Enter Test Name
            base.baseURL = url;  //Be sure to update the selenium.Open command with baseURL
            base.selenium = webdriver;
            base.verificationErrors = verrors;
            base.quality = new QualityCheck(this);
            base.description = "**Create a user, upload a file from an Edge 605 and check for the firmware update notice**";
            utility = new ConnectUtility(this);
        }

        #region Test Script
        //this is the test code generated by selenium
        //****Paste test script here*****
        public override void RunTest()
        {
            selenium.Open(baseURL);
            base.username = utility.CreateUser("test1!");
            utility.UploadFile(@"C:\RegressionUpload\Edge605.tcx");
            quality.WaitForPageToLoad("30000");

            utility.SignOut();
            quality.WaitForPageToLoad("30000");
            utility.SignIn(username, "test1!");
            quality.WaitForPageToLoad("30000");
            utility.CheckForFirmware();
            //quality.IsTextPresent("Firmware Update");
            utility.SignOut();
        }
        #endregion


    }


}
